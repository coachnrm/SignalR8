using Microsoft.EntityFrameworkCore;
using SignalR8.Models;

namespace SignalR8.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; } = null!;
    }
}
