using System;
using MobilePhoneComponents;

public class Program
{
    internal static void Main()
    {
        var myPhone = new GSM("Nokia", "Windows");
        Console.WriteLine(myPhone);
        Console.WriteLine("------------------------");
        GSMTest.Test();
        GSMCallHistoryTest.Test();
        Console.WriteLine(MobilePhoneComponents.GSM.IPhone4S);
    }
}
