using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyMapProject.Core.Domain;
using MyMapProject.Persistance.Configurations;

namespace MyMapProject.Persistance.Context
{
    public class LocationsContext : DbContext
    {
        public LocationsContext(DbContextOptions<LocationsContext> options) : base(options)
        { 
        }
        protected readonly IConfiguration Configuration;

        public LocationsContext() 
        { 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = DESKTOP-G69HVIR; Database = locationsdb; integrated security = true;");
        }

        public DbSet<Location> Locations => this.Set<Location>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<UserRole> UserRoles => this.Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
