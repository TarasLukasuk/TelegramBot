using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Keyboards;

namespace TelegramBot.Messages
{
    class StartMessage : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly Update _update;

        internal override string MessageText => "Ти студент університету на інформаційних технологіях. До захисту диплому залишилося дві тижні. Твій проєкт поки не готовий, але ти вже маєш чіткий план його завершити. Проте сьогодні вранці тобі прийшло неочікуване запрошення на співбесіду від відомої IT-компанії.";
        internal override string[] Butthons => new[] { "Почати пошук інформації для проекту.", "Звернутися до друзів з університету за допомогою.", "Зосередитися тільки на написанні коду.", "Знайти наукового керівника для додаткових порад." };

        public StartMessage(ITelegramBotClient telegramBotClient, Update update)
        {
            if (telegramBotClient is null)
            {
                throw new ArgumentNullException(nameof(telegramBotClient));
            }

            if (update is null)
            {
                throw new ArgumentNullException(nameof(update));
            }

            _client = telegramBotClient;
            _update = update;
        }


        [Obsolete]
        internal override async Task HandlerMessageAsync()
        {
            if (_update.Message != null)
            {
                await _client.SendTextMessageAsync(_update.Message.Chat.Id, MessageText, replyMarkup: Keyboard.CreateInlineKeyboard(Butthons));
            }
        }
    }
}
