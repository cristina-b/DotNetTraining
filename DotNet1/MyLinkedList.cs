using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet1
{
    class MyLinkedList
    {
        public ListNode First;

        /*
         * Recursion
         * Write code to reverse a linked list, if you able to do it using loops, try to solve with recursion.
         */

        public MyLinkedList()
        {
            this.First = null;
        }

        public void Add(int nodeData)
        {
            ListNode node = new ListNode(nodeData);

            if (this.First != null)
            {
                node.Next = First;
            }
            this.First = node;
        }

        public void homework4Recursive()
        {
            int n = 0;
            MyLinkedList list = new MyLinkedList();

            Console.WriteLine("How many elements in the linked list?");
            n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine("Type the elements: ");
                for (int i = 0; i < n; i++)
                {
                    list.Add(Console.ReadLine());
                }

                //list.Reverse();
                MyLinkedList first = list.First;
                ListNode newList = ReverseRecursive(list.First);

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

    }


    public class ListNode
    {

        public int data;
        public ListNode Next;

        public ListNode(int node)
        {
            data = node;
            Next = null;
        }
    }
}
