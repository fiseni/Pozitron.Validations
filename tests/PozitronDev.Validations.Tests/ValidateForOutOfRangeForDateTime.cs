using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForOutOfRangeForDateTime
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 3)]
        [InlineData(-1, 1)]
        [InlineData(-1, 0)]
        public void DoesNothingGivenInRangeValue(int rangeFromOffset, int rangeToOffset)
        {
            DateTime input = DateTime.Now;
            DateTime rangeFrom = input.AddSeconds(rangeFromOffset);
            DateTime rangeTo = input.AddSeconds(rangeToOffset);

            input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo);

            PozValidate.For.OutOfRange(input, "index", rangeFrom, rangeTo);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(-4, -3)]
        public void ThrowsGivenOutOfRangeValue(int rangeFromOffset, int rangeToOffset)
        {
            DateTime input = DateTime.Now;
            DateTime rangeFrom = input.AddSeconds(rangeFromOffset);
            DateTime rangeTo = input.AddSeconds(rangeToOffset);

            Assert.Throws<ArgumentOutOfRangeException>(() => input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo));

            Assert.Throws<ArgumentOutOfRangeException>(() => PozValidate.For.OutOfRange(input, "index", rangeFrom, rangeTo));
        }

        [Theory]
        [InlineData(3, 1)]
        [InlineData(3, -1)]
        public void ThrowsGivenInvalidArgumentValue(int rangeFromOffset, int rangeToOffset)
        {
            DateTime input = DateTime.Now;
            DateTime rangeFrom = input.AddSeconds(rangeFromOffset);
            DateTime rangeTo = input.AddSeconds(rangeToOffset);

            Assert.Throws<ArgumentException>(() => input.ValidateFor().OutOfRange("index", rangeFrom, rangeTo));

            Assert.Throws<ArgumentException>(() => PozValidate.For.OutOfRange(DateTime.Now, "index", rangeFrom, rangeTo));
        }
    }
}
