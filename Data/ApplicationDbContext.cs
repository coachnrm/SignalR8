using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using SignalR8.Models;

namespace SignalR8.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<NurseRequest> NurseRequest {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<NurseRequest>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
            base.OnModelCreating(modelBuilder);
        }      
    }
}
