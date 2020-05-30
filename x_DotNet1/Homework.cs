using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace DotNet1
{
    class Homework
    {
        /*
         *  remove duplicate characters from String.
         */
        public void homework1()
        {
            string str, result = "";

            Console.WriteLine("Type a string: ");
            str = Console.ReadLine();

            var hash = new HashSet<char>(str);

            foreach (char ch in hash)
            {
                result += ch;
            }
            Console.WriteLine("String without duplicates : " + result);
        }

        /*
         *  Given an unsorted array which has a number in the majority (a number appears more than 50% in the array/list), find that number
         */
        public void homework2()
        {
            int n, x, number = 0;
            int totalNr = 0;
            List<int> ulist = new List<int>();
            Console.WriteLine("Array size: ");
            n = x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Type the numbers: ");

            while (x-- > 0)
            {
                ulist.Add(Convert.ToInt32(Console.ReadLine()));
            }


            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (ulist[i] == ulist[j])
                    {
                        count++;
                    }
                }

                if (count > totalNr)
                {
                    totalNr = count;
                    number = ulist[i];
                }
            }

            if (totalNr > n / 2)
            {
                Console.WriteLine("The number is: " + number);
            }
            else
            {
                Console.WriteLine("No element appears more than 50 times");
            }
        }

        /*
         *  Count the frequency of chars in a string.
         */
        public void homework3()
        {
            string str;

            Console.WriteLine("Type a string: ");
            str = Console.ReadLine();

            var charFrequency = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (charFrequency.ContainsKey(ch))
                {
                    charFrequency[ch]++;
                }
                else
                {
                    charFrequency[ch] = 1;
                }
            }

            foreach (var KVPair in charFrequency)
            {
                Console.WriteLine("{0} appears {1} times", KVPair.Key, KVPair.Value);
            }
        }

        /*
         *  Write code to reverse a linked list, if you able to do it using loops, try to solve with recursion.
         */
        public void homework4()
        {
            int n = 0;
            LinkedList<String> list = new LinkedList<String>();

            Console.WriteLine("How many elements in the linked list?");
            n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine("Type the elements: ");
                for (int i = 0; i < n; i++)
                {
                    list.AddLast(Console.ReadLine());
                }

                //list.Reverse();
                var current = list.First;

                while (current.Next != null)
                {
                    var temp = current.Next;
                    list.Remove(temp);
                    list.AddFirst(temp.Value);
                }

                current = list.First;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }
        }

        /*
         * Recursion
         * Write code to reverse a linked list, if you able to do it using loops, try to solve with recursion.
         */
        public void homework4Recursive()
        {
            int n = 0;
            LinkedList<String> list = new LinkedList<String>();

            Console.WriteLine("How many elements in the linked list?");
            n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine("Type the elements: ");
                for (int i = 0; i < n; i++)
                {
                    list.AddLast(Console.ReadLine());
                }

                //list.Reverse();
                //ListNode newList = ReverseRecursive(list.First); //wrong?!
            }
        }

        public ListNode ReverseRecursive(ListNode current)
        {

            if (current == null || current.Next == null)
            {
                return current;
            }

            ListNode newHead = ReverseRecursive(current.Next);           
            current.Next.Next = current;
            current.Next = null;               
            return newHead;
        }

        /*
         * Write code to remove duplicates from an unsorted linked list.
         */
        public void homework5()
        {
            List<string> list = new List<String>();
            int n = 0;

            Console.WriteLine("How many elements in the linked list?");
            n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine("Type the elements: ");
                for (int i = 0; i < n; i++)
                {
                    list.Add(Console.ReadLine());
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    //if (j==i) continue;
                    if (j != i && list[i].Equals(list[j]))
                    {
                        list.RemoveAt(j);
                    }
                }
            }

            list.ForEach(i => Console.Write("{0} ", i));

        }

        /*
        * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
        * If the last word does not exist, return 0
        * Note: A word is defined as a character sequence consists of non-space characters only.
        * Example:
        * Input: "Hello World"
        * Output: 5
        */
        public void homework6()
        {
            int length = 0;
            Console.WriteLine("Type a sentece: ");
            string sentence = Console.ReadLine();
            sentence = sentence.Trim();
            Console.WriteLine(sentence);
            Console.WriteLine(sentence.Length);

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    length = 0;
                }
                else
                {
                    length++;
                }
            }

            Console.WriteLine(length);
        }

        public void homework6bis()
        {
            Console.WriteLine("Type a sentece: ");
            string sentence = Console.ReadLine();
            sentence = sentence.Trim();

            string[] words = sentence.Split(' ');

            Console.WriteLine(words.Last().Length);
        }

    }

}

