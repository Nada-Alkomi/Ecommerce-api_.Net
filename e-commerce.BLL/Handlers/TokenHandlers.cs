using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using e_commerce.DAL.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace e_commerce.BLL.Handlers;

public class TokenHandlers
{
    public static async Task<string> CreateTokenAsync(
        AppUser user,
        IConfiguration configuration,
        UserManager<AppUser> userManager)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Name, user.Name)
        };
        
        var userRoles = await userManager.GetRolesAsync(user);

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        
        var KeyInBytes = Encoding.UTF8.GetBytes(configuration["JWT:Key"]!);
         var Key= new SymmetricSecurityKey(KeyInBytes);
        
         var _issuer = configuration["JWT:Issuer"]!;
         var _audience=configuration["JWT:Aduins"]!;
         var _exiperTime=configuration["JWT:DurationInMinutes"]!;
         var _cred= new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
         
         var Token=new JwtSecurityToken(
             issuer: _issuer,
             audience: _audience,
             claims: claims,
             expires: DateTime.Now.AddMinutes(double.Parse(_exiperTime)),
             signingCredentials: _cred
         );
             
         return new JwtSecurityTokenHandler().WriteToken(Token);
         
         

    }
}