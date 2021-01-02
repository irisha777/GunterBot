using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public class OrderCommand : Command
    {
        public override string Name => "Заказать";
        public override Task Execute(Update update, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
