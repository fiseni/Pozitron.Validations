using PozitronDev.Validations.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PozitronDev.Validations.Tests.Exceptions
{
    public class NotFoundSampleTest
    {
        [Fact]
        public void SampleMethod1ShouldThrow()
        {
            var sample = new NotFoundSample();

            Assert.Throws<NotFoundException>(() => sample.SampleMethod1());
            Assert.Throws<NotFoundException>(() => sample.SampleMethod2());
        }
    }
}
