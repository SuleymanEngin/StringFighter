using StringFighter.StringExtractors.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringFighter.StringExtractors.Tests
{
    public class ChangingValueExtractorTests
    {
        [Fact]
        public void ToChangingValueExtractor_ShouldBeChangingValue_WhenChangingValueIsInTheMıddleOfTheString()
        {
            ChangingValueExtractor changingValueExtractor = new ChangingValueExtractor("bu ürün {} tarafından satılmaktadır.");

            var input = "bu ürün ahmet erdal tarafından satılmaktadır.";
            var result = changingValueExtractor.ExtractChangingValue(ref input);

            Assert.Equal("ahmet erdal", result);
        }

        [Fact]
        public void ToChangingValueExtractor_ShouldBeChangingValue_WhenChangingValueIsInThheEndOfTheString()
        {
            ChangingValueExtractor changingValueExtractor = new ChangingValueExtractor("bu adamın adı {}");

            var input = "bu adamın adı kemalettin erbaş yanyatmaz düzkalkmazdır";

            var result = changingValueExtractor.ExtractChangingValue(ref input);

            Assert.Equal("kemalettin erbaş yanyatmaz düzkalkmazdır", result);
        }

        [Fact]
        public void ToChangingValueExtractor_ShouldBeChangingValue_WhenChangingValueIsInThheBeginningOfTheString()
        {
            ChangingValueExtractor changingValueExtractor = new ChangingValueExtractor("{} adlı şahıs gerçek anlamda bir yalancıdır!");

            var input = "nizamettin ucsuzhayalgücü adlı şahıs gerçek anlamda bir yalancıdır!";

            var result = changingValueExtractor.ExtractChangingValue(ref input);

            Assert.Equal("nizamettin ucsuzhayalgücü", result);
        }

        [Fact]
        public void ToChangingValueExtractor_ShouldBeValueNotValidForTemplateException_WhenValueIsNotValidForTheTemplate()
        {
            ChangingValueExtractor changingValueExtractor = new ChangingValueExtractor("Sahi {}'da bizimle gelecek mi?");

            var input = "Sahi nizamettinde geliyo mu?";

            var exception = Record.Exception(() => changingValueExtractor.ExtractChangingValue(ref input));

            Assert.IsType<ValueNotValidForTemplateException>(exception);
        }

        [Fact]
        public void ToChangingValueExtractor_ShouldBeArgumentException_WhenConstructorParamWasNullOrSpace()
        {
            var whenSpaceException = Record.Exception(() => new ChangingValueExtractor(""));

            var whenNullException = Record.Exception(() => new ChangingValueExtractor(null));

            Assert.IsType<ArgumentException>(whenSpaceException);
            Assert.IsType<ArgumentException>(whenNullException);
        }

        [Fact]
        public void ToChangingValueExtractor_ShouldBeArgumentException_WhenExtrachChangingMethodParamWasNullOrSpace()
        {
            var changingValuExtractor = new ChangingValueExtractor("blab {} labla");

            var spaceInput = " ";

            string nullInput = null;

            var whenSpaceException = Record.Exception(() => changingValuExtractor.ExtractChangingValue(ref spaceInput));

            var whenNullException = Record.Exception(() => changingValuExtractor.ExtractChangingValue(ref nullInput));

            Assert.IsType<ArgumentException>(whenSpaceException);
            Assert.IsType<ArgumentException>(whenNullException);
        }
    }
}
