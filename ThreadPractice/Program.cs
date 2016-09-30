using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPractice
{
    class Program
    {
        static List<int> timestamps = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine(":: STARTING APPLICATION.\n");

            Random rand = new Random();
            List<CustomWorker> workerList = new List<CustomWorker>();
            CustomWorker.CustomWorkerCallBack defaultCallBack = new CustomWorker.CustomWorkerCallBack(SaveRandWaitTime);
            workerList.Add(new CustomWorker("Worker1", "Worker 1 Running...", defaultCallBack, rand.Next(1, 2000)));
            workerList.Add(new CustomWorker("Worker2", "Worker 2 Running...", defaultCallBack, rand.Next(1, 2000)));
            workerList.Add(new CustomWorker("Worker3", "Worker 3 Running...", defaultCallBack, rand.Next(1, 2000)));
            workerList.Add(new CustomWorker("Worker4", "Worker 4 Running...", defaultCallBack, rand.Next(1, 2000)));
            workerList.Add(new CustomWorker("Worker5", "Worker 5 Running...", defaultCallBack, rand.Next(1, 2000)));
            workerList.Add(new CustomWorker("Worker6", "Worker 6 Running...", defaultCallBack, rand.Next(1, 2000)));

            // Create threads
            List<Thread> threadList = new List<Thread>();
            foreach (var worker in workerList)
            {
                threadList.Add(new Thread(worker.Run));
            }

            // Start threads
            threadList.ForEach(t => t.Start());

            // Join threads
            threadList.ForEach(t => t.Join());
            Console.WriteLine("\n:: THREAD FINISHED.\n");

            Console.WriteLine("  TimeStamps recorded were: {0}.", string.Join<int>(", ", timestamps));

            Console.WriteLine("\n:: ENDING APPLICATION.\n");
        }

        static void SaveRandWaitTime(int i) {
            timestamps.Add(i);
        }
    }
}
