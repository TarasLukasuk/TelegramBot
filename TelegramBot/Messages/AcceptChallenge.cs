using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Keyboards;
using TelegramBot.Services;

namespace TelegramBot.Messages
{
    class AcceptChallenge : MessageAbstract
    {
        private readonly ITelegramBotClient _client;
        private readonly Update _update;
        private readonly BotMessageHandler _botMessageHandler;

        public AcceptChallenge(ITelegramBotClient client, Update update, BotMessageHandler botMessageHandler) : base(client, update, botMessageHandler)
        {
            _client = client;
            _update = update;
            _botMessageHandler = botMessageHandler;
        }

        public override string MessageTextBot =>
            "Ти вирішуєш прийняти виклик і берешся за проєкт. Відкривши вкладення, ти бачиш технічне завдання: розробити веб-застосунок із застосуванням сучасних технологій. Часу не так багато, але виклик захоплює." +
            "Перший тиждень проходить у виборі стеку технологій та плануванні архітектури.Ти розумієш, що доведеться жонглювати між дипломом і новим проєктом. Вибравши React та Node.js, ти створюєш перший прототип." +
            "На другий тиждень виникають труднощі: непередбачувані баги, проблеми з інтеграцією бази даних.Дипломний керівник починає запитувати, чому ти здаєш розділи із затримкою. Але ти вперто рухаєшся вперед." +
            "За кілька днів до дедлайну ти майже не спиш.Здається, що проєкт не встигне бути готовим. Проте, доклавши максимум зусиль, ти відправляєш його в останній момент." +
            "Через день приходить відповідь від компанії: твій проєкт оцінили! Тебе запрошують на фінальну співбесіду.Радість змішується з втомою, але тепер у тебе є шанс отримати роботу." +
            "Тим часом дипломна робота залишається майже недописаною.Ти розумієш, що часу мало.Перед тобою новий вибір:";

        public override string[] Buttons => new string[]
        {
            "Відкласти підготовку до співбесіди й терміново доробляти диплом.",
            "Сконцентруватися на співбесіді й спробувати отримати роботу, ризикуючи дипломом."
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
