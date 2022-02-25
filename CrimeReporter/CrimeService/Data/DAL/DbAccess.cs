using CrimeService.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeService.Data.DAL
{
    public class DbAccess : DbContext
    {
        public DbAccess(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CrimeEvent> CrimeEvents { get; set; }
    }
}
