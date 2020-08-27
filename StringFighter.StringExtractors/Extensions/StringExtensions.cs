using System;
using System.Collections.Generic;
using System.Text;

namespace StringFighter.StringExtractors.Extensions
{
    public static class StringExtensions
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");

            var indexes = new List<int>();

            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);

                if (index == -1)
                    return indexes;

                indexes.Add(index);
            }
        }
    }
}
