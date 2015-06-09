namespace Extensions
{
    using System;
    using System.Text;

    public static class Helper
    {
        public static string ArrayString(this int[] array)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
            }

            return sb.ToString();
        }
    }
}
