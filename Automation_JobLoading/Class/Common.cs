using Ranorex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace Automation_JobLoading.Class
{
    class Common
    {
        string strCeditorPath = @"C:\kohyoung\KY-3030\CEditor.exe";
        string strVisAppPath = @"C:\KohYoung\KSMART\KSMARTVisApp.exe";
        Class.Log Log = new Class.Log();

        public void CEditorON()
        {
            Process[] process = Process.GetProcessesByName("CEditor");
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }
            Process.Start(strCeditorPath);
            JobLoading_Repository.Instance.FormOperator.Supervisor1.Click();
            JobLoading_Repository.Instance.FormOperator.Password.Click();
            Keyboard.Press("21077421");
            JobLoading_Repository.Instance.FormOperator.ButtonOK.Click();
        }
        
        //VisionAnalysis tool 실행 & KSMARTVisApp 강제 실행 
        string strVATPath = @"C:\Kohyoung\KY-3030\Vision\VisionAnalysisTool.exe";
      

        public void SPIGUION()
        {

            Process[] process = Process.GetProcessesByName("KY-3030.exe");
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }
            //process = Process.GetProcessesByName("KSMARTVisApp");
            //if (process.GetLength(0) > 0)
            //{
            //    process[0].Kill();
            //}


            try
            {
                // SPIGUI Simul 실행
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.SimulationApply.Click();
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.SimulationApplyCompleteInfo.WaitForAttributeContains(60000, "Text", "Complete");
                Delay.Seconds(3);
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.KY3030Start.Click();


                // Latest Job Open 창 Close
                Delay.Seconds(3);
                JobLoading_Repository.Instance.SPIGUI.LatestOpenJob.ButtonNo.Click();
                //Log.LogWrite("Latest Open Job창 Closed");

                // User Login 창 Login
                JobLoading_Repository.Instance.FormOperator.TitleBarOperatorInfo.WaitForAttributeContains(60000, "Text", "Operator");
                Delay.Seconds(3);
                JobLoading_Repository.Instance.FormOperator.Supervisor1.Click();
                JobLoading_Repository.Instance.FormOperator.Password.Click();
                Keyboard.Press("21077421");
                JobLoading_Repository.Instance.FormOperator.ButtonOK.Click();
                Log.LogWrite("---User Login Completed---");

            }
            catch(Exception ex)
            {
                Log.LogWrite(ex.ToString());
            }
            
        }
        
       
        

        public string UC_chkTextType()
        {
            System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;
            AutomationElement element = AutomationElement.FromPoint(new System.Windows.Point(mouse.X, mouse.Y));
            if (element == null)
            {
                Validate.Fail();
            }
            string txtName = element.Current.Name;
            return txtName;
        }

        
        public void SaveCSV(StreamWriter sw, ListViewItem job)
        {

            foreach (ListViewItem.ListViewSubItem subitem in job.SubItems)
            {
                sw.Write(subitem.Text + "\t");
            }
            sw.WriteLine("");
            sw.Flush();

        }
        
        public void SaveCSV(StreamWriter sw, ListView listView)
        {
            foreach(ListViewItem job in listView.Items)
            {
                foreach (ListViewItem.ListViewSubItem subitem in job.SubItems)
                {
                    sw.Write(subitem.Text + "\t");
                }
                sw.WriteLine("");
            }
            
            
            sw.Flush();

        }
        public void CheckGUI()
        {
            Process[] process = Process.GetProcessesByName("KY-3030.exe");
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }
        }
        public void ChkVisionApp()
        {
            Process[] process = Process.GetProcessesByName("KSMARTVisApp.exe");
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }
            Process.Start(strVisAppPath);
        }
    }
}
