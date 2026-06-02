using e_commerce.BLL.DTOs;


namespace e_commerce.BLL.Services.RoleService;

public interface IRoleService
{
    Task<CommonRespons> AddAsync(string roleName);

    Task<CommonRespons> RemoveAsync(string roleName);

    Task<IEnumerable<string>> GetAllRolesAsync();
}