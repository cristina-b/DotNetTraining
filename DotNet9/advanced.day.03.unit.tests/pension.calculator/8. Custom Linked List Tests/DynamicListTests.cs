using System;
using Xunit;
using CustomLinkedList;
using Moq;

namespace CustomLinkedListTests
{
    public class DynamicListTests
    {        
        [Fact]
        public void AddNodeTest<T>()
        {
            DynamicList<string> myList = new DynamicList<string>();
            myList.Add("Ana");
            myList.Add("are");
            myList.Add("mere");

            string newNode = "Ciresel";
            
            myList.Add(newNode);
            Assert.True(myList.Contains(newNode));
        }

        [Fact]
        public void RemoveNodeTest<T>()
        {
            DynamicList<string> myList = new DynamicList<string>();
            myList.Add("Ana");
            myList.Add("are");
            myList.Add("mere");

            string newNode = "mere";            
            myList.Remove(newNode);

            Assert.False(myList.Contains(newNode));
        }

        [Fact]
        public void ListContainsNodeTest<T>()
        {
            DynamicList<string> myList = new DynamicList<string>();
            myList.Add("Ana");
            myList.Add("are");
            myList.Add("mere");

            string newNode = "are";
            Assert.True(myList.Contains(newNode));
        }

        [Fact]
        public void ListDoesNotContainNodeTest<T>()
        {
            DynamicList<string> myList = new DynamicList<string>();
            myList.Add("Ana");
            myList.Add("are");
            myList.Add("mere");

            string newNode = "Ciresel";
            Assert.False(myList.Contains(newNode));
        }        


    }
}
