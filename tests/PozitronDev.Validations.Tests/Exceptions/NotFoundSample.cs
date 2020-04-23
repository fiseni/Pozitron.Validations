using PozitronDev.Validations.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Validations.Tests.Exceptions
{
    public class NotFoundSample
    {
        public void SampleMethod1()
        {
            throw new NotFoundException("1", "test");
        }

        public void SampleMethod2()
        {
            throw new NotFoundException("1", "test", new Exception());
        }
    }
}
