using e_commerce.DAL.Models.Catergory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_commerce.DAL.Models_Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> modelbuilder)
    {
        modelbuilder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
        modelbuilder.Property(c=>c.Description).IsRequired().HasMaxLength(250);
        
        modelbuilder.HasMany(c=>c.Products)
            .WithOne(p=>p.Category)
            .HasForeignKey(p=>p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
            
            
        
        
    }
    
}