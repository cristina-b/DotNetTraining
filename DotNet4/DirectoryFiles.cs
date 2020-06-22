using System;
using System.IO;
using System.Linq;

namespace DotNet4
{
    static class DirectoryFiles
    {        
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
