using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Validations
{
    /// <summary>
    /// A collection of common IValidate clauses, implented as extensions.
    /// </summary>
    public static class IValidateOutOfRangeExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if the integer input is less than <paramref name="rangeFrom" /> or greater than <paramref name="rangeTo" />.
        /// </summary>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>int</returns>
        public static int OutOfRange(this IValidate<int> validateClause, string parameterName, int rangeFrom, int rangeTo)
        {
            OutOfRange<int>(validateClause, parameterName, rangeFrom, rangeTo);

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if the DateTime input is less than <paramref name="rangeFrom" /> or greater than <paramref name="rangeTo" />.
        /// </summary>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <param name="rangeFrom"></param>
        /// <param name="rangeTo"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>DateTime</returns>
        public static DateTime OutOfRange(this IValidate<DateTime> validateClause, string parameterName, DateTime rangeFrom, DateTime rangeTo)
        {
            OutOfRange<DateTime>(validateClause, parameterName, rangeFrom, rangeTo);

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if the DateTime input is not in the range of valid SqlDateTIme values.
        /// </summary>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>DateTime</returns>
        public static DateTime OutOfSQLDateRange(this IValidate<DateTime> validateClause, string parameterName)
        {
            // System.Data is unavailable in .NET Standard so we can't use SqlDateTime.
            const long sqlMinDateTicks = 552877920000000000;
            const long sqlMaxDateTicks = 3155378975999970000;

            OutOfRange<DateTime>(validateClause, parameterName, new DateTime(sqlMinDateTicks), new DateTime(sqlMaxDateTicks));

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException" /> if the integer input is not a valid enum value.
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>int</returns>
        public static int OutOfRange<T>(this IValidate<int> validateClause, string parameterName) where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), validateClause.Input))
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Required input {parameterName} was not a valid enum value for {typeof(T).ToString()}.");
            }

            return validateClause.Input;
        }

        private static void OutOfRange<T>(IValidate<T> validateClause, string parameterName, T rangeFrom, T rangeTo)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            if (comparer.Compare(rangeFrom, rangeTo) > 0)
            {
                throw new ArgumentException($"{nameof(rangeFrom)} should be less or equal than {nameof(rangeTo)}");
            }

            if (comparer.Compare(validateClause.Input, rangeFrom) < 0 || comparer.Compare(validateClause.Input, rangeTo) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Input {parameterName} was out of range");
            }
        }
    }
}
