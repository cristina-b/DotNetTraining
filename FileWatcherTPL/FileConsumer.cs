using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileWatcherTPL
{
    class FileConsumer
    {
        private CountdownEvent countdownEvent;
        private CancellationToken cancellationToken;
        private Semaphore Semaphore;

        public FileConsumer(CountdownEvent countdownEvent, CancellationToken cancellationToken)
        {
            this.countdownEvent = countdownEvent;
            this.cancellationToken = cancellationToken;
            Semaphore = new Semaphore(1,4);
        }

        public void Consume()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (FileManager.FileCollection.Any())
                {
                    Semaphore.WaitOne();

                    FileManager.FileCollection.TryDequeue(out var filePath);

                    try
                    {
                        var fileContent = File.ReadAllText(filePath);
                        var fileName = Path.GetFileName(filePath);

                        FileManager.ProcessedFiles.TryAdd(fileName, fileContent);

                        this.countdownEvent.Signal();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        Semaphore.Release();
                    }
                }                
            }
        }

    }
}
