using e_commerce.BLL.DTOs;
using e_commerce.BLL.DTOs.Roles;
using e_commerce.BLL.Services.RoleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace E_commerce.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RoleController:ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [HttpPost]
    public  async Task<IActionResult<CommonRespons>> create(AddRoleDtos dtos)
    {
       var respons= await _roleService.AddAsync(dtos.RoleName);
       if (!respons.IsSuccess)
       {
           return BadRequest(respons);
       }
       return Ok(respons);
    }
}