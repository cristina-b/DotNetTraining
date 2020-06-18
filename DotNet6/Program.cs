using System;

namespace DotNet6
{
    class Ex01
    {
        static void Go()
        {
            var arraySize = 50000000;

            var array = BuildAnArray(arraySize);

            var sum = 0;

            for(int i=0; i<array.Length; i++)
            {
                sum += array[i];
            }

            Console.WriteLine(sum);
        }

        public static int BuildAnArray(int size)
        {
            var array = new int[size];
            for(int i=0;i<array.Length;i++)
            {
                array[i] = i;
            }
            return array;
        }
    }
}
