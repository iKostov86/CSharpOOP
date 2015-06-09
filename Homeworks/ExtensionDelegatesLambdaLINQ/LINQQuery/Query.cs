namespace LINQQuery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Query
    {
        public static List<Students> FirstNameBeforeLast(List<Students> students)
        {
            var newListOfStudents =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return newListOfStudents.ToList();
        }
    }
}
