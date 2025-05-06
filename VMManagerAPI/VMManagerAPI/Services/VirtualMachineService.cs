using VMManagerAPI.Models;
using VMManagerAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using VMManagerAPI.Data;
using VMManagerAPI.Models.Dto;
using AutoMapper;

namespace VMManagerAPI.Services
{
    public class VirtualMachineService : IVirtualMachineService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VirtualMachineService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VirtualMachineDto>> GetAllAsync()
        {
            var vms = await _context.VirtualMachines.ToListAsync();
            return _mapper.Map<List<VirtualMachineDto>>(vms);
        }

        public async Task<VirtualMachineDto?> GetByIdAsync(int id)
        {
            var vm = await _context.VirtualMachines.FindAsync(id);
            return vm == null ? null : _mapper.Map<VirtualMachineDto>(vm);
        }

        public async Task<VirtualMachineDto> CreateAsync(CreateVirtualMachineDto dto)
        {
            var vm = _mapper.Map<VirtualMachine>(dto);

            vm.CreatedAt = DateTime.UtcNow;
            vm.UpdatedAt = DateTime.UtcNow;
            _context.VirtualMachines.Add(vm);
            await _context.SaveChangesAsync();
            return _mapper.Map<VirtualMachineDto>(vm);

        }

        public async Task<VirtualMachineDto?> UpdateAsync(int id, UpdateVirtualMachineDto dto)
        {
            var vm = await _context.VirtualMachines.FindAsync(id);
            if (vm == null) return null;

            _mapper.Map(dto, vm);
            vm.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return _mapper.Map<VirtualMachineDto>(vm);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vm = await _context.VirtualMachines.FindAsync(id);
            if (vm == null) return false;

            _context.VirtualMachines.Remove(vm);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
