using e_commerce.DAL.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> moderbuilder)
    {
        moderbuilder.Property(o=>o.OrderDate).IsRequired();
        moderbuilder.Property(o=>o.TotalPrice).IsRequired().HasPrecision(18,2);
        moderbuilder.Property(o=>o.Status).IsRequired().HasMaxLength(20);
        moderbuilder.Property(o=>o.OrderNumber).IsRequired().HasMaxLength(20);
        
         moderbuilder.HasOne(o=>o.User)
             .WithMany(u=>u.Orders)
             .HasForeignKey(o=>o.UserId)
             .OnDelete(DeleteBehavior.Restrict);
         
         moderbuilder.HasMany(o=>o.OrderItems)
            .WithOne(oi=>oi.Order)
            .HasForeignKey(oi=>oi.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
            
         
    }
}