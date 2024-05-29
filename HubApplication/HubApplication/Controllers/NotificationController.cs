using HubApplication.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HubApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string SendNotification(string message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            //                                       ^^^^^^^^^^^^^^^^^^^^ -> Angulardagi [this.hubConnection.on] ichidagi method bilan
            //                                                                  birxil bo'lishi lozim
            return "Sent!";
        }
    }
}
