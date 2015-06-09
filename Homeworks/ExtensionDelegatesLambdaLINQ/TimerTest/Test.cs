using System;
using System.Threading;
using Timer;

public class Test
{
    public static void TimerCallback(object obj)
    {
        Console.WriteLine(DateTime.Now);
        GC.Collect();
    }

    internal static void Main()
    {
        // v.1
        System.Threading.Timer timer = new System.Threading.Timer(TimerCallback, null, 0, 500);
        Console.ReadLine();

        // v.2
        TimerClass myTimer = new TimerClass();
        ////myTimer.TimerChanged += delegate(object sender, EventArgs e) { Console.WriteLine(DateTime.Now); };
        myTimer.TimerChanged += delegate(object sender, TimerChangedEventArgs e) { Console.WriteLine(e.TimeNow); };
        myTimer.Run();
    }
}
