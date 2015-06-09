using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students;

public class Test
{
    internal static void Main()
    {
        List<StudentsClass> listOfStudents = new List<StudentsClass>()
        {
            new StudentsClass("Ivaylo", "Kostov", "345739", "03227", "i.kostov@abv.bg", new MarksClass { MarksList = new List<int>() { 5, 6, 5, 6 }, }, new GroupClass { GroupNumber = "1", DepartmentName = "Mathematics" }),
            new StudentsClass("Diana", "Pamporova", "123456", "032612", "d.pamporova@abv.bg", new MarksClass { MarksList = new List<int>() { 6, 5, 6, 6 }, }, new GroupClass { GroupNumber = "1", DepartmentName = "Biology" }),
            new StudentsClass("Gosho", "Goshev", "632406", "0244", "basi.mamata@ne_e_abv.bg", new MarksClass { MarksList = new List<int>() { 2, 3, 5, 2 } }, new GroupClass { GroupNumber = "2", DepartmentName = "History" }),
            new StudentsClass("Bai", "Pesho", "010206", marks: new MarksClass { MarksList = new List<int>() { 4, 5, 4, 6 } }, group: new GroupClass { GroupNumber = "3", DepartmentName = "History" }),
        };

        // select students in group 2 using LINQ query
        var studentsFromGroup2Linq =
            from student in listOfStudents
            where student.Group.GroupNumber == "2"
            orderby student.FirstName
            select student;

        foreach (var item in studentsFromGroup2Linq)
        {
            Console.WriteLine(item);
        }

        // select students in group 2 using extension methods
        var studentsFromGroup2Extension = listOfStudents
            .Where(x => x.Group.GroupNumber == "2")
            .OrderBy(x => x.FirstName);

        foreach (var item in studentsFromGroup2Extension)
        {
            Console.WriteLine(item);
        }

        // extract all students that have email in abv.bg, using LINQ
        var studentsExtractedByEmail =
            from student in listOfStudents
            where student.Email != null && student.Email.EndsWith("@abv.bg")
            select student;

        foreach (var item in studentsExtractedByEmail)
        {
            Console.WriteLine(item);
        }

        // extract all students with phones in Sofia, using LINQ
        var studentsExtractedByPhones =
            from student in listOfStudents
            where student.Tel != null && student.Tel.StartsWith("02")
            select student;

        foreach (var item in studentsExtractedByPhones)
        {
            Console.WriteLine(item);
        }

        // select all students that have at least one mark (6)
        var studentsWithExcellentMark =
            from student in listOfStudents
            where student.Marks.MarksList.Contains(6)
            select new { FullName = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) };

        foreach (var item in studentsWithExcellentMark)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // extract all students that have exactly two marks (2)
        var studentWithTwoMarks2 = listOfStudents.Where(x => x.Marks.MarksList.Count(y => y == 2) == 2);

        foreach (var item in studentWithTwoMarks2)
        {
            Console.WriteLine(item);
        }

        // extract all students that enrolled in 2006
        var studentsEnrolledIn2006Marks =
            from student in listOfStudents
            where student.FacNumber.EndsWith("06")
            select new { Marks = string.Join(", ", student.Marks) };

        foreach (var item in studentsEnrolledIn2006Marks)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // extract all students in mathematics department
        List<GroupClass> departmentGroups = new List<GroupClass>() { new GroupClass { GroupNumber = "1", DepartmentName = "Mathematics" } };

        var studentsInMathematicsDepartment =
            from student in listOfStudents
            join mathGroup in departmentGroups
                on student.Group.DepartmentName equals mathGroup.DepartmentName
            select student;

        foreach (var item in studentsInMathematicsDepartment)
        {
            Console.WriteLine(item);
        }

        // return string with maximum length from an array of strings
        string[] strArray = new string[] { "one", "two", "three", "four", "five" };

        var maximalStr =
            (from str in strArray
            orderby str.Length
            select str).Last();

        Console.WriteLine("{0, 12}\r\n", maximalStr.ToUpper());

        // extract all student grouped by GroupName
        var studentsByGroupNameLinq =
            from student in listOfStudents
            group new { FullName = student.FirstName + " " + student.LastName } by student.Group.DepartmentName into department
            select new { Department = department.Key, Members = department };

        foreach (var name in studentsByGroupNameLinq)
        {
            Console.WriteLine("--> {0} <--\r\n", name.Department);

            foreach (var member in name.Members)
            {
                Console.WriteLine("{0}", member);
            }

            Console.WriteLine();
        }

        var studentByGroupName = listOfStudents.GroupBy(student => student.Group.DepartmentName, student => new { FullName = student.FirstName + " " + student.LastName });

        foreach (var department in studentByGroupName)
        {
            Console.WriteLine("--> {0} <--\r\n", department.Key);

            foreach (var member in department)
            {
                Console.WriteLine("{0}", member);
            }

            Console.WriteLine();
        }
    }
}
