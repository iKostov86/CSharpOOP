namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            GSM gsm = new GSM(
                "Lumia 800",
                "Nokia",
                400m,
                "Ivaylo Kostov",
                new Battery("A", 15, 4, BatteryTypes.Li_Ion),
                new Display(4.5m, 16000));

            for (int i = 0; i < 5; i++)
            {
                gsm.AddCall(new Call("+359088" + i.ToString(), (uint)(120 + (i * 3))));
            }

            gsm.AddCall(new Call("Diana Pamporova", 425));
            Call longestCall = new Call();

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call);
                if (longestCall.Duration < call.Duration || longestCall.Duration == null)
                {
                    longestCall = call;
                }
            }

            Console.WriteLine("Toatal cost is: {0:F5}$", gsm.CalculateTotalCost());

            gsm.DeleteCall(longestCall);

            Console.WriteLine("Toatal cost is: {0:F5}$", gsm.CalculateTotalCost());

            gsm.ClearCallHistory();

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine(call);
            }

            Console.WriteLine();

            Console.WriteLine(gsm);
            GSM g1 = gsm;
            Console.WriteLine(g1);
            GSM g2 = gsm.ShallowCopy();
            Console.WriteLine(g2);
            GSM g3 = gsm.DeepCopy();
            Console.WriteLine(g3);
        }
    }
}
