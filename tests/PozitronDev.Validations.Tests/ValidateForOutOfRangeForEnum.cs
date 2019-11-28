using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForOutOfRangeForEnum
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void DoesNothingGivenInRangeValue(int enumValue)
        {
            enumValue.ValidateFor().OutOfRange<TestEnum>(nameof(enumValue));

            PozValidate.For.OutOfRange<TestEnum>(enumValue, nameof(enumValue));
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        [InlineData(10)]
        public void ThrowsGivenOutOfRangeValue(int enumValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => enumValue.ValidateFor().OutOfRange<TestEnum>(nameof(enumValue)));
            Assert.Throws<ArgumentOutOfRangeException>(() => PozValidate.For.OutOfRange<TestEnum>(enumValue, nameof(enumValue)));
        }
    }

    internal enum TestEnum
    {
        Cat = 0,
        Dog = 1,
        Fish = 2,
        Budgie = 3,
        Penguin = 4,
        Frog = 5
    }
}
