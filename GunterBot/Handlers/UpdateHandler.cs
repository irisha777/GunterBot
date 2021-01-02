using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using GunterBot.Models;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GunterBot.Handlers
{
    public static class UpdateHandler
    {
        public static async Task Handle(Update update)
        {
            var commands = BotHandler.Commands;
            var callbackCommands = BotHandler.CallbackCommands;
            var botClient = await BotHandler.GetBotClientAsync();

            switch (update.Type)
            {
                case UpdateType.Message:
                    foreach (var command in commands)
                    {
                        if (!command.Contains(update.Message.Text)) continue;
                        await command.Execute(update, botClient);
                        break;
                    };
                    break;
                case UpdateType.CallbackQuery:
                    foreach (var callbackCommand in callbackCommands)
                    {
                        if (!callbackCommand.Contains(GetEntityType(update.CallbackQuery.Data))) continue;
                        await callbackCommand.Execute(update, botClient);
                        break;
                    };
                    break;
                default:
                    throw new Exception("This Update.Type is not supported");
            }
        }
        
        private static string GetEntityType(string data)
        {
            return data.Substring(0, data.IndexOf("_", StringComparison.Ordinal));
        }
    }
}
