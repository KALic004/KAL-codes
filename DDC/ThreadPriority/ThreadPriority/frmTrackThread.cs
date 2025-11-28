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

namespace ThreadPriority
{
    public partial class frmTrackThread: Form
    {
        Thread threadA, threadB, threadC, threadD;

        public frmTrackThread()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            threadA = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadB = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadC = new Thread(new ThreadStart(MyThreadClass.Thread1));
            threadD = new Thread(new ThreadStart(MyThreadClass.Thread1));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            threadA = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadB = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadC = new Thread(new ThreadStart(MyThreadClass.Thread2));
            threadD = new Thread(new ThreadStart(MyThreadClass.Thread2));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("-End of Thread-");
            lblStatus.Text = "-End of Thread-";
        }
    }
}
