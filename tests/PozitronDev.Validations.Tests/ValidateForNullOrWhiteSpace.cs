using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForNullOrWhiteSpace
    {
        [Theory]
        [InlineData("a")]
        [InlineData("1")]
        [InlineData("some text")]
        [InlineData(" leading whitespace")]
        [InlineData("trailing whitespace ")]
        public void DoesNothingGivenNonEmptyStringValue(string nonEmptyString)
        {
            nonEmptyString.ValidateFor().NullOrWhiteSpace();
            nonEmptyString.ValidateFor().NullOrWhiteSpace("string");
            nonEmptyString.ValidateFor().NullOrWhiteSpace("aNumericString");

            PozValidate.For.NullOrWhiteSpace(nonEmptyString, "string");
            PozValidate.For.NullOrWhiteSpace(nonEmptyString, "aNumericString");
        }

        [Fact]
        public void ThrowsGivenNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).ValidateFor().NullOrWhiteSpace());
            Assert.Throws<ArgumentNullException>(() => ((string)null).ValidateFor().NullOrWhiteSpace("null"));

            Assert.Throws<ArgumentNullException>(() => PozValidate.For.NullOrWhiteSpace(null, "null"));
        }

        [Fact]
        public void ThrowsGivenEmptyString()
        {
            Assert.Throws<ArgumentException>(() => string.Empty.ValidateFor().NullOrWhiteSpace());
            Assert.Throws<ArgumentException>(() => string.Empty.ValidateFor().NullOrWhiteSpace("emptystring"));

            Assert.Throws<ArgumentException>(() => PozValidate.For.NullOrWhiteSpace("", "emptystring"));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("   ")]
        public void ThrowsGivenWhiteSpaceString(string whiteSpaceString)
        {
            Assert.Throws<ArgumentException>(() => whiteSpaceString.ValidateFor().NullOrWhiteSpace());
            Assert.Throws<ArgumentException>(() => whiteSpaceString.ValidateFor().NullOrWhiteSpace("whitespacestring"));

            Assert.Throws<ArgumentException>(() => PozValidate.For.NullOrWhiteSpace(whiteSpaceString, "whitespacestring"));
        }
    }
}
