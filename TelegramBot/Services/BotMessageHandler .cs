using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Services
{
    public delegate Task MessageHandler(string messageText);

    class BotMessageHandler
    {
        public event MessageHandler OnMessage;

        public async Task SendMessageAsync(string messageText)
        {
           await OnMessage?.Invoke(messageText);
        }
    }
}
