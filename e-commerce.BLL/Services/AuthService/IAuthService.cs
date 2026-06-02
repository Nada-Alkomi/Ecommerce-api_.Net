using e_commerce.BLL.DTOs;
using e_commerce.BLL.DTOs.User;
namespace e_commerce.BLL.Services;

public interface IAuthService
{
 
    Task<CommonRespons> RegisterAsync(RegisterDtos dtos);

    Task<CommonRespons> LoginAsync(LoginDtos dtos);
}