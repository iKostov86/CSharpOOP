using System;
using System.Linq;
using System.Collections.Generic;
using MobilePhoneComponents;

public class Program
{
    internal static void Main()
    {
        var myPhone = new GSM("Nokia", "Windows");
        Console.WriteLine(myPhone.Owner);
        Console.WriteLine("------------------------");

        //GSMTest.Test();
        //GSMCallHistoryTest.Test();
        //Console.WriteLine(MobilePhoneComponents.GSM.IPhone4S);
    }
}
