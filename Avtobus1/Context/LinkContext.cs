using Avtobus1.Models;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.Context
{
    public class LinkContext : DbContext
    {
        public DbSet<Link>? Links { get; set; }

        public LinkContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
