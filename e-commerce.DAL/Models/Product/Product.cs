using System.ComponentModel.DataAnnotations;
using e_commerce.DAL.Models.Catergory;
using e_commerce.DAL.Models.Order_Item;

namespace e_commerce.DAL.Models.Porduct;

public class Product
{
    
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string Name { get; set; }=string.Empty;
    [Required]
    [MaxLength(200, ErrorMessage = "Description must be less than 200 characters")]
    public string Description { get; set; }=string.Empty;
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater than 0")]
    public int Stock { get; set; }
    [Required]
    [Url(ErrorMessage = "Image URL is not valid")]
    public string ImageUrl { get; set; } = string.Empty;
    
    
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public IEnumerable<OrderItem>? OrderItem { get; set; }
    public IEnumerable<CartItem>? CartItem { get; set; }
}