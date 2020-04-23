using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PozitronDev.Validations.Exceptions;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForNotFound
    {
        [Fact]
        public void DoesNothingGivenNonNullValue()
        {
            new object().ValidateFor().NotFound("1");
            new object().ValidateFor().NotFound("1", "object");
            new object().ValidateFor().NotFound(1, "object");

            PozValidate.For.NotFound("1", "", "string");
            PozValidate.For.NotFound(1, new Object(), "object");
        }

        [Fact]
        public void ThrowsGivenNullValue()
        {
            Assert.Throws<NotFoundException>(() => ((object)null).ValidateFor().NotFound("1"));
            Assert.Throws<NotFoundException>(() => ((object)null).ValidateFor().NotFound("1", "null"));
            Assert.Throws<NotFoundException>(() => ((object)null).ValidateFor().NotFound(1, "null"));

            Assert.Throws<NotFoundException>(() => PozValidate.For.NotFound("1", null, "null"));
            Assert.Throws<NotFoundException>(() => PozValidate.For.NotFound(1, null, "null"));
        }
    }
}
