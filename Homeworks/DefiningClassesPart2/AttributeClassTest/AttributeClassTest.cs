namespace ProgramsTest
{
    using System;
    using AttributeClass;

    [Version(01, 01)]
    public class AttributeClassTest
    {
        internal static void Main()
        {
            Type type = typeof(AttributeClassTest);

            var allAttributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("The program is {0} ", attribute.ToString());
            }

            Console.WriteLine();
        }
    }
}
