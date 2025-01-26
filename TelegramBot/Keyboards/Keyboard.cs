using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Keyboards
{
    internal static class Keyboard
    {
        public static IReplyMarkup CreateInlineKeyboard(string[] options)
        {
            var keyboard = new InlineKeyboardButton[options.Length][];
            for (int i = 0; i < options.Length; i++)
            {
                keyboard[i] = new[] { InlineKeyboardButton.WithCallbackData(options[i], options[i]) };
            }

            return new InlineKeyboardMarkup(keyboard);
        }
    }
}
