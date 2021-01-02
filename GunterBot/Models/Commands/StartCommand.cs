using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override async Task Execute(Update update, TelegramBotClient client)
        {


            await client.SendTextMessageAsync(update.Message.Chat.Id, 
                "Доброго времени суток! Я помогу Вам с выбором Вашего идеального аромата😊 Что Вас интересует?", 
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: KeyboardHandler.GetCommonReplyKeyBoard());
        }
    }
}