using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Messages;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunBot();

            Console.ReadKey();
        }

        private void RunBot()
        {
            using (FileStream file = new FileStream(@"F:\TelegramBot\TelegramBot\ApiKey.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var client = new TelegramBotClient(JsonConvert.DeserializeObject<Api>(reader.ReadToEnd()).Token.ToString());
                    client.StartReceiving(HandlerUpDateAsync, HandlerErrorAsync);
                }
            }
        }



        private async Task HandlerUpDateAsync(ITelegramBotClient client, Update update, CancellationToken cancellation)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                switch (update.Message.Text.ToLower())
                {
                    case "/start":
                        StartMessage startMessage = new StartMessage(client, update);
                        await startMessage.SendMessageAsync();
                        break;
                    case "продовжити працювати над дипломом — ти вирішуєш не ризикувати та сконцентруватися на захисті.":
                        DontRisk dontRisk = new DontRisk(client, update);
                        await dontRisk.SendMessageAsync();
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
