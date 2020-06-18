using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace DotNet6
{
    class ThreadArraySum
    {
        private static volatile bool sum;

        static void Go()
        {
            //var arraySize = 50000000;
            int[] array = new int[50000000];

            Thread t = new Thread(ThreadArraySum.BuildAnArray);
            Thread t2 = new Thread(ThreadArraySum.BuildAnArray);
            t.Start(array.Length/2);            
            t.Join();
            t2.Start(array.Length/2);
            t2.Join();
        }

        public static void BuildAnArray(object data)
        {
            var sum = data.Sum();            
        }
    }
}
