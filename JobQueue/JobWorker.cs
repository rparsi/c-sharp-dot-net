using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MyConsoleApp.NumberProcessing;

namespace MyConsoleApp.JobQueue
{
    public delegate void JobWorkerCallback(string message);

    public class JobWorker: IJobWorker
    {
        public int[] NumberCollection { get; set; }
        private JobWorkerCallback jobWorkerCallback;
        private ShortestNeighbourProcessor processor;

        public JobWorker(int[] numbers, JobWorkerCallback jobWorkerCallback)
        {
            this.NumberCollection = numbers;
            this.jobWorkerCallback = jobWorkerCallback;
            this.processor = new ShortestNeighbourProcessor(numbers);
        }

        public void Run()
        {
            Console.WriteLine("Job worker is running");

            for (int index = 0;index < this.NumberCollection.Length;index++)
            {
                Console.WriteLine("value " + this.NumberCollection[index]);
            }

            Console.WriteLine("determining shortest neighbours...");

            try
            {
                FindShortestNeighboursResult result = this.processor.FindShortestNeighbours();

                if (result.Found)
                {
                    Console.WriteLine("numbers are...");
                    foreach (NumberElement numberElement in result.Numbers)
                    {
                        Console.WriteLine("number = " + numberElement.Number + ", index = " + numberElement.Index);
                    }
                }
            }
            catch (NoShortestNeighbourException exception)
            {
                Console.WriteLine(exception.ToString());
            }

            jobWorkerCallback?.Invoke("callback: job worker done");
        }
    }
}
