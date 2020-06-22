using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WordsManagerTPL
{
    public class FileManager
    {        
        public string FilePath;
        static int countWords;

        public FileManager(string filePath)
        {
            FilePath = filePath;
        }        

        public void ProcessFile()
        {
            List<string> words = File.ReadAllLines(FilePath).ToList();

            Parallel.Invoke(() =>
            {
                var count = WordFilter.DistinctWords(words);
                Console.WriteLine("count: {0}", count);
                Interlocked.Add(ref countWords, count);
                
            },  

            () =>
            {
                var str = WordFilter.SearchWord(words, "okonojevo");                
                /*foreach (string sr in str)
                {
                    Console.WriteLine(sr);
                }*/
            }, 

            () =>
            {
                var str = WordFilter.WordsPerCategories(words, 5, 10).Take(10);                
            },

            () =>
            {
                var str = WordFilter.WordsPerCategories(words, 1, 5).Take(10);                
            },

            () =>
            {
                var str = WordFilter.WordsPerCategories(words, 10, 15).Take(10);
                /*foreach (string sr in str)
                {
                    Console.WriteLine(sr);
                }*/

            }
            );            
        }

    }
}