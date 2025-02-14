using Avtobus1.Models;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.Context
{
    public class LinkContext : DbContext
    {
        public DbSet<Link> Links { get; set; }

        public LinkContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                Environment.GetEnvironmentVariable("CONNECTION_STRING")!,
                new MySqlServerVersion(new Version())
            );
        }
    }
}
