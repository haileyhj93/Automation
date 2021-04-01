using System;
using System.Collections.Generic;
using System.Drawing;
using WinForms = System.Windows.Forms;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Windows;

using Ranorex;
using System.Collections;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;

using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Automation_JobLoading
{
    public partial class Inspection : System.Windows.Forms.Form
    //public partial class Inspection : Form
    {
        
        Automation_JobLoading.Class.Log Log = new Automation_JobLoading.Class.Log();
        string strFilePath = @"D:\SPIAuto_hailey\Sim_List\";

        PopupWatcher pwVisionError = new PopupWatcher();
        bool crashFlag = false;
        bool guiFirstFlag = false;

        public Inspection()
        {
            InitializeComponent();         
        }
 
        private void Inspection_Load(object sender, EventArgs e)
        {
            //Sim List
            DirectoryInfo DI = new DirectoryInfo(strFilePath);
            if (DI.Exists)
            {
                DirectoryInfo[] CInfo = DI.GetDirectories();
                foreach (DirectoryInfo di in CInfo)
                {
                    WinForms.ListViewItem jlvi = new WinForms.ListViewItem(di.Name);
                    lvnorjob.Items.Add(jlvi);
                }
            }


            //Automation_JobLoading.Module.ConvertJob.Start();
            Log.LogWrite("---Automation Program Load---");

            Ranorex.Core.Reporting.TestReport.Setup(ReportLevel.None, null, false);
            try
            {

                pwVisionError.Watch("/form[@title~'Vision Error.*']", SaveErrorImage);
                pwVisionError.Watch("/form[@title='Error Report']", SaveErrorImage);
                pwVisionError.Watch("/form[@title~'Optional update delivery ']", SaveErrorImage);
                //pwVisionError.Watch("/ form[@title~'Input Production Quantity']", SaveErrorImage);
                pwVisionError.Watch("/form[@processname='KY-3030' and @class='#32770']", SaveErrorImage);
                pwVisionError.Watch("/form[@title='KSMARTVisionApplication']", SaveErrorImage);
                pwVisionError.Watch("/form[@title~'KSmart connection disconn']", SaveErrorImage);

                pwVisionError.Start();


            }
            catch (Exception ex)
            {
                Report.Error("Unexpected exception occurred: " + ex.ToString());

            }
            throw new NotImplementedException();
        }
        public void SaveErrorImage(Ranorex.Core.RxPath myPath, Ranorex.Core.Element myElement)
        {
            if (myPath.ToString().Contains("Error Report") || myPath.ToString().Contains("KSMARTVisionApp") || myPath.ToString().Contains("KSmart connection disconn"))
            {
                crashFlag = true;
                //Automation_JobLoading.Module.VisionErrorWatch.Start(myPath);
                Log.LogWrite("Save Error(Crash) Image Completed!");
            }
            else if (myPath.ToString().Contains("Vision Error"))
            {
                Automation_JobLoading.Module.VisionErrorWatch.Start();
                Log.LogWrite("Save Vision Error Image Completed!");
            }
            /*else if(myPath.ToString().Contains("Quantity"))
            {
                Delay.Seconds(1); 
                JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.DoubleClick();
                Log.LogWrite("quantity창 종료버튼 클릭");
                
            }*/
            else
            {
                myElement.As<Form>().Click();
                Keyboard.Press(WinForms.Keys.Escape);
            }

        }
        private void lvnorjob_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automation_JobLoading.Class.Common cm = new Automation_JobLoading.Class.Common();
            Automation_JobLoading.Class.Setting st = new Automation_JobLoading.Class.Setting();
            for (int i=0; i<=lvnorjob.SelectedItems.Count -1; i++)
            {
                cm.CheckGUI();
                Automation_JobLoadingRepository.Instance.VisionAnalysisToolVersion273.txtJob.Click("107;11");
                Keyboard.PrepareFocus(Automation_JobLoadingRepository.Instance.VisionAnalysisToolVersion273.txtJob);
                Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
                Keyboard.Press("{Delete}");

                Automation_JobLoadingRepository.Instance.VisionAnalysisToolVersion273.txtJob.TextValue = strFilePath + lvnorjob.SelectedItems[i].Text;
                Automation_JobLoadingRepository.Instance.VisionAnalysisToolVersion273.SimulationApply.Click();
                Delay.Seconds(15);
                st.SetFOREIGN_MATERIAL();

                st.SetRegistry();
                st.SetRegistry();
                Automation_JobLoadingRepository.Instance.VisionAnalysisToolVersion273.KY3030Start.Click();
            }
        }

       
    }
}
