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
           MessageAbstract startMessage = new StartMessage(client, update);

            if (update.Message != null) 
            {
                Message message = update.Message;

                if (Validator.IsNotNull(message.Text))
                {
                    if (Validator.IsTextLower(message.Text, "/start"))
                    {
                        await startMessage.HandlerMessageAsync();
                    }
                }
            }

            if (update.CallbackQuery != null)
            {
                switch (update.CallbackQuery.Data)
                {
                    case "btn_0":
                        
                        break;
                    case "btn_1":
                        
                        break;
                    case "btn_2":
                        
                        break;
                    case "btn_3":
                        
                        break;
                }
            }
        }


        private static async Task HandlerErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource handle, CancellationToken cancellation)
        {
            Console.WriteLine(exception.Message);
            await Task.CompletedTask;
        }
    }
}
