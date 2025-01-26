using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TelegramBot.Helpers;
using TelegramBot.Messages;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream file = new FileStream(@"F:\TelegramBot\TelegramBot\ApiKey.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var client = new TelegramBotClient(JsonConvert.DeserializeObject<Api>(reader.ReadToEnd()).Token.ToString());
                    client.StartReceiving(HandlerUpDateAsync, HandlerErrorAsync);
                }
            }

            Console.ReadKey();
        }

        private async static Task HandlerUpDateAsync(ITelegramBotClient client, Update update, CancellationToken cancellation)
        {
            Message message = update.Message;
            long chatId = message.Chat.Id;

            if (Validator.IsNotNull(message.Text))
            {
                if (Validator.IsTextLower(message.Text, "/start"))
                {
                    StartMessage startMessage = new StartMessage(client, chatId);
                    await startMessage.HandlerMessageAsync();
                }
            }
        }


        private static Task HandlerErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource handle, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
