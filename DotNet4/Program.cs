using System;
using System.IO;
using System.Linq;

namespace DotNet4
{
    class Program
    {
        public static void printDirectoryTree()
        {
            try
            {
                var dir = @"D:\.NET";               
                DirectoryFiles.PrintDirectoryTree(dir, 6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Main()
        {
            printDirectoryTree();
            Console.WriteLine("Smooth Sentence: {0}", SmoothSentence.IsSmoothSentence("Marta appreciated deep perpendicular right trapezoids"));
        }
    }
}
