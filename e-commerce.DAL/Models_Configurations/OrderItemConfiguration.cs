using e_commerce.DAL.Models.Order_Item;
using e_commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> modelbuilder)
    {
        modelbuilder.Property(oi => oi.Quantity).IsRequired();
        modelbuilder.Property(oi => oi.Price).IsRequired().HasColumnType("decimal(18,2)");
        
        modelbuilder.HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItem)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelbuilder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
