using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract Task Execute(Update update, TelegramBotClient client);
        public virtual bool Contains(string commandName)
        {
            return commandName.Contains(Name);
        }

        public virtual string GetItemtId(string data)
        {
            return data.Substring(data.IndexOf("_", StringComparison.Ordinal) + 1);
        }
    }
}