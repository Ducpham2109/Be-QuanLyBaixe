using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DATN.Api.Controllers
{
    [Route("api/Chat")]
    [ApiController]
    public class MessageDto
    {
        public string user { get; set; }
        public string msgHeader { get; set; }
        public string msgText { get; set; }
    }
    public class MessageSend
    {
        public string PhoneNumberAddr { get; set; }
        public string Content { get; set; }
    }
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;


        public ChatController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [Route("/api/notification/admin/send")]
        [HttpPost]
        public IActionResult AdminSendNotificationRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("UserReceiveNotification", msg.msgText, msg.user, msg.msgHeader);
            return Ok();
        }
        [Route("/api/notification/user/send")]
        [HttpPost]
        public IActionResult UserSendNotificationRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("AdminReceiveNotification", msg.msgText, msg.user, msg.msgHeader);
            return Ok();
        }
    }

    }
