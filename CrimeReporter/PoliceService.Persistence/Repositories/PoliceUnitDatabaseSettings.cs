namespace PoliceService.Persistence.Repositories
{
    public class PoliceUnitDatabaseSettings
    {
        public bool UseTls { get; internal set; } = false;
        public string Host { get; internal set; } = "mongo_database";
        public string DatabaseName { get; internal set; } = "PoliceUnitsDb";
        public string AuthenticationMechanism { get; internal set; } = "SCRAM-SHA-1";
        public string Username { get; internal set; } = "admin";
        public string Password { get; internal set; } = "admin";
        public string AuthenticationDatabaseName { get; internal set; } = "admin";
        public int Port { get; internal set; } = 27017;
        public string CollectionName { get; internal set; } = "PoliceUnits";
    }
}