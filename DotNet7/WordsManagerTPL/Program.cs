using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WordsManagerTPL
{
    class Program
    {
        static void Main()
        {

            var path = @"C:\Users\cristina\source\repos\cristina-b\DotNetTraining\WordsManagerTPL\data\";
            var files = Directory.GetFiles(path);
           
            Parallel.ForEach(files, (file) =>
            {
                FileManager fileManager = new FileManager(Path.GetFullPath(file));
                fileManager.ProcessFile();
            });

        }
    }
}
