namespace InfiniteSeries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public delegate K SomeDelegate<T, K>(T number);

    public class InfiniteSeriesClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dlg"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal CalculateTheSumOfInfiniteSeries<T, K>(SomeDelegate<T, K> dlg, decimal precision)
            where T : struct
        {
            decimal result = 0m;
            int element = 1;

            while (true)
            {
                decimal res = (decimal)Convert.ChangeType(dlg((T)Convert.ChangeType(element, typeof(T))), typeof(decimal));

                if (Math.Abs(res) < precision)
                {
                    break;
                }

                result += res;
                element++;

                Console.WriteLine(result);
            }

            return result;
        }
    }
}