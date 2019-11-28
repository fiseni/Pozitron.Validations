using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests
{
    public class ValidateForDefault
    {
        [Fact]
        public void DoesNothingGivenNonDefaultValue()
        {
            "".ValidateFor().Default("string");
            1.ValidateFor().Default("int");
            Guid.NewGuid().ValidateFor().Default("guid");
            DateTime.Now.ValidateFor().Default("datetime");
            new object().ValidateFor().Default("object");

            PozValidate.For.Default("", "string");
            PozValidate.For.Default(1, "int");
            PozValidate.For.Default(Guid.NewGuid(), "guid");
            PozValidate.For.Default(DateTime.Now, "datetime");
            PozValidate.For.Default(new Object(), "object");
        }

        [Fact]
        public void ThrowsGivenDefaultValue()
        {
            Assert.Throws<ArgumentException>(() => default(string).ValidateFor().Default("string"));
            Assert.Throws<ArgumentException>(() => default(int).ValidateFor().Default("int"));
            Assert.Throws<ArgumentException>(() => default(Guid).ValidateFor().Default("guid"));
            Assert.Throws<ArgumentException>(() => default(DateTime).ValidateFor().Default("datetime"));
            Assert.Throws<ArgumentException>(() => default(object).ValidateFor().Default("object"));

            Assert.Throws<ArgumentException>(() => PozValidate.For.Default(default(string), "string"));
            Assert.Throws<ArgumentException>(() => PozValidate.For.Default(default(int), "int"));
            Assert.Throws<ArgumentException>(() => PozValidate.For.Default(default(Guid), "guid"));
            Assert.Throws<ArgumentException>(() => PozValidate.For.Default(default(DateTime), "datetime"));
            Assert.Throws<ArgumentException>(() => PozValidate.For.Default(default(object), "object"));
        }
    }
}
