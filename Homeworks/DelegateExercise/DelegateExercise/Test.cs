using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExercise
{
    public delegate void SomeDelegate();

    internal class Test
    {
        private static void Main()
        {
            Console.WriteLine(Sum(m => 1 / (decimal)Math.Pow(2, m - 1)));
            Console.WriteLine(Sum(m => 1m / Enumerable.Range(1, m).Aggregate((a, b) => a * b)));
            Console.WriteLine(Sum(m => -1 / (decimal)Math.Pow(-2, m - 1)));
        }

        private static decimal Sum(Func<int, decimal> f)
        {
            decimal sum = 1;
            for (int i = 2; Math.Abs(f(i)) > 0.00001m; i++)
            {
                sum += f(i);
            }

            return sum;
        }
    }
}
