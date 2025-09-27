using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//This is a Thread tracking program
//na nagdedemonstrate paano ang multiple threads magrun at the same time 
//and paano naaffectohan ang execution when may priority levels 
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
