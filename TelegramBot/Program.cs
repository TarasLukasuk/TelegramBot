using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        static ConcurrentDictionary<long, string> userStates = new ConcurrentDictionary<long, string>();

        static void Main(string[] args)
        {
            using (FileStream file = new FileStream(@"F:\TelegramBot\TelegramBot\ApiKey.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var client = new TelegramBotClient(JsonConvert.DeserializeObject<Api>(reader.ReadToEnd()).Token.ToString());
                    client.StartReceiving(UpDate, Error);
                }
            }

            Console.ReadKey();
        }

        private async static Task UpDate(ITelegramBotClient client, Update update, CancellationToken cancellation)
        {
            var message = update.Message;

            if (message.Text != null)
            {
                message.Text.ToLower();

                long chatId = message.Chat.Id;

                if (message.Text.ToLower() == "/start")
                {
                    userStates[chatId] = "start";
                    await client.SendTextMessageAsync(chatId,"Вітаю у текстовому квесті! Ви прокидаєтесь у темній кімнаті. Що робити далі?\n1. Увімкнути світло\n2. Шукати вихід\n3. Залишатися на місці");
                }
            }
        }

        static IReplyMarkup CreateReplyKeyboard(string[] options)
        {
            var keyboard = new KeyboardButton[options.Length][];
            for (int i = 0; i < options.Length; i++)
            {
                keyboard[i] = new[] { new KeyboardButton(options[i]) };
            }

            return new ReplyKeyboardMarkup(keyboard)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
        }

        private static Task Error(ITelegramBotClient client, Exception exception, HandleErrorSource handle, CancellationToken cancellation)
        {
            throw new NotImplementedException(); // Прийшов?ghhgfghg
        }
    }
}
