using System;
using System.Collections.Generic;
using System.Text;

namespace InteractorLayer
{
    public static class Hashing
    {
        public static string HashText(string text)
        {
            text = BCrypt.Net.BCrypt.HashPassword(text);
            return text;
        }

        public static bool ValidateText(string text , string hashedText)
        {
            return BCrypt.Net.BCrypt.Verify(text, hashedText);
        }
    }
}
