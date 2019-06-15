using System;
using System.Collections.Generic;
using System.Text;

namespace customerdata.lib.Extensions
{
    public static class StringExtension
    {
        private const string quote = "\"";
        public static string RemoveSpecialCharacters(this string input)
        {
            return input.Replace(quote, string.Empty);
        }
    }
}
