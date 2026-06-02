using e_commerce.BLL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace e_commerce.BLL.Services.RoleService;

public class RoleService : IRoleService
{
   private readonly RoleManager<IdentityRole> _roleManager;
   public RoleService(RoleManager<IdentityRole> roleManager)
   {
       _roleManager = roleManager;
   }


   public  async Task<CommonRespons> AddAsync(string roleName)
   {
      var roleEixt=await _roleManager.FindByNameAsync(roleName);
      if (roleEixt is not null)
      {
          return new CommonRespons("Role already exist.", false);
      } 
      var addRoleResult=await _roleManager.CreateAsync(new IdentityRole(roleName));
      if (addRoleResult.Succeeded)
      {
          var errors=addRoleResult.Errors.Select(e=>e.Description).ToList();
          return new CommonRespons("can't create role currently .", false, null!, errors);    
      }
      return new CommonRespons("Role created successfully.", true);
   }

   public async  Task<CommonRespons> RemoveAsync(string roleName)
   {
       var roleEixt=await _roleManager.FindByNameAsync(roleName);
       if (roleEixt is not null)
       {
           return new CommonRespons("Role is not found.", false);
       } 
       
       var removeRoleResult=await _roleManager.DeleteAsync(roleEixt);
       if (removeRoleResult.Succeeded)
       {
           return new CommonRespons("Role can't be removed currently.", false);
       }
      
       return new CommonRespons("Role removed successfully.", true);
   }

   public async Task<IEnumerable<string>> GetAllRolesAsync()
   {
       return await _roleManager.Roles.Select(r => r.Name??"").ToListAsync();
       
   }
}