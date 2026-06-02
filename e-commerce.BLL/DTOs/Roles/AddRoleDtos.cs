using System.ComponentModel.DataAnnotations;

namespace e_commerce.BLL.DTOs.Roles;

public class AddRoleDtos
{
    [Required]
    [MaxLength(100, ErrorMessage = "Role name must be less than 100 characters")]
    public string RoleName { get; set; } = string.Empty;
    
}