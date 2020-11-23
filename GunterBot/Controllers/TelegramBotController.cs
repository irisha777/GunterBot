using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using ShitBot.Models;

namespace GunterBot.Controllers
{
    [Route("api")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        [HttpPost("update")]
        public async Task<IActionResult> MakeUpdate(Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (!command.Contains(message)) continue;
                await command.Execute(message, botClient);
                break;
            }

            return Ok();
        }
    }
}
