using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForNullOrEmpty
    {
        [Fact]
        public void DoesNothingGivenNonEmptyStringValue()
        {
            "a".ValidateFor().NullOrEmpty();
            "a".ValidateFor().NullOrEmpty("string");
            "1".ValidateFor().NullOrEmpty("aNumericString");

            PozValidate.For.NullOrEmpty("a", "string");
            PozValidate.For.NullOrEmpty("1", "aNumericString");
        }

        [Fact]
        public void DoesNothingGivenNonEmptyEnumerable()
        {
            new[] { "foo", "bar" }.ValidateFor().NullOrEmpty();
            new[] { "foo", "bar" }.ValidateFor().NullOrEmpty("stringArray");
            new[] { 1, 2 }.ValidateFor().NullOrEmpty("intArray");
            new List<string>() { "foo", "bar" }.ValidateFor().NullOrEmpty();
            new List<string>() { "foo", "bar" }.ValidateFor().NullOrEmpty("stringList");
            new List<int>() { 1, 2 }.ValidateFor().NullOrEmpty("intList");

            PozValidate.For.NullOrEmpty(new[] { "foo", "bar" }, "stringArray");
            PozValidate.For.NullOrEmpty(new[] { 1, 2 }, "intArray");
            PozValidate.For.NullOrEmpty(new List<string>() { "foo", "bar" }, "stringList");
            PozValidate.For.NullOrEmpty(new List<int>() { 1, 2 }, "intList");
        }

        [Fact]
        public void ThrowsGivenNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).ValidateFor().NullOrEmpty());
            Assert.Throws<ArgumentNullException>(() => ((string)null).ValidateFor().NullOrEmpty("null"));
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<string>)null).ValidateFor().NullOrEmpty());
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<string>)null).ValidateFor().NullOrEmpty("null"));

            Assert.Throws<ArgumentNullException>(() => PozValidate.For.NullOrEmpty(null, "null"));
        }

        [Fact]
        public void ThrowsGivenEmptyString()
        {
            Assert.Throws<ArgumentException>(() => string.Empty.ValidateFor().NullOrEmpty());
            Assert.Throws<ArgumentException>(() => string.Empty.ValidateFor().NullOrEmpty("emptystring"));

            Assert.Throws<ArgumentException>(() => PozValidate.For.NullOrEmpty("", "emptystring"));
        }

        [Fact]
        public void ThrowsGivenEmptyEnumerable()
        {
            Assert.Throws<ArgumentException>(() => Enumerable.Empty<string>().ValidateFor().NullOrEmpty());
            Assert.Throws<ArgumentException>(() => Enumerable.Empty<string>().ValidateFor().NullOrEmpty("emptyStringEnumerable"));

            Assert.Throws<ArgumentException>(() => PozValidate.For.NullOrEmpty(Enumerable.Empty<string>(), "emptyStringEnumerable"));
        }
    }
}
