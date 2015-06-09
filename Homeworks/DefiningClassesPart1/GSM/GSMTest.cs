namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GSMTest
    {
        public static void Test()
        {
            ////Create array of GSMs
            List<GSM> gsmColection = new List<GSM>();

            for (int i = 0; i < 5; i++)
            {
                gsmColection.Add(
                    new GSM(
                    "Galaxy " + i,
                    "Samsung",
                    i + 100m,
                    "Ivaylo Kostov",
                    new Battery("Removable", (i * 1) + 10, i, (i % 2) == 0 ? BatteryTypes.Li_Ion : BatteryTypes.NiCd),
                    new Display(i + 5.5m, i * 50000)));
            }

            ////Print GSMs
            foreach (var gsm in gsmColection)
            {
                Console.WriteLine(gsm);
            }

            ////Print static member iPhone
            Console.WriteLine(GSM.IPhone4S);
            Console.WriteLine();
        }
    }
}
