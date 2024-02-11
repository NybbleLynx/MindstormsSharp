using System;

namespace MindstormsSharp.Core.Helpers
{
    /// <summary>
    /// Helper class for use in constructor arguments to prevent passing null parameters.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guards against a null object. If the given object is null then a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static TObject AgainstNull<TObject>(TObject obj, string parameterName) 
            => obj != null ? obj : throw new ArgumentNullException(parameterName);

        /// <summary>
        /// Guards against a null or empty string value. If the given value is null or empty then a <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public static string AgainstNullAndEmpty(string value, string parameterName) 
            => !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(parameterName);
    }
}