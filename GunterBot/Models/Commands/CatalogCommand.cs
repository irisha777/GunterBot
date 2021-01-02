using System.Threading.Tasks;
using GunterBot.Handlers;
using GunterBot.Models.Enum;
using SalesDb.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GunterBot.Models.Commands
{
    public class CatalogCommand : Command
    {
        public override string Name => @"Каталог";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var salesDbContext = new SalesDbContext();

            var activeProductCategoryNameDict = 
                await CatalogHandler.GetActualProductCategoryDictionaryAsync(salesDbContext);

            var inlineButtonArr =
                KeyboardHandler.GetOneColumnInlineKeyboardWithCallbackData(activeProductCategoryNameDict,
                    EntityTypeEnum.ProductCategory);

            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "🌈 Пожалуйста, выберите интересующую Вас категорию 🌈",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: new InlineKeyboardMarkup(inlineButtonArr));
        }
    }
}