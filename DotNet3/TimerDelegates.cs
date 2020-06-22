using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace DotNet3
{    
    class TimerDelegate
    {
        private static Timer timer;

        private static void PrintSomething(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("tic tac {0}", e.SignalTime);
        }

        public static void DoSomething()
        {
            Console.WriteLine("tic tac");
            timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += PrintSomething;
            timer.AutoReset = true;
            timer.Enabled = true;
            Console.WriteLine("waiting... ");
            Console.ReadLine();
        }
    }
}
