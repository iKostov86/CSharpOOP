using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfiniteSeries;

internal class Test
{
    private static void Main()
    {
        // first series
        Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + 1/16 + …");
        SomeDelegate<double, double> dlgFlt1 = 
            delegate(double index)
            {
                return 1 / Math.Pow(2, index - 1);
            };

        // SomeDelegate<double, double> dlgFlt = index => 1 / Math.Pow(2, index - 1);
        Console.WriteLine("{0:F2}", InfiniteSeriesClass.CalculateTheSumOfInfiniteSeries(dlgFlt1, 0.01m));
        Console.WriteLine();

        // second series
        Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - 1/16 + …");
        SomeDelegate<double, double> dlgflt2 =
            index => (index % 2) == 0 ?
                (1 / Math.Pow(2, index - 1)) * -1 :
                (1 / Math.Pow(2, index - 1));

        Console.WriteLine("{0:F2}", InfiniteSeriesClass.CalculateTheSumOfInfiniteSeries(dlgflt2, 0.01m));
        Console.WriteLine();

        MessageBox.Show("I am watching you!");
    }
}
