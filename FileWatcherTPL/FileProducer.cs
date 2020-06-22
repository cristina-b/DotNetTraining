using System;
using System.IO;

namespace FileWatcherTPL
{
    class FileProducer
    {
        private FileSystemWatcher fileWatcher;

        public FileProducer()
        {
            fileWatcher = new FileSystemWatcher();
        }

        public void MonitorFolder(string path)
        {
            fileWatcher.Path = path;
            fileWatcher.Created += OnCreated;
            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            FileManager.FileCollection.Enqueue(e.FullPath);
            Console.WriteLine("File created: {0}", e.Name);
        }
    }
}
