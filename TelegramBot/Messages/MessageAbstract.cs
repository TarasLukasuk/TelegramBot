using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot.Messages
{
    internal abstract class MessageAbstract
    {
        internal abstract string MessageText { get; }
        internal abstract string[] Butthons { get; }

        internal abstract Task HandlerMessageAsync();
    }
}
