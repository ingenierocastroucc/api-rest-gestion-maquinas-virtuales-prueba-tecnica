using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Services
{
    public interface IAuthService
    {
        string Authenticate(UserDto userDto);
    }
}