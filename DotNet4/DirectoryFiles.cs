using System;
using System.IO;
using System.Linq;

namespace DotNet4
{
    class DirectoryFiles
    {
        static void Main(string[] args)
        {
            try
            {
                var dir = @"D:\.NET";
                PrintDirectoryTree(dir, 6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintDirectoryTree(string directory, int level, string treeDisplay = "")
        {
            foreach (string f in Directory.GetFiles(directory))
            {
                Console.WriteLine(treeDisplay + Path.GetFileName(f));
            }

            foreach (string d in Directory.GetDirectories(directory))
            {
                Console.WriteLine(treeDisplay + "-" + Path.GetFileName(d));

                if (level > 0)
                {
                    PrintDirectoryTree(d, level - 1, treeDisplay + "  ");
                }
            }
        }
    }
}
