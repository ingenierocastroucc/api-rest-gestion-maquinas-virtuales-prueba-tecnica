using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VMManagerAPI.Models.Dto;
using VMManagerAPI.Services;

namespace VMManagerAPI.Controllers
{
    public class SignalRealTimeController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRealTimeController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("notify")]
        public async Task<IActionResult> NotifyVmChange([FromBody] VirtualMachineDto vmChange)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", vmChange);
            return Ok();
        }
    }
}
