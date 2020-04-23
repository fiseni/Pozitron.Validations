using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForNull
    {
        [Fact]
        public void DoesNothingGivenNonNullValue()
        {
            "".ValidateFor().Null();
            "".ValidateFor().Null("string");
            new object().ValidateFor().Null("object");

            PozValidate.For.Null("", "string");
            PozValidate.For.Null(new Object(), "object");
        }

        [Fact]
        public void ThrowsGivenNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => ((object)null).ValidateFor().Null());
            Assert.Throws<ArgumentNullException>(() => ((object)null).ValidateFor().Null("null"));
            Assert.Throws<ArgumentNullException>(() => ((int?)null).ValidateFor().Null("null"));
            Assert.Throws<ArgumentNullException>(() => ((string)null).ValidateFor().Null("null"));

            Assert.Throws<ArgumentNullException>(() => PozValidate.For.Null(null, "null"));
        }
    }
}
