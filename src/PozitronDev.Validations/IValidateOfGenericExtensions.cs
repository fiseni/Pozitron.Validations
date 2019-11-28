using PozitronDev.Validations.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Validations
{
    /// <summary>
    /// A collection of common IValidate clauses, implented as extensions.
    /// </summary>
    public static class IValidateOfGenericExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if the input is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns><typeparamref name="T"/></returns>
        public static T Null<T>(this IValidate<T?> validateClause, string parameterName = null) where T : struct
        {
            if (validateClause.Input == null)
            {
                throw new ArgumentNullException(parameterName ?? validateClause.InputTypeName);
            }

            return validateClause.Input.Value;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException" /> if the input is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns><typeparamref name="T"/></returns>
        public static T Null<T>(this IValidate<T> validateClause, string parameterName = null) where T : class
        {
            if (validateClause.Input == null)
            {
                throw new ArgumentNullException(parameterName ?? validateClause.InputTypeName);
            }

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if the input is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="key">The value by which the object is queried.</param>
        /// <param name="parameterName">Name of the queried object.</param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns><typeparamref name="T"/></returns>
        public static T NotFound<T, TKey>(this IValidate<T> validateClause, TKey key, string parameterName = null) where T : class where TKey : struct
        {
            validateClause.NotFound(key.ToString(), parameterName);

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="NotFoundException" /> if the input is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="key">The string value by which the object is queried.</param>
        /// <param name="parameterName">Name of the queried object.</param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns><typeparamref name="T"/></returns>
        public static T NotFound<T>(this IValidate<T> validateClause, string key, string parameterName = null) where T : class
        {
            if (validateClause.Input == null)
                throw new NotFoundException(key, parameterName ?? validateClause.InputTypeName);

            return validateClause.Input;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException" /> if the input is default value for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validateClause"></param>
        /// <param name="parameterName">Name of the variable/property.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns><typeparamref name="T"/></returns>
        public static T Default<T>(this IValidate<T> validateClause, string parameterName = null)
        {
            if (EqualityComparer<T>.Default.Equals(validateClause.Input, default(T)))
            {
                throw new ArgumentException($"Parameter {parameterName ?? validateClause.InputTypeName} is default value for type {validateClause.InputTypeName}");
            }

            return validateClause.Input;
        }
    }
}
