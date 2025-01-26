using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Keyboards;

namespace TelegramBot.Messages
{
    class StartMessage : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly long _chatId;

        internal override string MessageText => "Ти студент університету на інформаційних технологіях. До захисту диплому залишилося дві тижні. Твій проєкт поки не готовий, але ти вже маєш чіткий план його завершити. Проте сьогодні вранці тобі прийшло неочікуване запрошення на співбесіду від відомої IT-компанії.";
        internal override string[] Butthons => new[] { "Почати пошук інформації для проекту.", "Звернутися до друзів з університету за допомогою.", "Зосередитися тільки на написанні коду.", "Знайти наукового керівника для додаткових порад." };

        public StartMessage(ITelegramBotClient telegramBotClient, long chatId)
        {
            if (telegramBotClient is null)
            {
                throw new ArgumentNullException(nameof(telegramBotClient));
            }

            _client = telegramBotClient;
            _chatId = chatId;
        }

        [Obsolete]
        internal override async Task HandlerMessageAsync()
        {
            await _client.SendTextMessageAsync(_chatId, MessageText, replyMarkup: Keyboard.CreateInlineKeyboard(Butthons));
        }
    }
}
