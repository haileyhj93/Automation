using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation_JobLoading
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automation_JobLoading.Converting Cv = new Automation_JobLoading.Converting();
            Cv.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Automation_JobLoading.Inspection Is = new Automation_JobLoading.Inspection();
            Is.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Automation_JobLoading.Variability Vr = new Automation_JobLoading.Variability();
            Vr.Show();
        }
    }
}
