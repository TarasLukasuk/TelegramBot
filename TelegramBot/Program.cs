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
using TelegramBot.Services;

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
            using (FileStream file = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "ApiKey.json").Replace(@"\bin\Debug", string.Empty), FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var client = new TelegramBotClient(JsonConvert.DeserializeObject<Api>(reader.ReadToEnd()).Token.ToString());
                    client.StartReceiving(HandlerUpDateAsync, HandlerErrorAsync);
                }
            }
        }

        private BotMessageHandler botMessageHandler;

        private async Task HandlerUpDateAsync(ITelegramBotClient client, Update update, CancellationToken cancellation)
        {
            if (update.Type == UpdateType.Message && update.Message != null)
            {
                if (botMessageHandler == null)
                {
                    botMessageHandler = new BotMessageHandler();
                    StartMessage startMessage = new StartMessage(client, update, botMessageHandler);

                    botMessageHandler.OnMessage += startMessage.SendMessageAsync;
                }

                await botMessageHandler.SendMessageAsync(update.Message.Text);
            }
        }



        private static async Task HandlerErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource handle, CancellationToken cancellation)
        {
            Console.WriteLine(exception.Message);
            await Task.CompletedTask;
        }
    }
}
