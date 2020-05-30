using System;
using System.Collections;
using System.Data;
using System.Linq;

namespace DotNet1
{
    class Exercises
    {
        /*
         *  Write a C# Sharp program that takes three letters as input and display them in reverse order.
         */
        public void Exercise1()
        {
            Stack s = new Stack();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter letter: ");
                s.Push(Console.ReadLine());
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(s.Pop());
            }

        }

        /*
         * Write a C# Sharp program that takes two numbers as input and perform an operation (+,-,*,x,/) on them and displays the result of that operation.
         */
        public void Exercise2()
        {
            int a, b = 0;
            string op;
            DataTable result = new DataTable();
            string[] operands = { "+", "-", "*", "/", "%" };

            Console.WriteLine("Input first number: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input operand: ");
            op = Console.ReadLine();

            Console.WriteLine("Input second number: ");
            b = Convert.ToInt32(Console.ReadLine());

            if (operands.Contains(op))
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, op, b, result.Compute(a + op + b, ""));
            }
            else
            {
                Console.WriteLine("Operand not permitted");
            }
        }

        /*
         * Write a C# Sharp program that takes a character as input and check the input (lowercase) is a vowel, a digit, or any other symbol
         */
        public void Exercise3()
        {
            string input;
            string[] vowels = { "a", "e", "i", "o", "u" };

            Console.WriteLine("Type a character: ");

            input = Console.ReadLine().ToLower();
            char code = Convert.ToChar(input);

            if (Char.IsDigit(code))
            {
                Console.WriteLine("It's a digit");
            }
            else if (vowels.Contains(input))
            {
                Console.WriteLine("It's a vowel");
            }
        }

        /*
         * 4. Write a C# Sharp program to accept the height of a person in centimeter and categorize the person according to their height.
         */
        public void Exercise4()
        {
            int height;

            Console.WriteLine("Height: ");
            height = Convert.ToInt32(Console.ReadLine());

            if (height < 150)
            {
                Console.WriteLine("It's a dwarf");
            }
            else if (height > 190)
            {
                Console.WriteLine("Very tall");
            }
            else
            {
                Console.WriteLine("Normal height");
            }
        }

        /*
         * Write a program in C# Sharp to display the n terms of even natural number and their sum
         */
        public void Exercise6()
        {
            int n, sum = 0;

            Console.WriteLine("N terms: ");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The even natural numbers: ");
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}", i * 2);
                sum += i * 2;
            }
            Console.WriteLine("Sum: {1}", n, sum);
        }

        /*
         * Write a C# Sharp program to read temperature in centigrade and display a suitable message according to temperature state below 
         */
        /*public void Exercise7()
        {
            int temperature = 0;

            Console.WriteLine("Temperature: ");
            temperature = Convert.ToInt32(Console.ReadLine());

            switch (temperature)
            {

            }
        }*/
    }
    
}
