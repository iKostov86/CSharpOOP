using System;
using StudentHierarchy;

public class Test
{
    private static void Main()
    {
        Student st1 = new Student("Ivaylo", "Valeriev", "Kostov");
        Student st2 = new Student("Ivaylo", "Valeriev", "Kostov");
        Student st3 = new Student();
        Student st4 = st1.Clone() as Student;

        Console.WriteLine(st1.GetHashCode());
        Console.WriteLine(st1 == st2);
        Console.WriteLine(st1.Equals(st2));
        Console.WriteLine(ReferenceEquals(st1, st2));

        Console.WriteLine();

        Console.WriteLine(st4.GetHashCode());
        Console.WriteLine(st1 == st4);
        Console.WriteLine(st1.Equals(st4));
        Console.WriteLine(ReferenceEquals(st1, st4));
    }
}
