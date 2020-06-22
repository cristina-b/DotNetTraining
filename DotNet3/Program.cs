using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DotNet3
{
    class Program
    {
        public static void MathMethods()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            var result = numbers.Product();
            Console.WriteLine(result);

            result = numbers.Sum();
            Console.WriteLine(result);

            result = numbers.Min();
            Console.WriteLine(result);

            result = numbers.Max();
            Console.WriteLine(result);
        }

        public static void MyListDisplay()
        {
            MyList<string> myList = new MyList<string>();

            myList.Add(new string[] { "ana", "are", "mere", "ciresel", "vine", "si", "cere" });

            Console.WriteLine("MyList elements:");

            foreach (string str in myList)
            {
                Console.WriteLine(str);
            }
        }

        public static void OutOfRangeExample()
        {
            int number = 123;
            
            if(number < 5 || number > 100)
            {                
                throw new InvalidRangeException<int>("Out of range", 5, 100);
            }            
        }

        static void Main(string[] args)
        {
            //MyListDisplay();
            //TimerDelegate.DoSomething();
            //MathMethods();
            OutOfRangeExample();
        }

        
    }
}
