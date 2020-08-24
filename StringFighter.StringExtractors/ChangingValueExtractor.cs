using StringFighter.StringExtractors.Exceptions;
using System;
using System.Linq;

namespace StringFighter.StringExtractors
{
    public class ChangingValueExtractor
    {
        string changingValueBeforeValue;

        string changingValueAfterValue;

        public ChangingValueExtractor(string template)
        {
            if (string.IsNullOrWhiteSpace(template))
                throw new ArgumentException("I need a template dude!");

            var value = template.Split("{}");

            changingValueBeforeValue = value.ElementAtOrDefault(0) ?? "";

            changingValueAfterValue = value.ElementAtOrDefault(1) ?? "";
        }

        public string ExtractChangingValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("I need a value dude!");

            var valueIsValidForTemplate = CheckValueValidateForTemplate(value);

            if (!valueIsValidForTemplate)
                throw new ValueNotValidForTemplateException(nameof(value));

            var changingValueAfterValueStartIndex = value.Length - changingValueAfterValue.Length;

            var result = value[changingValueBeforeValue.Length..changingValueAfterValueStartIndex];

            return result;
        }

        private bool CheckValueValidateForTemplate(string value)
        {

            if (!(changingValueBeforeValue == value[0..changingValueBeforeValue.Length]))
                return false;

            var changingValueAfterValueStartIndex = value.Length - changingValueAfterValue.Length;

            if (!(changingValueAfterValue == value[changingValueAfterValueStartIndex..value.Length]))
                return false;

            return true;
        }
    }
}
