using System.Threading.Tasks;
using GunterBot.Db;
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
                await DbHelper.GetActualProductCategoryDictionaryAsync(salesDbContext);

            var inlineButtonArr =
                Keyboard.GetOneColumnInlineKeyboardWithCallbackData(activeProductCategoryNameDict,
                    EntityTypeEnum.ProductCategory);

            await client.SendTextMessageAsync(update.Message.Chat.Id,
                "🌈 Пожалуйста, выберите интересующую Вас категорию 🌈",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: new InlineKeyboardMarkup(inlineButtonArr));
        }
    }
}