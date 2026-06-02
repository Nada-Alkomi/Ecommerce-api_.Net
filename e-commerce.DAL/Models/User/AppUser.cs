using System.ComponentModel.DataAnnotations;

namespace e_commerce.DAL.Models.User;

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    [Required]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100,ErrorMessage = "Address must be less than 100 characters")]
    public string? Address { get; set; }

    public IEnumerable<Order.Order>? Orders { get; set; }
}