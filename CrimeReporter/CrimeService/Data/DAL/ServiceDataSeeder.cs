using CrimeService.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeService.Data.DAL
{
    public static class ServiceDataSeeder
    {
        public static void SeedCrimeData(this IApplicationBuilder builder)
        {
            using var Scope = builder.ApplicationServices.CreateScope();
            DbAccess? ScopeDbAccess;
            ILogger? Logger = null;

            try
            {
                ScopeDbAccess = Scope.ServiceProvider.GetRequiredService<DbAccess>();
                Logger = Scope.ServiceProvider.GetRequiredService<ILogger>();
            }
            catch (InvalidOperationException)
            {
                if (Logger is not null)
                {
                    Logger.LogError("Unable to get required database access service in order to seed data. Trying to continue without seeded data... ");
                }
                return;
            }
            ScopeDbAccess.CrimeEvents.AddRange(GetExampleCrimeEvents());
        }
        public static void ApplyPendingMigrations(this IApplicationBuilder builder)
        {
            DbAccess? ScopeDbAccess;
            ILogger? Logger = null;
            using var Scope = builder.ApplicationServices.CreateScope();

            try
            {
                ScopeDbAccess = Scope.ServiceProvider.GetRequiredService<DbAccess>();
                Logger = Scope.ServiceProvider.GetRequiredService<ILogger>();
            }
            catch (InvalidOperationException)
            {
                if (Logger is not null)
                {
                    Logger.LogError("Unable to get required database access service in order to apply migrations. Trying to continue without applying migrations... ");
                }
                return;
            }
            if (ScopeDbAccess.Database.IsRelational())
            {
                if (ScopeDbAccess.Database.GetPendingMigrations().Any())
                {
                    ScopeDbAccess.Database.Migrate();
                }
            }
        }
        public static IList<CrimeEvent> GetExampleCrimeEvents()
        {
            List<CrimeEvent> CrimeEventList = new();
            CrimeEventList.Add(new CrimeEvent()
            {
                Id = new Guid("0aa1862c-99a7-4fc3-b668-9f372be6c781"),
                EventType = CrimeEventType.Burglary,
                Location = "Kraków, Ślusarska 9",
                Description = "Someone broke into the codecool facilities in order to steal exam details",
                ReporterEmail = "abcdef@gmail.com",
                Status = CrimeStatus.Waiting,
                LawEnforcementId = "621888d6851ced5aa9518dbb"
            });

            CrimeEventList.Add(new CrimeEvent()
            {
                Id = new Guid("06069fbd-d7d9-4b86-8b24-d5ad316c6b9f"),
                EventType = CrimeEventType.Murder,
                Location = "Kraków, Czerwone Maki 82",
                Description = "Someone seems to have lost 10-0 in table soccer and appears to be dead.",
                ReporterEmail = "asdf@gmail.com",
                Status = CrimeStatus.Declined,
                LawEnforcementId = "621888dc851ced5aa9518dbc"
            });

            CrimeEventList.Add(new CrimeEvent()
            {
                Id = new Guid("3e559015-5efa-4809-8745-b11982922e5a"),
                EventType = CrimeEventType.Mugging,
                Location = "Armii Krajowej 11, Kraków",
                Description = "A group of masked and armed individuals broke into the local casino",
                ReporterEmail = "qwerty@gmail.com",
                Status = CrimeStatus.Finished,
                LawEnforcementId = "621888de851ced5aa9518dbd"
            });


            return CrimeEventList;
        }
    }
}
