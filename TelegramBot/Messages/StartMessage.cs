using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Keyboards;
using TelegramBot.Services;

namespace TelegramBot.Messages
{
    internal class StartMessage : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly Update _update;
        private readonly BotMessageHandler _botMessageHandler;

        public StartMessage(ITelegramBotClient client, Update update, BotMessageHandler botMessageHandler) : base(client, update, botMessageHandler)
        {
            _client = client;
            _update = update;
            _botMessageHandler = botMessageHandler;
        }

        public override string MessageTextBot =>
            "Ти — студент четвертого курсу ІТ-спеціальності. До захисту диплома залишилося всього кілька місяців. " +
            "Всі твої одногрупники вже давно поринули в написання роботи, але сьогодні твій спокій порушило несподіване повідомлення. " +
            "На екрані ноутбука світиться лист: Запрошуємо вас на співбесіду до нашої компанії. Але перш ніж ми зможемо вас прийняти, " +
            "необхідно пройти випробування: створити невеликий проєкт за визначений термін. Деталі в додатку. Ти перечитуєш повідомлення ще раз. " +
            "Це шанс! Велика компанія, можливість одразу після випуску отримати престижну роботу. Але ж диплом ніхто не скасовував...";

        public override string[] Buttons => new string[]
        {
            "Продовжити працювати над дипломом — ти вирішуєш не ризикувати та сконцентруватися на захисті.",
            "Прийняти виклик і взятися за проєкт — диплом можна якось підтягнути потім, а такий шанс випадає не щодня."
        };

        public override long ChatId => _update.Message.Chat.Id;

        public override async Task SendMessageAsync(string messageText)
        {
            switch (messageText)
            {
                case "/start":
                    await _client.SendTextMessageAsync(ChatId, MessageTextBot, replyMarkup: Keyboard.CreateReplyKeyboard(Buttons));
                    break;

                case var text when text == Buttons[0]:
                    DontRisk dontRisk = new DontRisk(_client, _update, _botMessageHandler);
                    _botMessageHandler.OnMessage -= SendMessageAsync;
                    _botMessageHandler.OnMessage += dontRisk.SendMessageAsync;

                    await dontRisk.SendMessageAsync(messageText);
                    break;

                case var text when text == Buttons[1]:
                    AcceptChallenge acceptChallenge = new AcceptChallenge(_client, _update, _botMessageHandler);
                    _botMessageHandler.OnMessage -= SendMessageAsync;
                    _botMessageHandler.OnMessage += acceptChallenge.SendMessageAsync;

                    await acceptChallenge.SendMessageAsync(messageText);
                    break;
            }

        }
    }
}
