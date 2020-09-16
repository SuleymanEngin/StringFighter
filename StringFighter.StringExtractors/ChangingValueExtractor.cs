using StringFighter.StringExtractors.Exceptions;
using System;
using System.Linq;

namespace StringFighter.StringExtractors
{
    public class ChangingValueExtractor
    {
        private readonly string _changingValueBeforeValue;

        private readonly string _changingValueAfterValue;

        public ChangingValueExtractor(string template)
        {
            if (string.IsNullOrWhiteSpace(template))
                throw new ArgumentException("I need a template dude!");

            var value = template.Split("{}");

            _changingValueBeforeValue = value.ElementAtOrDefault(0) ?? "";

            _changingValueAfterValue = value.ElementAtOrDefault(1) ?? "";
        }

        public string ExtractChangingValue(ref string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("I need a value dude!");

            var valueIsValidForTemplate = CheckValueValidateForTemplate(ref value);

            if (!valueIsValidForTemplate)
                throw new ValueNotValidForTemplateException(nameof(value));

            var changingValueAfterValueStartIndex = value.Length - _changingValueAfterValue.Length;

            var result = value[_changingValueBeforeValue.Length..changingValueAfterValueStartIndex];

            return result;
        }

        private bool CheckValueValidateForTemplate(ref string value)
        {

            if (!(_changingValueBeforeValue == value[0.._changingValueBeforeValue.Length]))
                return false;

            var changingValueAfterValueStartIndex = value.Length - _changingValueAfterValue.Length;

            if (!(_changingValueAfterValue == value[changingValueAfterValueStartIndex..value.Length]))
                return false;

            return true;
        }
    }
}
