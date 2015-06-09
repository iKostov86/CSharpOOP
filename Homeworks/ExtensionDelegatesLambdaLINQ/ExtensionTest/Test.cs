using System;
using System.Collections.Generic;
using System.Text;
using ExtendedFeatures;

public class Test
{
    public static void Method<T, K>(T point, params K[] prop)
    {
        Console.WriteLine(point.GetType());
        Console.WriteLine(prop[prop.Length - 1]);
    }

    internal static void Main()
    {
        var point = new
        {
            X = 10,
            Y = 20,
        };

        Method(point, point.X, point.Y);

        StringBuilder myBuilder = new StringBuilder();
        myBuilder.Append("IvayloKostovDianaPamporova");
        Console.WriteLine(myBuilder.SubstringBuilder(6, 6));
        Console.WriteLine(myBuilder.SubstringBuilder(17, 9));

        var list1 = new List<char>();
        var list2 = new List<int>();
        var list3 = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            list1.Add((char)i);
            list2.Add(i + 3);
        }

        Console.WriteLine("Eto min: {0}", list1.MinInColection());
        Console.WriteLine("Eto max: {0}", list1.MaxInColection());
        Console.WriteLine("Eto average: {0}", list1.AverageInColection());

        var result1 = list1.SumCollection();

        Console.WriteLine(result1);

        //var result2 = list1.SumTwoCollection(list2);

        //foreach (var item in result2)
        //{
        //    Console.WriteLine(item);
        //}
    }
}
