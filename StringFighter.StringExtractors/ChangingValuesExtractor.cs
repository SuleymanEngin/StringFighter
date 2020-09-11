using StringFighter.StringExtractors.Exceptions;
using StringFighter.StringExtractors.Extensions;
using System;
using System.Collections.Generic;

namespace StringFighter.StringExtractors
{
    public class ChangingValuesExtractor
    {
        string[] _staticValues;

        public ChangingValuesExtractor(ref string template)
        {
            if (string.IsNullOrWhiteSpace(template))
                throw new ArgumentNullException("template cannot be null or empty!");

            if (template.AllIndexesOf("{}").Count <= 1)
                throw new FormatException("template must contain more than one variable");

            _staticValues = template.Split("{}", StringSplitOptions.RemoveEmptyEntries);
        }

        public List<string> ExtractChangingValues(ref string value)
        {
            int startIndex = 0;

            var changingValues = new List<string>();

            foreach (var staticValue in _staticValues)
            {
                var staticValueIndex = value.IndexOf(staticValue, startIndex);

                if (staticValueIndex == -1)
                    throw new ValueNotValidForTemplateException("value not valid for template!");

                var changingValue = value[startIndex..staticValueIndex];

                changingValues.Add(changingValue);

                startIndex = staticValueIndex + staticValue.Length;
            }

            if (startIndex < value.Length)
            {
                changingValues.Add(value[startIndex..value.Length]);
            }

            return changingValues;
        }
    }
}
