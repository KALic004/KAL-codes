using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPriority
{
    class MyThreadClass
    {
        public static void Thread1()
        {
            for (int LoopCount = 0; LoopCount <= 2; LoopCount++)
            {
                Thread thread = Thread.CurrentThread;

                Console.WriteLine("Thread Name: " + thread.Name + " = " + LoopCount);
                Thread.Sleep(500);
            }
        }
        public static void Thread2()
        {
            for (int LoopCount = 0; LoopCount <= 5; LoopCount++)
            {
                Thread thread = Thread.CurrentThread;

                Console.WriteLine("Thread Name: " + thread.Name + " = " + LoopCount);
                Thread.Sleep(1500);
            }
        }
    }
}
