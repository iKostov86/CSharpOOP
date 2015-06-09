namespace FurnitureManufacturer.Common
{
    using System;

    public static class Helpers
    {
        public static void ChekStringIfNullOrEmpthy(this string str, string message = "String can't be null or empthy!")
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ChekStringIfWithLessThanXSymbols(this string str, int symbols, string message = null)
        {
            if (str.Length < symbols)
            {
                if (message == null)
                {
                    message = string.Format("String can't be less than {0} symbols!", symbols);
                }

                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ChekValueIfLessThanXOrEqual<T>(this T value, T min, string message = null)
            where T : struct, IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.Equals(min))
            {
                if (message == null)
                {
                    message = string.Format("Value can't be less or equal to {0}!", min);
                }

                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
