using System.Threading.Tasks;
using GunterBot.Handlers;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace GunterBot.Controllers
{
    [Route("api")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        [HttpPost("update")]
        public async Task<IActionResult> MakeUpdate(Update update)
        {
            await UpdateHandler.Handle(update);
            return Ok();
        }
    }
}