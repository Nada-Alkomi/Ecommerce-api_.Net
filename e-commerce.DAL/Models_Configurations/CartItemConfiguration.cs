using Microsoft.EntityFrameworkCore;
using e_commerce.DAL.Models.CartItem;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class CartItemConfiguration:IEntityTypeConfiguration<CartItem>
{

    public void Configure(EntityTypeBuilder<CartItem> modelbuilder)
    { 
        
        modelbuilder.Property(ci => ci.Quantity).IsRequired();
        modelbuilder.Property(ci => ci.UnitPrice).IsRequired().HasPrecision(18, 2);
        
        
        modelbuilder.HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItem)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        
        modelbuilder.HasOne(ci => ci.Product)
            .WithMany(p => p.CartItem)
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict); 
       
    }
}