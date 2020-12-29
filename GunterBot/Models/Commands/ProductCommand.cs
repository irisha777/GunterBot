﻿using System;
using System.Threading.Tasks;
using GunterBot.Db;
using GunterBot.Models.Enum;
using SalesDb.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace GunterBot.Models.Commands
{
    public class ProductCommand : Command
    {
        public override string Name => ((int)EntityTypeEnum.ProductCategory).ToString();

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var salesDbContext = new SalesDbContext();

            var actualProductNameDict =
                await DbHelper.GetActualProductNameDictionaryByCategoryIdAsync(salesDbContext, 
                    int.Parse(GetProductId(update.CallbackQuery.Data)));

            //var inlineButtonArr =
            //    Keyboard.GetTwoColumnInlineCatalogWithCallbackData(actualProductNameDict,
            //        EntityTypeEnum.Product);

            var inlineButtonArr =
                Keyboard.GetTwoColumnInlineCatalogWithCallbackDataAndBackButton(actualProductNameDict,
                    EntityTypeEnum.Product);

            await client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id,
                "🌈 Пожалуйста, выберите интересующую Вас категорию 🌈",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: new InlineKeyboardMarkup(inlineButtonArr));
        }

        private static string GetProductId(string data)
        {
            return data.Substring(data.IndexOf("_", StringComparison.Ordinal) + 1);
        }
    }
}
