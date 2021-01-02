using System.Collections.Generic;
using System.Threading.Tasks;
using GunterBot.Models.Commands;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace GunterBot.Models
{
    public class BotHandler
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _commandsList;
        private static List<Command> _callbackCommandsList;

        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();
        public static IReadOnlyList<Command> CallbackCommands => _callbackCommandsList.AsReadOnly();
        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _commandsList = new List<Command>
            {
                new StartCommand(),
                new AboutCommand(),
                new CatalogCommand()
            };

            _callbackCommandsList = new List<Command>
            {
                new ProductListCommand(),
                new ProductDescriptionCommand()
            };

            _botClient = new TelegramBotClient(AppSettings.Key);
            var hook = string.Concat(AppSettings.Url, "/api/update");
            await _botClient.SetWebhookAsync(hook);

            return _botClient;
        }
    }
}