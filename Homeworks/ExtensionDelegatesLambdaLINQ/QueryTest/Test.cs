using System;
using System.Collections.Generic;
using System.Linq;
using ExtendedFeatures;
using LINQQuery;

public class Test
{
    internal static void Main()
    {
        // students with first name before last one alphabeticaly
        List<Students> studentList = new List<Students>()
        {
            new Students { FirstName = "Diana", LastName = "Pamporova", Age = 26, City = "Plovdiv" },
            new Students { FirstName = "Ivaylo", LastName = "Kostov", Age = 28, City = "Plovdiv" },
            new Students { FirstName = "Pesho", LastName = "Goshev", Age = 23, City = "Sofia" },
            new Students { FirstName = "Bai", LastName = "Ivan", Age = 42, City = "Plovdiv" },
            new Students { FirstName = "Boris", LastName = "Tachev", Age = 27, City = "Plovdiv" }
        };

        var firstNameBeforeLastOne = Query.FirstNameBeforeLast(studentList);

        foreach (var item in firstNameBeforeLastOne)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // students with age between 18 and 24
        var yongerStudents = studentList.FindAll(x => x.Age > 18 && x.Age < 24).Select(x => x.FirstName + " / " + x.LastName);

        foreach (var item in yongerStudents)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // sort students by first name then by last one
        var sortedStudents = studentList.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);

        foreach (var item in sortedStudents)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        var sortedStudentsLinq =
            from student in studentList
            orderby student.FirstName descending
            orderby student.LastName descending
            select student;

        foreach (var item in sortedStudents)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // prints integers from given array that divisible by 7 and 3 (extension)
        int[] numbers = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 21, 44, 42, 67, 91, 84 };

        var divisibleNumbers = numbers.PrintIntDivisibleBy7And3();

        foreach (var item in divisibleNumbers)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        var divisibleNumbersLinq =
            from number in numbers
            where (number % 7 == 0) && (number % 3 == 0)
            select number;

        foreach (var item in divisibleNumbersLinq)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }
}
