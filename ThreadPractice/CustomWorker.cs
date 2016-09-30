using System;
using System.Threading;

namespace ThreadPractice
{
    public class CustomWorker
    {
        private string Id;
        private string message;
        private int waitTime;
        CustomWorkerCallBack callBack;


        public CustomWorker(string id, string m, CustomWorkerCallBack cb, int wt = 1000)
        {
            Id = id;
            message = m;
            waitTime = wt;
            callBack = cb;
        }

        public void Run()
        {
            Thread.Sleep(waitTime);
            Console.WriteLine("  {0}   [WaitTime: {1}]", message, waitTime);
            callBack(waitTime);
        }

        private int DefaultCallBack() {
            return waitTime;
        }

        public delegate void CustomWorkerCallBack(int i);
    }
}
