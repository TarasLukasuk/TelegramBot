using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Messages
{
    internal abstract class MessageAbstract
    {
        public MessageAbstract(ITelegramBotClient client, Update update)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (update is null)
            {
                throw new ArgumentNullException(nameof(update));
            }
        }

        public abstract string MessageText { get; }
        public abstract string[] Buttons { get; }

        public abstract Task SendMessageAsync();
    }
}
