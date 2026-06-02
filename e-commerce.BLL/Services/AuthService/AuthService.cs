using e_commerce.BLL.DTOs;
using e_commerce.BLL.DTOs.User;
using e_commerce.DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using e_commerce.BLL.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace e_commerce.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    public  AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration= configuration;
    }
    public async Task<CommonRespons> LoginAsync(LoginDtos dtos)
    {
        var userExist = await _userManager.FindByEmailAsync(dtos.Email);

        if (userExist is null)
        {
            return new CommonRespons("Invalid email or password.", false);
        }

        var checkPassword = await _userManager.CheckPasswordAsync(userExist, dtos.Password);

        if (!checkPassword)
        {
            return new CommonRespons("Invalid email or password.", false);
        }

        // craete token
        var token= await TokenHandlers.CreateTokenAsync(userExist, _configuration, _userManager);
        
        return new CommonRespons("Login successfully.", true, token);
    }

    public async Task<CommonRespons> RegisterAsync(RegisterDtos dtos)
    {

        var userExist = await _userManager.FindByEmailAsync(dtos.Email);
        if (userExist is not null)
        {

            return new CommonRespons("there is problems while registering.", false);
        }


        var newUser = new AppUser
        {
            Name = dtos.Fullname,
            Email = dtos.Email,
            UserName = dtos.Email
        };


        var result = await _userManager.CreateAsync(newUser, dtos.Password);
        if (!result.Succeeded)
        {   
            var errors = result.Errors.Select(e => e.Description).ToList();
            return new CommonRespons("There was a problem while registering.", false);
        }

    

        var addToRoleResult = await _userManager.AddToRoleAsync(newUser, "User");
        if (!addToRoleResult.Succeeded)
        {
            var errors = addToRoleResult.Errors.Select(e => e.Description).ToList();
            return new CommonRespons("Cant register you: ", false, errors);
        }

        return new CommonRespons("User registered successfully.", true);
    }

   
}