using System.Threading.Tasks;
using GunterBot.Tools;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public class GetRateCommand : Command
    {
        public override string Name => @"/getrate";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            var rate = await RatesReceiver.GetRates();

            await botClient.SendTextMessageAsync(chatId, $"Rate: {rate}",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
