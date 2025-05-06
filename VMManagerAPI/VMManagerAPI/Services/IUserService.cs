using System.Collections.Generic;
using System.Threading.Tasks;
using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByEmailAsync(string email);
        Task<bool> ChangeRoleAsync(string email, string newRole);
    }
}