
using System.ComponentModel.DataAnnotations;

namespace e_commerce.BLL.DTOs.User;

public class RegisterDtos
{
    [Required]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string Fullname { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100, ErrorMessage = "Address must be less than 100 characters")]
     public string? Address { get; set; } = string.Empty;
}