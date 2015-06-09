namespace WarMachines.Helpers
{
    using System;
    
    using WarMachines.Interfaces;
    using WarMachines.Machines;
    using WarMachines.Pilots;

    public static class WarMachinesExtensions
    {
        public static void ChekObjectIfNull(this object obj, string message = "Object can't be null!")
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message); 
            }
        }

        public static void ChekStringIfNullOrEmpthy(this string str, string message = "String can't be null or empthy!")
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ChekValueForNegative<T>(this T value, string msg = "Value can't be negative!")
            where T : struct, IComparable<T>
        {
            if (value.CompareTo(default(T)) < 0)
            {
                throw new ArgumentException(msg);
            }
        }
    }
}
