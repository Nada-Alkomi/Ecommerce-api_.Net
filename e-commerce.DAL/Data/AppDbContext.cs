using e_commerce.DAL.Models.Catergory;
using e_commerce.DAL.Models.Order_Item;
using e_commerce.DAL.Models.Order;
using e_commerce.DAL.Models.Porduct;
using e_commerce.DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace e_commerce.DAL.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
     public DbSet<AppUser> AppUsers { get; set; }
     public DbSet<Product>Products { get; set; }
     public DbSet<Order> Orders { get; set; }
     public DbSet<OrderItem> OrderItems { get; set; }
     public DbSet<Category>Categories{ get; set;}
     public DbSet<CartItem>CartItems{ get; set;}
        
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


}