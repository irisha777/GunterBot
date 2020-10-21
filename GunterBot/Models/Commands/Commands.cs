using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShitBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, TelegramBotClient client);

        //public abstract void Execute(Message message, TelegramBotClient client);

        //public abstract bool Contains(Message message);

        public virtual bool Contains(Message message)
        {
            return message.Type == Telegram.Bot.Types.Enums.MessageType.Text && message.Text.Contains(Name);
        }
    }
}