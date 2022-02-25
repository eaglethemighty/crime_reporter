using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;
using System.Security.Authentication;

namespace PoliceService.Persistence.Repositories
{
    public class PoliceUnitRepository : IAsyncRepository<PoliceUnit>
    {

        private readonly MongoClient _mongoClient;
        private readonly ILogger<PoliceUnitRepository> _logger;
        private PoliceUnitDatabaseSettings _policeUnitDatabaseSettings;
        public PoliceUnitRepository(PoliceUnitDatabaseSettings policeUnitDatabaseSettings, ILogger<PoliceUnitRepository> logger)
        {
            _logger = logger;

            _policeUnitDatabaseSettings = policeUnitDatabaseSettings ?? throw new ArgumentNullException(nameof(policeUnitDatabaseSettings));
            MongoClientSettings settings = InitializeSettings(_policeUnitDatabaseSettings);
            _mongoClient = new MongoClient(settings);

            try
            {
                AddDatabaseUser(_policeUnitDatabaseSettings);
            }
            catch (MongoCommandException cmdException)
            {
                logger.LogWarning("Database failed on command with a message: " + cmdException.Message);
            }
        }

        private static MongoClientSettings InitializeSettings(PoliceUnitDatabaseSettings paymentDatabaseSettings)
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(paymentDatabaseSettings.Host, paymentDatabaseSettings.Port);

            settings.UseTls = paymentDatabaseSettings.UseTls;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(paymentDatabaseSettings.AuthenticationDatabaseName, paymentDatabaseSettings.Username);
            MongoIdentityEvidence evidence = new PasswordEvidence(paymentDatabaseSettings.Password);

            settings.Credential = new MongoCredential(paymentDatabaseSettings.AuthenticationMechanism, identity, evidence);
            return settings;
        }
        private void AddDatabaseUser(PoliceUnitDatabaseSettings paymentDatabaseSettings)
        {
            var user = new BsonDocument { 
                { "createUser", paymentDatabaseSettings.Username }, 
                { "pwd", paymentDatabaseSettings.Password }, 
                { "roles", 
                    new BsonArray { 
                        new BsonDocument {
                        { "role", "readWrite" },
                        { "db", paymentDatabaseSettings.DatabaseName }
                        } 
                    } 
                } 
            };

            _mongoClient.GetDatabase(paymentDatabaseSettings.DatabaseName).RunCommand<BsonDocument>(user);
        }

        public Task AddAsync(PoliceUnit entity)
        {
            return Task.Run(() =>
            {
                var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);
                PoliceUnits.InsertOne(entity);
            });
        }

        public Task DeleteAsync(PoliceUnit entity)
        {
            return Task.Run(() =>
            {
                var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);
                PoliceUnits.DeleteOne(policeUnit => policeUnit.Id == entity.Id);
            });
        }

        public Task EditAsync(PoliceUnit entity)
        {
            return Task.Run(() =>
            {
                var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);
                PoliceUnits.ReplaceOne(policeUnit => policeUnit.Id == entity.Id, entity);
            });
        }

        public Task<List<PoliceUnit>> GetAllAsync()
        {
            return Task.Run(() =>
           {
               var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);

               return PoliceUnits.Find(policeUnit => true).ToList();
           });
        }

        public Task<List<PoliceUnit>> GetAllFilteredByConditionAsync(Func<PoliceUnit, bool> condition)
        {
            return Task.Run(() =>
            {
                var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);
                return PoliceUnits.Find(policeUnit => true).ToList().Where(condition).ToList();
            });
        }

        public Task<PoliceUnit?> GetByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var PoliceUnits = _mongoClient.GetDatabase(_policeUnitDatabaseSettings.DatabaseName).GetCollection<PoliceUnit>(_policeUnitDatabaseSettings.CollectionName);
                return PoliceUnits.Find(policeUnit => policeUnit.Id == id).FirstOrDefault();
            });
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(true);
        }
    }
}