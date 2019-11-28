using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForOutOfRangeForInt
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 1, 3)]
        [InlineData(2, 1, 3)]
        [InlineData(3, 1, 3)]
        public void DoesNothingGivenInRangeValue(int input, int rangeFrom, int rangeTo)
        {
            input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo);

            PozValidate.For.OutOfRange(input, "index", rangeFrom, rangeTo);
        }

        [Theory]
        [InlineData(-1, 1, 3)]
        [InlineData(0, 1, 3)]
        [InlineData(4, 1, 3)]
        public void ThrowsGivenOutOfRangeValue(int input, int rangeFrom, int rangeTo)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo));

            Assert.Throws<ArgumentOutOfRangeException>(() => PozValidate.For.OutOfRange(input, "index", rangeFrom, rangeTo));
        }

        [Theory]
        [InlineData(-1, 3, 1)]
        [InlineData(0, 3, 1)]
        [InlineData(4, 3, 1)]
        public void ThrowsGivenInvalidArgumentValue(int input, int rangeFrom, int rangeTo)
        {
            Assert.Throws<ArgumentException>(() => input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo));

            Assert.Throws<ArgumentException>(() => PozValidate.For.OutOfRange(input, "index", rangeFrom, rangeTo));
        }
    }
}
