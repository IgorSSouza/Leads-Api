using Microsoft.EntityFrameworkCore;
using Model;

namespace Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Lead>? Leads { get; set; }
        public DbSet<Category>? Categories { get; set; }
        
    }
}
