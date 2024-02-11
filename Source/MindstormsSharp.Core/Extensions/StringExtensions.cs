using System;
using System.Collections.Generic;
using System.Linq;

namespace MindstormsSharp.Core.Extensions
{
    /// <summary>
    /// Helper class for extensions to .NET string type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if a string value is contained within a collection of string values. If it is then True, otherwise False.
        /// </summary>
        /// <param name="value">The current value to compare for.</param>
        /// <param name="comparisonValues">The list of string values to compare against.</param>
        /// <returns>True if comparison is successful, otherwise false.</returns>
        public static bool AnyOf(this string value, IEnumerable<string> comparisonValues) 
            => comparisonValues.Contains(value);

        /// <summary>
        /// Checks if a string value is contained within a collection of string values. If it is then True, otherwise False.
        /// </summary>
        /// <param name="value">The current value to compare for.</param>
        /// <param name="comparisonValues">The list of string values to compare against.</param>
        /// <param name="comparisonType">The <see cref="StringComparison"/> type to use.</param>
        /// <returns>True if comparison is successful, otherwise false.</returns>
        public static bool AnyOf(this string value, IEnumerable<string> comparisonValues, StringComparison comparisonType) 
            => comparisonValues.Any(comp => comp.Equals(value, comparisonType));
    }
}