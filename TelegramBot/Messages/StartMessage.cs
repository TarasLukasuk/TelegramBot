using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Keyboards;

namespace TelegramBot.Messages
{
    internal class StartMessage : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly Update _update;

        public StartMessage(ITelegramBotClient client, Update update) : base(client, update)
        {
            _client = client;
            _update = update;
        }

        public override string MessageText =>
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

        public override async Task SendMessageAsync()
        {
            await _client.SendTextMessageAsync(_update.Message.Chat.Id, MessageText, replyMarkup: Keyboard.CreateReplyKeyboard(Buttons));
        }
    }
}
