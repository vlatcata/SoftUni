using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Validator
    {
        public static void ThrowStringIsNullOrEmpty(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfNumerIsNegative(decimal number, string message)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
