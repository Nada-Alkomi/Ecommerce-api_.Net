using e_commerce.DAL.Models.Porduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> modelbuilder)
    {
        modelbuilder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        modelbuilder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
        modelbuilder.Property(p=>p.Description).IsRequired().HasMaxLength(500);
        modelbuilder.Property(p=>p.Stock).IsRequired().HasColumnType("int");
        modelbuilder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
        modelbuilder.Property(p=>p.ImageUrl).IsRequired();
        
    
        
        modelbuilder.HasOne(p=>p.Category)
            .WithMany(c=>c.Products)
            .HasForeignKey(p=>p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        modelbuilder.HasMany(p=>p.OrderItem)
            .WithOne(oi=>oi.Product)
            .HasForeignKey(oi=>oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
            
        
    }
    
}