using System;

namespace ThreadPractice
{
    public static class CustomStaticWorker
    {
        public static string Name { get { return "Static Custom Thread"; } }

        private readonly static string message = "Running...";

        public static void Run()
        {
            Console.WriteLine("{0} Run Message: {1}", Name, message);
        }
    }
}
