using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherTasks
{
    class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static CancellationToken cancellationToken = cancellationTokenSource.Token;
        static void Main(string[] args)
        {
            var countdownEvent = new CountdownEvent(10);

            var fileProducer = new FileProducer();
            var fileConsumer = new FileConsumer(countdownEvent, token);

            string path = @"D:\TestFolder2";

            Task.Factory.StartNew(() =>
            {
                fileProducer.MonitorFolder(path);
            }, cancellationToken);

            var task = Task.Factory.StartNew(() =>
            {
                fileConsumer.Consume();
            }, cancellationToken);

            countdownEvent.Wait();
            cancellationTokenSource.Cancel();

            PrintResults();

            Console.ReadLine();

        }

        private static void PrintResults()
        {
            FileManager.ProcessedFiles.Select(i => $"{i.Key}|===> {i.Value}").ToList().ForEach(Console.WriteLine);
        }
    }
}
