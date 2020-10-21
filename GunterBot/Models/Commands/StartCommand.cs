using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShitBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Hallo I'm ASP.NET Core Bot", 
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}