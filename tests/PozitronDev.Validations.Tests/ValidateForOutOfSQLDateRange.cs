using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForOutOfSQLDateRange
    {
        [Theory]
        [InlineData(1)]
        [InlineData(60)]
        [InlineData(60 * 60)]
        [InlineData(60 * 60 * 24)]
        [InlineData(60 * 60 * 24 * 30)]
        [InlineData(60 * 60 * 24 * 30 * 365)]
        public void ThrowsGivenValueBelowMinDate(int offsetInSeconds)
        {
            DateTime date = SqlDateTime.MinValue.Value.AddSeconds(-offsetInSeconds);

            Assert.Throws<ArgumentOutOfRangeException>(() => PozValidate.For.OutOfSQLDateRange(date, nameof(date)));
        }

        [Fact]
        public void DoNothingGivenCurrentDate()
        {
            DateTime.Today.ValidateFor().OutOfSQLDateRange("Today");
            DateTime.Now.ValidateFor().OutOfSQLDateRange("Now");
            DateTime.UtcNow.ValidateFor().OutOfSQLDateRange("UTC Now");

            PozValidate.For.OutOfSQLDateRange(DateTime.Today, "Today");
            PozValidate.For.OutOfSQLDateRange(DateTime.Now, "Now");
            PozValidate.For.OutOfSQLDateRange(DateTime.UtcNow, "UTC Now");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(60)]
        [InlineData(60 * 60)]
        [InlineData(60 * 60 * 24)]
        [InlineData(60 * 60 * 24 * 30)]
        [InlineData(60 * 60 * 24 * 30 * 365)]
        public void DoNothingGivenSqlMinValue(int offsetInSeconds)
        {
            DateTime date = SqlDateTime.MinValue.Value.AddSeconds(offsetInSeconds);

            date.ValidateFor().OutOfSQLDateRange(nameof(date));

            PozValidate.For.OutOfSQLDateRange(date, nameof(date));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(60)]
        [InlineData(60 * 60)]
        [InlineData(60 * 60 * 24)]
        [InlineData(60 * 60 * 24 * 30)]
        [InlineData(60 * 60 * 24 * 30 * 365)]
        public void DoNothingGivenSqlMaxValue(int offsetInSeconds)
        {
            DateTime date = SqlDateTime.MaxValue.Value.AddSeconds(-offsetInSeconds);

            date.ValidateFor().OutOfSQLDateRange(nameof(date));

            PozValidate.For.OutOfSQLDateRange(date, nameof(date));
        }
    }
}
