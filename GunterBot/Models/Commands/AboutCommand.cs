using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public class AboutCommand : Command
    {
        public override string Name => @"IoMoonStore";
        public override async Task Execute(Update update, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "✨АРОМА КОМПОЗИЦИИ НА ОСНОВЕ ЭФИРНЫХ МАСЕЛ✨ ▫️ритуальные бленды для медитаций▫️терапевтические миксы  ▫️100 % натуральные компоненты   ▫️vegan продукт", 
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: KeyboardHandler.GetCommonReplyKeyBoard());
        }
    }
}