using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsManagerTPL
{
    public static class WordFilter
    {
        //public static Dictionary<string, string> distinct = new BlockingCollection<string>(boundedCapacity: 10);

        public static List<string> WordsPerCategories(List<string> words, int firstCondition, int secondCondition)
        {
            return words
              .Where(word => word.Length >= firstCondition && word.Length <= secondCondition)
              .Distinct()
              .ToList();
        }

        public static int DistinctWords(List<string> words)
        {
            return words
                .Distinct()
                .Count();
              ;
        }

        public static List<string> SearchWord(List<string> words, string searchedWord)
        {
            //return words.Where(word => word.Contains(searchedWord)).ToList();
            return words.Where(word => word.Contains(searchedWord)).ToList();
        }
    }
}
