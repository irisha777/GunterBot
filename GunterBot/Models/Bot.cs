using System.Collections.Generic;
using System.Threading.Tasks;
using GunterBot.Models.Commands;
using Telegram.Bot;

namespace ShitBot.Models
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _commandsList;

        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _commandsList = new List<Command>
            {
                new StartCommand(),
                new GetRateCommand()
            };

            _botClient = new TelegramBotClient(AppSettings.Key);
            var hook = string.Concat(AppSettings.Url, "/api/update");
            await _botClient.SetWebhookAsync(hook);
            return _botClient;
        }
    }
}