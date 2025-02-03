using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Keyboards;
using TelegramBot.Services;

namespace TelegramBot.Messages
{
    internal class DontRisk : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly Update _update;
        private readonly BotMessageHandler _botMessageHandler;

        public DontRisk(ITelegramBotClient client, Update update, BotMessageHandler botMessageHandler) : base(client, update, botMessageHandler)
        {
            _client = client;
            _update = update;
            _botMessageHandler = botMessageHandler;
        }

        public override string MessageTextBot => 
            "Ти вирішуєш не ризикувати та повністю зосереджуєшся на дипломній роботі. Дні минають у безперервних дослідженнях, написанні коду та правках тексту." +
            "Одного вечора ти заходиш на форум студентів і бачиш обговорення тієї самої співбесіди.Виявляється, кілька твоїх знайомих теж отримали запрошення.Один із них — твій приятель Сергій — вже виклав свої перші напрацювання.Його проєкт викликав зацікавлення у компанії, і він запрошений на наступний етап." +
            "Ти замислюєшся: можливо, варто було спробувати? Але зараз вже пізно." +
            "Наступні тижні ти повністю занурюєшся в диплом.Захист проходить успішно, ти отримуєш високий бал і навіть рекомендацію від наукового керівника. Проте після випуску виявляється, що знайти роботу не так просто. Конкуренція велика, а без практичного досвіду твоє резюме не дуже вражає роботодавців.";

        public override string[] Buttons => new string[]
        {
            "Почати стажування в невеликій компанії, щоб здобути необхідний досвід і поступово розвивати кар'єру.",
            "Звернутися до компанії, яка пропонувала випробування, і дізнатися, чи є ще можливість співпраці.",
            "Піти на фріланс і почати виконувати дрібні проєкти, щоб зібрати портфоліо."
        };

        public override long ChatId => _update.Message.Chat.Id;

        public override async Task SendMessageAsync(string messageText)
        {
            switch (messageText)
            {
                default:
                    await _client.SendTextMessageAsync(ChatId, MessageTextBot, replyMarkup: Keyboard.CreateReplyKeyboard(Buttons));
                    break;
            }
        }
    }
}
