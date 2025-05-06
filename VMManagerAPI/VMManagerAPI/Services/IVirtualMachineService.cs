using VMManagerAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Services
{
    public interface IVirtualMachineService
    {
        Task<List<VirtualMachineDto>> GetAllAsync();
        Task<VirtualMachineDto?> GetByIdAsync(int id);
        Task<VirtualMachineDto> CreateAsync(CreateVirtualMachineDto dto);
        Task<VirtualMachineDto?> UpdateAsync(int id, UpdateVirtualMachineDto dto);
        Task<bool> DeleteAsync(int id);
    }
}