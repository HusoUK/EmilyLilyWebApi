using EmilyLilyApi.Models;
using EmilyLilyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmilyLilyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        private readonly IMessenger _messenger;

        public MessengerController(IMessenger emailer)
        {
            _messenger = emailer;
        }

        [HttpPost]
        public IActionResult Post(EmailMessage msg)
        {
            _messenger.SendMessage(msg);
            return Ok();
        }
    }
}
