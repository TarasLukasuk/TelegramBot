using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Keyboards
{
    internal static class Keyboard
    {
        public static IReplyMarkup CreateReplyKeyboard(string[] options)
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
    }
}
