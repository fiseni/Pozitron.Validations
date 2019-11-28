using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PozitronDev.Validations.Exceptions;

namespace PozitronDev.Validations
{
    /// <summary>
    /// A collection of common PozValidate clauses, implented as extensions.
    /// </summary>
    /// <example>
    /// PozValidate.For.Null(input, nameof(input));
    /// </example>
    public static class PozValidateExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Null(this IPozValidate pozValidateClause, object input, string parameterName)
        {
            input.ValidateFor().Null(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty string.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NullOrEmpty(this IPozValidate pozValidateClause, string input, string parameterName)
        {
            input.ValidateFor().NullOrEmpty(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty enumerable.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NullOrEmpty<T>(this IPozValidate pozValidateClause, IEnumerable<T> input, string parameterName)
        {
            input.ValidateFor().NullOrEmpty(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if <paramref name="input" /> is null.
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty or white space string.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NullOrWhiteSpace(this IPozValidate pozValidateClause, string input, string parameterName)
        {
            input.ValidateFor().NullOrWhiteSpace(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input" /> is less than <paramref name="rangeFrom" /> or greater than <paramref name="rangeTo" />.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfRange(this IPozValidate pozValidateClause, int input, string parameterName, int rangeFrom, int rangeTo)
        {
            input.ValidateFor().OutOfRange(parameterName, rangeFrom, rangeTo);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input" /> is less than <paramref name="rangeFrom" /> or greater than <paramref name="rangeTo" />.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfRange(this IPozValidate pozValidateClause, DateTime input, string parameterName, DateTime rangeFrom, DateTime rangeTo)
        {
            input.ValidateFor().OutOfRange(parameterName, rangeFrom, rangeTo);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input" /> is not in the range of valid SqlDateTIme./> values.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfSQLDateRange(this IPozValidate pozValidateClause, DateTime input, string parameterName)
        {
            // System.Data is unavailable in .NET Standard so we can't use SqlDateTime.
            const long sqlMinDateTicks = 552877920000000000;
            const long sqlMaxDateTicks = 3155378975999970000;

            input.ValidateFor().OutOfRange(parameterName, new DateTime(sqlMinDateTicks), new DateTime(sqlMaxDateTicks));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if <paramref name="input" /> is not a valid enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfRange<T>(this IPozValidate pozValidateClause, int input, string parameterName) where T : Enum
        {
            input.ValidateFor().OutOfRange<T>(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is default for that type.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void Default<T>(this IPozValidate pozValidateClause, T input, string parameterName)
        {
            input.ValidateFor().Default(parameterName);
        }

        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if <paramref name="queriedObject" /> with <paramref name="key" /> is not found.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="key"></param>
        /// <param name="queriedObject"></param>
        /// <param name="objectName"></param>
        /// <exception cref="NotFoundException"></exception>
        public static void NotFound(this IPozValidate pozValidateClause, string key, object queriedObject, string objectName)
        {
            queriedObject.ValidateFor().NotFound(key, objectName);
        }

        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if <paramref name="queriedObject" /> with <paramref name="key" /> is not found.
        /// </summary>
        /// <param name="pozValidateClause"></param>
        /// <param name="key"></param>
        /// <param name="queriedObject"></param>
        /// <param name="objectName"></param>
        /// <exception cref="NotFoundException"></exception>
        public static void NotFound(this IPozValidate pozValidateClause, int key, object queriedObject, string objectName)
        {
            queriedObject.ValidateFor().NotFound(key, objectName);
        }
    }
}
