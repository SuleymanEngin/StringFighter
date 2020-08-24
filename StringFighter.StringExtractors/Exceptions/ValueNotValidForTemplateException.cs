using System;
using System.Collections.Generic;
using System.Text;

namespace StringFighter.StringExtractors.Exceptions
{
    public class ValueNotValidForTemplateException : Exception
    {
        public ValueNotValidForTemplateException(string message) : base(message)
        {

        }
    }
}
