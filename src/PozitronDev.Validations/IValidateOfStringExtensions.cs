using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Validations
{
    /// <summary>
    /// A collection of common IValidate clauses, implented as extensions.
    /// </summary>
    public static class IValidateOfStringExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if the input string is null.
        /// Throws an <see cref="ArgumentException" /> if the input string is and empty string.
        /// </summary>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>string</returns>
        public static string NullOrEmpty(this IValidate<string> validateClause, string parameterName = null)
        {
            validateClause.Null(parameterName);

            if (validateClause.Input.ToString() == string.Empty)
            {
                throw new ArgumentException($"Required parameter {parameterName ?? validateClause.InputTypeName} was null or empty.");
            }

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if the input string is null.
        /// Throws an <see cref="ArgumentException" /> if the input string is an empty or white space string.
        /// </summary>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>string</returns>
        public static string NullOrWhiteSpace(this IValidate<string> validateClause, string parameterName = null)
        {
            validateClause.NullOrEmpty(parameterName);

            if (string.IsNullOrWhiteSpace(validateClause.Input.ToString()))
            {
                throw new ArgumentException($"Required parameter {parameterName ?? validateClause.InputTypeName} was null, empty or consists of white spaces.");
            }

            return validateClause.Input;
        }
    }
}
