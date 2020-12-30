using System.Threading.Tasks;
using GunterBot.Db;
using GunterBot.Models.Enum;
using SalesDb.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GunterBot.Models.Commands
{
    public class ProductDescriptionCommand : Command
    {
        public override string Name => ((int) EntityTypeEnum.Product).ToString();
        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var salesDbContext = new SalesDbContext();

            var product =
                await DbHelper.GetProductByIdAsync(salesDbContext,
                    int.Parse(GetItemtId(update.CallbackQuery.Data)));

            var inlineButtonArr =
                Keyboard.GetInlineKeyboardWithProductDescriptionAndCallbackData(product);

            await client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                $"{product.Name}  {product.Descrition} {product.Cost}",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: new InlineKeyboardMarkup(inlineButtonArr));
        }
    }
}
