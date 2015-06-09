using System;
using System.Linq;
using Fauna;

public class Test
{
    private static void Main()
    {
        Animal[] zoo =
        {
            new Dog(4, "Sharo", Gender.male),
            new Kitten(1, "Pusy"),
            new Frog(2, "Penka", Gender.female),
        };

        var averageAge = Animal.AverageAge(zoo);

        Console.WriteLine(averageAge);
    }
}
