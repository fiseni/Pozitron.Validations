using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Validations
{
    /// <summary>
    /// An entry point to a set of PozValidate clauses defined as extension methods on IPozValidate.
    /// </summary>
    public class PozValidate : IPozValidate
    {
        /// <summary>
        /// An entry point to a set of PozValidate clauses defined as extension methods on IPozValidate.
        /// </summary>
        public static IPozValidate For { get; } = new PozValidate();

        private PozValidate() { }
    }
}
