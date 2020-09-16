using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFighter.StringExtractors
{
    public class KeyValueExtractor
    {
        List<Node> _brackets = new List<Node>
        {
            new Node
            {
                Left = '{',
                Right = '}'
            },
            new Node
            {
                Left = '[',
                Right = ']'
            },
            new Node
            {
                Left = '(',
                Right = ')'
            }
        };

        /// <summary>
        /// extracts the value based on the key given from the string
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="key">target value's key.</param>
        /// <exception cref="System.ArgumentNullException"
        /// <exception cref="System.ArgumentOutOfRangeException"
        public string ExtractValueByKeyFromString(ref string source, string key)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (key is null)
                throw new ArgumentNullException(nameof(key));

            var keyStartIndex = source.IndexOf(key);

            if (keyStartIndex <= 0)
                throw new KeyNotFoundException(key);

            var valueStartIndex = keyStartIndex + key.Length;

            Node bracketNode;

            while (valueStartIndex < source.Length)
            {
                var currentChar = source[valueStartIndex];

                if (char.IsNumber(currentChar))
                    return ExtractNumericValue(ref source, ref valueStartIndex);

                if (currentChar == '"')
                    return ExtractStringValue(ref source, ref valueStartIndex, '"');

                if (currentChar == '\'')
                    return ExtractStringValue(ref source, ref valueStartIndex, '\'');

                if ((bracketNode = _brackets.FirstOrDefault(c => c.Left == currentChar)) != null)
                    return ExtractWithBracketsValue(ref source, ref valueStartIndex, bracketNode);

                valueStartIndex++;
            }

            return null;
        }

        private string ExtractStringValue(ref string source, ref int index, char quote = '"')
        {
            var sb = new StringBuilder();

            index++;

            while (index < source.Length)
            {
                if (source[index] == quote) break;

                sb.Append(source[index]);

                index++;
            }

            return sb.ToString();
        }

        private static string ExtractNumericValue(ref string source, ref int index)
        {
            var sb = new StringBuilder();

            while (index < source.Length)
            {
                if (!char.IsNumber(source[index]))
                {
                    if (source[index] != ',' && source[index] != '.')
                        break;

                    var nextChar = source.ElementAtOrDefault(index + 1);

                    if (!char.IsNumber(nextChar))
                        break;
                }

                sb.Append(source[index]);

                index++;
            }

            return sb.ToString();
        }

        private string ExtractWithBracketsValue(ref string source, ref int index, Node bracketNode)
        {
            var sb = new StringBuilder();

            sb.Append(source[index]);

            index++;

            int left = 1;

            int right = 0;

            while (index < source.Length)
            {
                if (left == right)
                    break;

                if (source[index] == bracketNode.Left)
                    left++;

                if (source[index] == bracketNode.Right)
                    right++;

                sb.Append(source[index]);

                index++;
            }

            return sb.ToString();
        }
    }
}
