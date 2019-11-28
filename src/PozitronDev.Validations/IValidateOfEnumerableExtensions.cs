using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PozitronDev.Validations
{
    /// <summary>
    /// A collection of common IValidate clauses, implented as extensions.
    /// </summary>
    public static class IValidateOfEnumerableExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if the input is null.
        /// Throws an <see cref="ArgumentException" /> if the input is an empty enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>IEnumerable of <typeparamref name="T"/></returns>
        public static IEnumerable<T> NullOrEmpty<T>(this IValidate<IEnumerable<T>> validateClause, string parameterName = null)
        {
            validateClause.Null(parameterName);

            if (!validateClause.Input.Any())
            {
                throw new ArgumentException($"Required parameter {parameterName ?? validateClause.InputTypeName} was null or empty.");
            }

            return validateClause.Input;
        }
    }
}
