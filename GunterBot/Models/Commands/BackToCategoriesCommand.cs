using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public class BackToCategoriesCommand : Command
    {
        public override string Name => "back";
        public override Task Execute(Update update, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
