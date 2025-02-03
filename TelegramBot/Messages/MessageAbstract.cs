using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Services;

namespace TelegramBot.Messages
{
    internal abstract class MessageAbstract
    {
        public MessageAbstract(ITelegramBotClient client, Update update, BotMessageHandler botMessageHandler)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (update is null)
            {
                throw new ArgumentNullException(nameof(update));
            }

            if (botMessageHandler is null)
            {
                throw new ArgumentNullException(nameof(botMessageHandler));
            }
        }

        public abstract string MessageTextBot { get; }
        public abstract string[] Buttons { get; }
        public abstract long ChatId { get; }

        public abstract Task SendMessageAsync(string messageText);
    }
}
