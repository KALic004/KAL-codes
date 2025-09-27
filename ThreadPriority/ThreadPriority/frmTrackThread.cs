using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Then dito sa Form class
namespace ThreadPriority
{
    public partial class frmTrackThread: Form
    {
        //We initalize four threads
        Thread threadA, threadB, threadC, threadD;

        public frmTrackThread()
        {
            InitializeComponent();
        }

        //then dito sa click event
        private void button1_Click(object sender, EventArgs e)
        {
            //we have declared the 4 threads
            //that equal to a new thread with parameter of MyThreadClass,
            //then yung method Thread1 function
            threadA = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadB = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadC = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadD = new Thread(new ThreadStart(MyThreadClass.Thread1));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            //then Start the 4 threads
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            //then Join, para magstart sila all at once
            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            //After matapos ang Thread1, Thread 2 naman
            //same thing like Thread1 deniclare natin ang 4 threads
            //now with the method of Thread2 function
            threadA = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadB = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadC = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadD = new Thread(new ThreadStart(MyThreadClass.Thread2));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";
            
            //the difference ay may priotrity levels each thread
            threadA.Priority = System.Threading.ThreadPriority.Highest;
            threadB.Priority = System.Threading.ThreadPriority.Normal;
            threadC.Priority = System.Threading.ThreadPriority.AboveNormal;
            threadD.Priority = System.Threading.ThreadPriority.BelowNormal;

            //then Start the 4 threads
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            //then Join, para magstart sila all at once
            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            //After matapos ang Thread2 execution, mag chachange ang label status to End of Thread
            Console.WriteLine("-End of Thread-");
            lblStatus.Text = "-End of Thread-";
        }
    }
}
