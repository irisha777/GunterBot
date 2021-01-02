using System;
using System.Collections.Generic;
using System.Linq;
using GunterBot.Models.Enum;
using SalesDb.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace GunterBot.Models
{
    public static class KeyboardHandler
    {
        public static IReplyMarkup GetCommonReplyKeyBoard()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>{
                    new List<KeyboardButton>{
                        new KeyboardButton { Text = "IoMoonStore" },
                        new KeyboardButton { Text = "Каталог" }
                    },
                     new List<KeyboardButton>{
                         new KeyboardButton { Text = "Обратная связь" },
                         new KeyboardButton { Text = "Статус заказа" }
                     }
                }
            };
        }

        public static InlineKeyboardButton[][] GetTwoColumnInlineCatalogWithCallbackData(List<string> stringList)
        {
            var stringArray = stringList.ToArray();

            if (stringArray.Length < 1)
                throw new Exception("Too few buttons");

            const int columnCount = 2;
            var linesCount = stringArray.Length / columnCount;

            if (stringArray.Length % columnCount > 0)
                linesCount++;

            var keyboardInline = new InlineKeyboardButton[linesCount][];


            for (var i = 0; i < linesCount; i++)
            {
                var keyboardLine = new InlineKeyboardButton[stringArray.Length == 1 ? 1 : columnCount];

                for (var j = 0; j < columnCount; j++)
                {
                    keyboardLine[j] = stringArray[j];
                    if (stringArray.Length == 1) j++;
                }

                keyboardInline[i] = keyboardLine;

                Array.Clear(stringArray, 0, stringArray.Length == 1 ? 1 : columnCount);

                stringArray = stringArray
                    .Where(s => s != null)
                    .ToArray();
            }

            return keyboardInline;
        }

        public static InlineKeyboardButton[][] GetTwoColumnInlineCatalogWithCallbackData(Dictionary<int, string> dict, 
            EntityTypeEnum entityType)
        {

            if (dict.Count < 1)
                throw new Exception("Too few buttons");

            const int columnCount = 2;
            var linesCount = dict.Count / columnCount;

            if (dict.Count % columnCount > 0)
                linesCount++;

            var keyboardInline = new InlineKeyboardButton[linesCount][];

            for (var i = 0; i < linesCount; i++)
            {
                var keyboardLine = new InlineKeyboardButton[dict.Count == 1 ? 1 : columnCount];

                for (var j = 0; j < columnCount; j++)
                {
                    keyboardLine[j] = InlineKeyboardButton.WithCallbackData(dict.First().Value,
                        string.Concat(((int)entityType).ToString(), "_", dict.First().Key.ToString()));

                    if (dict.Count == 1) j++;
                    dict.Remove(dict.Keys.First());
                }

                keyboardInline[i] = keyboardLine;
            }

            return keyboardInline;
        }

        public static InlineKeyboardButton[][] GetTwoColumnInlineCatalogWithCallbackDataAndBackButton(Dictionary<int, string> dict, 
            EntityTypeEnum entityType)
        {
            var twoColumnKeyboard = GetTwoColumnInlineCatalogWithCallbackData(dict, entityType);

            Array.Resize(ref twoColumnKeyboard, twoColumnKeyboard.Length + 1);

            twoColumnKeyboard[^1]= new[] { InlineKeyboardButton.WithCallbackData("Назад", "back") };

            return twoColumnKeyboard;
        }

        public static InlineKeyboardButton[][] GetOneColumnInlineKeyboardWithCallbackData(
            Dictionary<int, string> dict, EntityTypeEnum entityType)
        {
            if (dict.Count < 1)
                throw new Exception("Too few buttons");

            var keyboardInline = new InlineKeyboardButton[dict.Count][];
            var i = 0;

            foreach (var (key, value) in dict)
            {
                keyboardInline[i] = new[] 
                    { 
                        InlineKeyboardButton.WithCallbackData(
                        value, string.Concat(((int)entityType).ToString(), "_", key.ToString()))
                    };

                i++;
            }

            return keyboardInline;
        }
    }
}