using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringFighter.StringExtractors.Tests
{
    public class KeyValueExtractorTests
    {
        KeyValueExtractor _extracter;

        public KeyValueExtractorTests()
        {
            _extracter = new KeyValueExtractor();
        }

        [Fact]
        public void ToStringExtracter_ShouldArgumentNullException_WhenParametersNull()
        {
            string param1 = null;

            var result = Record.Exception(() => _extracter.GetValueByKeyFromString(ref param1, null));

            Assert.IsType<ArgumentNullException>(result);
        }

        [Fact]
        public void ToStringExtracter_ShouldJsonObject_WhennTheKeyIsFoundInTheString()
        {
            string jsonString = @"asdkaodpkaopdak aspodkpoadksapo obj={name:""ali""}";

            var result = _extracter.GetValueByKeyFromString(ref jsonString, "obj");

            Assert.Equal(@"{name:""ali""}", result);
        }

        [Fact]
        public void ToStringExtracter_ShouldKeyNotFoundException_WhenKeywordIsNotInTheString()
        {
            string jsonString = @"asdkaodpkaopdak aspodkpoadksapo obj={name:""ali""}";

            var exception = Record.Exception(() => _extracter.GetValueByKeyFromString(ref jsonString, "qwelrlrlrlr"));

            Assert.IsType<KeyNotFoundException>(exception);
        }

        [Fact]
        public void ToStringExtracter_ShouldJsonArray_WhenTheKeyIsFoundInTheString()
        {
            string jsonString = @"okpoaskdpoakdopapkd sapodkpaokdpoad asodpkadopka humans=[{name:{lastName:""kemal""}},{name:{lastName:""cemalettin""}}]";

            var result = _extracter.GetValueByKeyFromString(ref jsonString, "humans=");

            Assert.Equal(@"[{name:{lastName:""kemal""}},{name:{lastName:""cemalettin""}}]", result);
        }

        [Fact]
        public void ToStringExtracter_ShoulDoubleQuotedStringValue_WhenKeyIsFoundInTheString()
        {
            string jsonString = @"gool, gool bbe. merhaba hocam. var humanName='alicandan'";

            var result = _extracter.GetValueByKeyFromString(ref jsonString, "humanName=");

            Assert.Equal("alicandan", result);
        }

        [Fact]
        public void ToStringExtracter_ShoulSingleQuotedStringValue_WhenKeyIsFoundInTheString()
        {
            string jsonString = @"gool, gool bbe. merhaba hocam. var humanName=""alicandan""";

            var result = _extracter.GetValueByKeyFromString(ref jsonString, "humanName=");

            Assert.Equal("alicandan", result);
        }
    }
}
