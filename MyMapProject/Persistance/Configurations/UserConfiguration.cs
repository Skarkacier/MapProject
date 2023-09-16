using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMapProject.Core.Domain;

namespace MyMapProject.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x=>x.UserRole).WithMany(x=>x.Users).HasForeignKey(x=>x.UserRoleId);
        }
    }

    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasOne(x=>x.Category).WithMany(x=>x.Locations).HasForeignKey(x=>x.CategoryId);
        }
    }
}
