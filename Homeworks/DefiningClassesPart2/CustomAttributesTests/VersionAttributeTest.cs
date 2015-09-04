namespace ProgramsTests
{
    using System;
    using CustomAttributes;

    [Version(01, 01)]
    public class VersionAttributeTest
    {
        internal static void Main()
        {
            Type type = typeof(VersionAttributeTest);

            var allAttributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("The program is {0} ", attribute.ToString());
            }

            Console.WriteLine();
        }
    }
}