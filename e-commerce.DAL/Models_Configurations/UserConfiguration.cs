using e_commerce.DAL.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class UserConfiguration:IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> modelbuilder)
    {
       modelbuilder.Property(u=>u.Name).IsRequired().HasMaxLength(50); 
       modelbuilder.Property(u=>u.Address).IsRequired().HasMaxLength(250);
       modelbuilder.Property(u=>u.Email).IsRequired().HasMaxLength(100);
       modelbuilder.Property(u=>u.UserName).IsRequired().HasMaxLength(100);
       modelbuilder.Property(u=>u.PhoneNumber).IsRequired().HasMaxLength(20);
       
       modelbuilder.HasMany(u=>u.Orders)
            .WithOne(o=>o.User)
            .HasForeignKey(o=>o.UserId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}