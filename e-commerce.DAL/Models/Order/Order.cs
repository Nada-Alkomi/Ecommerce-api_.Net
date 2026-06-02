using System.ComponentModel.DataAnnotations;
using e_commerce.DAL.Models.User;
using e_commerce.DAL.Models.Order_Item;

namespace e_commerce.DAL.Models.Order;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrderNumber { get; set; } = string.Empty;
    [Required]
    public DateTime OrderDate { get; set; }
[Required
,Range(0, double.MaxValue, ErrorMessage = "Total Price must be greater than 0")]
    public decimal TotalPrice { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Status must be less than 100 characters")]
    public string Status { get; set; } = string.Empty;

    [Required] 
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; }
        = new List<OrderItem>();
    
    public virtual ICollection<CartItem> CartItems { get; set; }
    = new List<CartItem>();
}