using Microsoft.AspNetCore.Identity;

namespace e_commerce.DAL.Models.User;

public class AppUser:IdentityUser
{
    public string Fullname { get; set; }=string.Empty;
    public string? Address { get; set; }=string.Empty;
     
    
    
}