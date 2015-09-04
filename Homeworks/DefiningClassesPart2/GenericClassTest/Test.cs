namespace ProgramsTest
{
    using System;
    using GenericClass;

    public class Test
    {
        internal static void Main()
        {
            var myList = new GenericList<int>();

            for (int i = 0; i < 4; i++)
            {
                myList.AddElement(i);
            }

            myList.RemoveElement(myList.Count - 1);
            myList.RemoveElement(1);

            Console.WriteLine(myList.Count);

            Console.WriteLine(myList.Capacity);

            Console.WriteLine("The list members:\n{0}", myList);

            Console.WriteLine("The max value of list:\n{0}", myList.Max());

            Console.WriteLine("The min value of list:\n{0}", myList.Min());
        }
    }
}