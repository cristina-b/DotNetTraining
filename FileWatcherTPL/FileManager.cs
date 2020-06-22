using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherTPL
{
    static class FileManager
    {        
        public static ConcurrentQueue<string> FileCollection = new ConcurrentQueue<string>();

        public static ConcurrentDictionary<string, string> ProcessedFiles = new ConcurrentDictionary<string, string>();
    }
}
