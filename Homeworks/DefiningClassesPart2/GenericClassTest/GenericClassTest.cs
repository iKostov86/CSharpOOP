namespace ProgramTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GenericClass;

    public class GenericClassTest
    {
        internal static void Main()
        {
            GenericList<int> myList = new GenericList<int>();

            for (int i = 0; i < 16; i++)
            {
                myList.AddElement(i + 10);
            }

            Console.WriteLine(myList);

            Console.WriteLine(myList.Max());

            Console.WriteLine(myList.Min());
        }
    }
}