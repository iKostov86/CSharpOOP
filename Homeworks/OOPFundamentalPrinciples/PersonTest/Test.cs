using System;
using System.Collections.Generic;
using System.Linq;
using People;

public class Test
{
    protected static void PrintPeople<T>(IEnumerable<T> people)
    {
        foreach (var human in people)
        {
            Console.WriteLine(human);
            Console.WriteLine();
        }

        Console.WriteLine("-- -- -- --");
        Console.WriteLine();
    }

    protected static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Ivaylo", "Kostov", 1),
            new Student("Aaa", "Aaa", 2),
            new Student("Bbb", "Bbb", 3),
            new Student("Ccc", "Ccc", 4),
            new Student("Ddd", "Ddd", 2),
            new Student("Eee", "Eee", 2),
            new Student("Fff", "Fff", 3),
            new Student("Ggg", "Ggg", 3),
            new Student("Hhh", "Hhh", 3),
        };

        var studentsByGrade =
            from student in students
            orderby student.Grade
            select student;

        Console.WriteLine(studentsByGrade.GetType());
        ////PrintPeople(studentsByGrade);

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Bai", "Ivan", 150, 8),
            new Worker("Aaa", "Aaa", 100, 9),
            new Worker("Bbb", "Bbb", 100, 9),
            new Worker("Ccc", "Ccc", 120, 9),
            new Worker("Ddd", "Ddd", 130, 9),
            new Worker("Eee", "Eee", 80, 7),
            new Worker("Fff", "Fff", 80, 7),
            new Worker("Ggg", "Ggg", 80, 7),
            new Worker("Hhh", "Hhh", 40, 4),
        };

        var workersByMoneyPerHour =
            from worker in workers
            orderby worker.MoneyPerHour() descending
            select worker;

        Console.WriteLine(workersByMoneyPerHour.GetType());
        ////PrintPeople(workersByMoneyPerHour);

        var result1 = new List<Human>(students);
        result1.AddRange(workers);
        PrintPeople(result1);

        IEnumerable<Human> result2 = (students as IEnumerable<Human>).Union(workers);
        PrintPeople(result2);

        var result3 = students.Cast<Human>().Concat(workers);
        PrintPeople(result3);

        var peopleCombine = students
            .Concat<Human>(workers)
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName);

        Console.WriteLine(peopleCombine.GetType());
        ////PrintPeople(studentWorkerCombine);
    }
}
