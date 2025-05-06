using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VMManagerAPI.Services;
using VMManagerAPI.DTOs;
using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualMachineController : ControllerBase
    {
        private readonly IVirtualMachineService _vmService;

        public VirtualMachineController(IVirtualMachineService vmService)
        {
            _vmService = vmService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,Cliente")]
        public async Task<IActionResult> GetAllVms()
        {
            var vms = await _vmService.GetAllAsync();
            return Ok(vms);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator,Cliente")]
        public async Task<IActionResult> GetVmById(int id)
        {
            var vm = await _vmService.GetByIdAsync(id);
            if (vm == null) return NotFound();
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateVm([FromBody] CreateVirtualMachineDto model)
        {
            var vm = await _vmService.CreateAsync(model);
            return CreatedAtAction(nameof(GetVmById), new { id = vm.Id }, vm);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateVm(int id, [FromBody] UpdateVirtualMachineDto model)
        {
            var updatedVm = await _vmService.UpdateAsync(id, model);
            if (updatedVm == null) return NotFound();
            return Ok(updatedVm);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteVm(int id)
        {
            var result = await _vmService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}