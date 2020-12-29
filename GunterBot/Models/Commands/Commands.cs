using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GunterBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        //public abstract Task Execute(Message message, TelegramBotClient client);

        public abstract Task Execute(Update update, TelegramBotClient client);

        //public abstract void Execute(Message message, TelegramBotClient client);

        //public abstract bool Contains(Message message);

        //public virtual bool Contains(Message message)
        //{
        //    return message.Type == Telegram.Bot.Types.Enums.MessageType.Text && message.Text.Contains(Name);
        //}

        //public virtual bool Contains(Update update)
        //{
        //    return update.CallbackQuery.Data.Contains(Name) || update.Message.Text.Contains(Name);
        //}

        // public abstract bool Contains(string update);

        public virtual bool Contains(string commandName)
        {
            return commandName.Contains(Name);
        }
    }
}