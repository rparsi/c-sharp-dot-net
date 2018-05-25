using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MyConsoleApp.JobQueue;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console App");
            //Console.ReadKey(true); // This code prompts the user to press any key and then pauses the program until a key is pressed.

            int[] data = { 5, 3, 10, 75, 4, 73, 41, 8 };
            //int[] data = { 5, 5 };
            JobWorker jobWorker = new JobWorker(data, new JobWorkerCallback(MyJobWorkerCallback));

            Thread jobConsumer = new Thread(new ThreadStart(jobWorker.Run));
            jobConsumer.Start();
        }

        public static void MyJobWorkerCallback(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }
    }
}
