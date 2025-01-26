using System;

namespace TelegramBot.Helpers
{
    internal static class Validator
    {
        internal static bool IsNotNull(string text)
        {
            if (text == null)
            {
                return false;
            }

            return true;
        }

        internal static bool IsTextLower(string text, string value)
        {
            if (text.ToLower() != value)
            {
                return false;
            }

            return true;
        }
    }
}
