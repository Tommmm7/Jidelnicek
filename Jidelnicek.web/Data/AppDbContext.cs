using Jidelnicek.web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jidelnicek.web.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<Menu> Menu { get; set; }
    }
}
