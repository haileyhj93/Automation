using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WinForms = System.Windows.Forms;
using Automation_JobLoading.Class;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using System.Diagnostics;

namespace Automation_JobLoading.Module
{
    public partial class VisionErrorWatch
    { 
        Automation_JobLoading.Class.Common cm = new Automation_JobLoading.Class.Common();
        Automation_JobLoading.Class.Log Log = new Automation_JobLoading.Class.Log();
        
        
        private void Init(Ranorex.Core.RxPath myPath)
        {
            // Your recording specific initialization code goes here.
            try
            {
               string imageFolderPath = Environment.CurrentDirectory + @"\Log\Error Image\" + System.DateTime.Today.ToString("yyyyMMdd") + @"\";
                DirectoryInfo di = new DirectoryInfo(imageFolderPath);
                string jobPath = "";
                string savePath = "";

                
                if (myPath.ToString().Contains("Vision "))
                {
                    jobPath = @"Vision Error_";
                    JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.VisionErrorTitle.Click();
                }
                else if(myPath.ToString().Contains("Error Report"))
                {
                    jobPath = @"Crash_";
                    JobLoading_Repository.Instance.CrashUI.ErrorReport.Self.Click();
                }else if(myPath.ToString().Contains("KSMARTVisionApp"))
                {
                    jobPath = @"KSMARTVisionApp Crash_";
                    JobLoading_Repository.Instance.KSMARTVisionApplication.KSMARTVisionApplication.Click();
                }
                else if ( myPath.ToString().Contains("KSmart connection disconn"))
                {
                    jobPath = @"KSMARTVisionApp Crash_";
                    JobLoading_Repository.Instance.KSmartConnectionDisconnected.TitleBar.Click();
                }


                //string[] imageNames = jobPath.Split('\\');
                //string imageName = imageNames[imageNames.Length - 1];
                //imageName = imageName.Substring(0, imageName.Length - 4) + "_";
                
                if (di.Exists == false)
                {
                    di.Create();
                }

                Bitmap btMain = new Bitmap(WinForms.Screen.PrimaryScreen.Bounds.Width, WinForms.Screen.PrimaryScreen.Bounds.Height);
                using (Graphics g = Graphics.FromImage(btMain))
                {
                    g.CopyFromScreen(WinForms.Screen.PrimaryScreen.Bounds.X, WinForms.Screen.PrimaryScreen.Bounds.Y, 0, 0, btMain.Size, CopyPixelOperation.SourceCopy);
                    //Picture Box Display 
                    savePath = imageFolderPath + jobPath + System.DateTime.Now.ToString("yyyyMMddHHmmss")+"_" + Converting.label1.Text;
                    btMain.Save(savePath + @".png");
                }

                Delay.Seconds(3);
                if (myPath.ToString().Contains("Vision "))
                {
                    JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.ButtonOK.Click();
                }
                else if (myPath.ToString().Contains("Error Report"))
                {
                    JobLoading_Repository.Instance.CrashUI.ErrorReport.DumpSaveBtn.Click(Location.CenterLeft);
                    JobLoading_Repository.Instance.CrashUI.ErrorReportDetails.Export.Click();
                    JobLoading_Repository.Instance.CrashUI.SaveAs.InputPathText.Click();
                    JobLoading_Repository.Instance.CrashUI.SaveAs.InputPathText.TextValue = "";
                    //Keyboard.Press(imageFolderPath + imageName + System.DateTime.Now.ToString("yyyyMMddHHmmss"));
                    JobLoading_Repository.Instance.CrashUI.SaveAs.InputPathText.TextValue = savePath ;
                    JobLoading_Repository.Instance.CrashUI.SaveAs.ButtonSave.Click();
                    JobLoading_Repository.Instance.CrashUI.ErrorReportDetails.Close.Click();
                    JobLoading_Repository.Instance.CrashUI.ErrorReport.Close.Click();
                    if(Ranorex.Validate.Exists(JobLoading_Repository.Instance.CrashUI.ErrorReport.SelfInfo, "Text", false))
                    {
                        Process[] process = Process.GetProcessesByName("CrashSender1403");
                        if (process.GetLength(0) > 0)
                        {
                            process[0].Kill();
                            Delay.Seconds(5);
                        }
                    }
                    

                }else if(myPath.ToString().Contains("KSMARTVisionApp"))
                {

                    JobLoading_Repository.Instance.KSMARTVisionApplication.KSMARTVisionApplication.Click();
                    Keyboard.Press(WinForms.Keys.Escape);

                    cm.SPIGUION();
                }else if (myPath.ToString().Contains("KSmart connection disconn"))
                {
                    JobLoading_Repository.Instance.KSmartConnectionDisconnected.ReportButton.Click();
                    JobLoading_Repository.Instance.KSmartConnectionDisconnected.OKButton.Click();

                }


            }
            catch (Exception ex)
            {
                Log.LogWrite(ex.ToString());
                    
            }

           
        }
        
	
    
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }
}
}
