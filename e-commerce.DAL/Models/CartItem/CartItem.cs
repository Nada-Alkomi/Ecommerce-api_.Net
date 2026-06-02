using e_commerce.DAL.Models.Porduct;


using e_commerce.DAL.Models.User;

public class CartItem
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; } = null!;

    public int Quantity { get; set; }

    public Product Product { get; set; } = null!;
    
    public bool IsSelected { get; set; }=false;

    public AppUser User { get; set; } = null!;
    public object UnitPrice { get; set; }
    public object Cart { get; set; }
    public object? CartId { get; set; }
}