using System.Threading.Tasks;

namespace TelegramBot.Messages
{
    internal abstract class MessageAbstract
    {
        internal abstract string MessageText { get; }
        internal abstract string[] Butthons { get; }

        internal abstract Task HandlerMessageAsync();
    }
}
