using e_commerce.BLL.DTOs;
using e_commerce.BLL.DTOs.User;
using e_commerce.DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace e_commerce.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CommonRespons> RegisterAsync(RegisterDtos dtos)
    {
        
        var userExist = await _userManager.FindByEmailAsync(dtos.Email);
        if (userExist is not null)
        {
            
            return new CommonRespons("there is problems while regidtring.", false);
        }

       
        var newUser = new AppUser
        {
            Fullname = dtos.Fullname,
            Email = dtos.Email,
            UserName = dtos.Email
        };

        
        var result = await _userManager.CreateAsync(newUser, dtos.Password);
        if (!result.Succeeded)
        {
            return new CommonRespons("There was a problem while registering.", false);
        }

       
        return new CommonRespons("User registered successfully.", true);
    }
}