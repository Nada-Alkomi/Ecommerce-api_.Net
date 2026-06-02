using System.ComponentModel.DataAnnotations;

namespace e_commerce.BLL.DTOs.User;

public class LoginDtos
{
    [Required]
    [EmailAddress (ErrorMessage =("Email is not valid"))]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;
}