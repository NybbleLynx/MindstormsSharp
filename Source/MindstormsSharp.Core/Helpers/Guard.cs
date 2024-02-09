using System;

namespace MindstormsSharp.Core.Helpers
{
    public static class Guard
    {
        public static TObject AgainstNull<TObject>(TObject obj, string parameterName) 
            => obj != null ? obj : throw new ArgumentNullException(parameterName);

        public static string AgainstNullAndEmpty(string value, string parameterName) 
            => !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentNullException(parameterName);
    }
}