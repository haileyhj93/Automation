/*
 * Created by Ranorex
 * User: T5810
 * Date: 2020-10-06
 * Time: 오후 3:52
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */

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

namespace Automation_JobLoading
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Converting : System.Windows.Forms.Form
	{
		public Converting()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();


		}

        Automation_JobLoading.Class.Common cm = new Automation_JobLoading.Class.Common();
        static Automation_JobLoading.Class.Setting st = new Automation_JobLoading.Class.Setting();
        Automation_JobLoading.Class.Log Log = new Automation_JobLoading.Class.Log();
        static string strJobPath = "";
        string strResultPath = Environment.CurrentDirectory + @"\Result\";
        static ArrayList jobList;
        
        PopupWatcher pwVisionError = new PopupWatcher();
        bool crashFlag = false;
        bool guiFirstFlag = false;
        
        private void DisplayJobList(string strJob)
        {
            if (System.IO.Directory.Exists(strJob))
            {
                
                foreach(var job in jobList)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(job.ToString());
                    lvJob.Items.Add(fi.Name);
                }
            }
            Log.LogWrite("Job List Display Completed!");
            
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
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
                //Automation_JobLoading.Module.VisionErrorWatch.Start(myPath);
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

        private void Run_Click(object sender, EventArgs e)
        {
            if (jobList == null)
            {
                WinForms.MessageBox.Show("Job이 존재하는 Folder를 선택해주세요.");
                return;
            }

            Log.LogWrite("---SPI Job Loading Automation Run Start!!!!!---");
            
            DirectoryInfo di = new DirectoryInfo(this.strResultPath);
            if (!di.Exists) Directory.CreateDirectory(this.strResultPath);
            StreamWriter sw = new StreamWriter(strResultPath + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv", false, Encoding.Unicode);
            sw.WriteLine("Job Names" + "\t" + "Job Convert" + "\t" + "Job Loading Result");

            //cm.SaveCSV(sw, lvJob);

            CEditor_JobConvert(sw);
//            cm.SPIGUION();
            SPIGUI_JobLoading(sw);
            WinForms.MessageBox.Show(new WinForms.Form() { WindowState = WinForms.FormWindowState.Maximized, TopMost = true},"Completed!");
        }

        private void CEditor_JobConvert(StreamWriter sw )
        {

            Log.LogWrite("---SPI Job Convert Start!!!!!---");
            cm.CEditorON();
            

            for (int i=0;i<jobList.Count;i++)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(jobList[i].ToString());
                    label1.Text = lvJob.Items[i].Text.Substring(0, lvJob.Items[i].Text.Length-4);
                    
                    JobLoading_Repository.Instance.EditComponentID.LoadJob.Click();
                    JobLoading_Repository.Instance.ComponentID.TextBox.Click();
                    JobLoading_Repository.Instance.ComponentID.TextBox.TextValue = "";

                    Delay.Seconds(2);
                    //Keyboard.Press(jobList[i].ToString());
                    JobLoading_Repository.Instance.ComponentID.TextBox.TextValue = jobList[i].ToString();
                    Delay.Seconds(2);
                    JobLoading_Repository.Instance.ComponentID.ButtonOpen.Click();
                    Delay.Seconds(5);

                    //bool jobPathError= Ranorex.Validate.AttributeContains(JobLoading_Repository.Instance.ComponentID.PopupMessageInfo, "Text", "try again.", "", false);
                    Ranorex.Core.RxPath temp = "/form[@processname='CEditor' and @class='#32770']/titlebar[@accessiblerole='TitleBar']";
                    bool jobPathError = Ranorex.Validate.Exists(temp, 5000, "try again.",  false);


                    //bool jobPathError = JobLoading_Repository.Instance.ComponentID.ComponentID.Valid;
                    if (jobPathError)
                    {
                        JobLoading_Repository.Instance.ComponentID.ButtonOK.Click();
                        Log.LogWrite("job path 입력 오류로 job load 재수행");
                        i = i - 1;
                        continue;
                    }

                    // C-Editor에서 Job Loading 완료까지 대기 
                    if (JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClass.Value == 28800)
                    {
                        Delay.Seconds(1);
                    }
                    else if(fi.Length> 104857600)
                    {
                        Duration timeout = Convert.ToInt32(fi.Length / 8);
                        JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(timeout, "Value", "29700");
                        Delay.Seconds(1);
                        JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(timeout, "Value", "29700");
                        Delay.Seconds(1);
                        if (JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClass.Value != 29700)
                        {
                            JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(timeout, "Value", "29700");
                        }
                    }
                    else
                    {
                        JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(600000, "Value", "29700");

                        Delay.Seconds(1);
                        JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(700000, "Value", "29700");
                        Delay.Seconds(3);
                        if (JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClass.Value != 29700)
                        {
                            JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(700000, "Value", "29700");
                        }
                    }
                    
                    Log.LogWrite("---"+jobList[i].ToString() + "_Job Load in C-Editor Completed!"+"---");
                    
                    JobLoading_Repository.Instance.EditComponentID.EditComponentIDTitleInfo.WaitForAttributeContains(60000, "Text", "Ver");
                    string job_ver = JobLoading_Repository.Instance.EditComponentID.EditComponentIDTitle.Text;

                    if (job_ver.Contains("File Ver 1.0"))
                    {
                        JobLoading_Repository.Instance.EditComponentID.Tools.Click();
                        JobLoading_Repository.Instance.CEditor.ConvertJobFileVersion.Click();
                        JobLoading_Repository.Instance.ComponentID.ButtonYes.Click();
                        // ButtonOK1 not found 처리 해야함 //
                        //Log.LogWrite("OK버튼찾기 시작");
                        while(!Ranorex.Validate.Exists(JobLoading_Repository.Instance.ComponentID.ComponentIDInfo,"Text", false))
                        {
                            Delay.Seconds(5);
                        }
                        JobLoading_Repository.Instance.ComponentID.ButtonOK.Click();
                        //JobLoading_Repository.Instance.ComponentID.ButtonOK1Info.WaitForExists(180000);
                        //Log.LogWrite("OK버튼찾기 완료");
                        //JobLoading_Repository.Instance.ComponentID.ButtonOK1.Click();
                        //Delay.Seconds(5);
                        if (JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClass.Value == 28800)
                        {
                            Delay.Seconds(1);
                        }
                        else
                        {
                            JobLoading_Repository.Instance.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(300000, "Value", "29700");
                        }

                        lvJob.Items[i].SubItems.Add("O");
                        
                       // cm.SaveCSV(sw, lvJob.Items[i]);
                        Log.LogWrite("---"+jobList[i].ToString() + "_ Job Convert Success!"+"---");
                    }
                    else if(job_ver.Contains("Ver 2.0"))
                    {
                        lvJob.Items[i].SubItems.Add("N/A");
                        //cm.SaveCSV(sw, lvJob.Items[i]);

                    }
                    /*
                    for (int timer = 0; timer <= 99999; timer++)
                    {
                        string tempJobName = "";
                        JobLoading_Repository.Instance.EditComponentID.StatusBar20WndClass.MoveTo("580;20");
                        tempJobName = cm.UC_chkTextType();
                        if (tempJobName.Contains("Job File Ver"))
                        {
                            refJobName[i]=tempJobName;
                        }
                        
                    }
                    */
                }
                catch (Exception ex)
                {
                    Log.LogWrite(ex.ToString());
                    lvJob.Items[i].SubItems.Add("Fail");

                }
            }
            
            
        }

        private void SPIGUI_JobLoading(StreamWriter sw)
        {


            //string loadedJobName = "";
            string currentJobName = "";
            

            for (int i = 0; i < jobList.Count; i++)
            {
                try
                {
                    label1.Text = lvJob.Items[i].Text.Substring(0, lvJob.Items[i].Text.Length - 4);
                    currentJobName = lvJob.Items[i].Text;
                    currentJobName = currentJobName.Substring(0, (currentJobName.Length) - 4);
                    Log.LogWrite("----SPI GUI Job Loading Start!!!----");
                    Process[] process = Process.GetProcessesByName("KY-3030");
                    
                    
                    if (process.GetLength(0) < 1)
                    {
                        Log.LogWrite("----SPIGUI ON----");
                        cm.SPIGUION();
                        guiFirstFlag = true;
                    }
                    Delay.Seconds(3);
                    while(!Ranorex.Validate.Exists(JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo, "Text", false))
                    {
                        //Log.LogWrite("----Open Icon Click1----");
                        JobLoading_Repository.Instance.SPIGUI.SPIGUI.OpenIcon.Click();
                        Delay.Seconds(3);
                    }
                    

                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.NormalLane2.Click();
                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane2.Click();
                    //Keyboard.Press(jobList[i].ToString());
                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane2.TextValue = jobList[i].ToString();
                    if (JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane2.TextValue != jobList[i].ToString())
                    {
                        JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane2.Click();
                        //Keyboard.Press(jobList[i].ToString());
                        JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane2.TextValue = jobList[i].ToString();
                    }

                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.SkipLoadingLane2.Click();

                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.NormalLane1.Click();
                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane1.Click();
                    //Keyboard.Press(jobList[i].ToString());
                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane1.TextValue = jobList[i].ToString();
                    if (JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane1.TextValue != jobList[i].ToString())
                    {
                        JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane1.Click();
                        //Keyboard.Press(jobList[i].ToString());
                        JobLoading_Repository.Instance.SPIGUI.LoadJobFile.JobPathLane1.TextValue = jobList[i].ToString();
                    }


                    JobLoading_Repository.Instance.SPIGUI.LoadJobFile.ButtonOK.Click();
                    
                    Log.LogWrite("--Job File Loading Start-- "+ currentJobName);
                    Delay.Seconds(3);
                    //JobLoading_Repository.Instance.SPIGUI.JobLoadProgressBar.ProgressBarInfo.WaitForNotExists(600000);
                    JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ProductionQuantityTitleInfo.WaitForExists(10000000);
                    //Log.LogWrite("--Quantity창 클릭1--");

                    /*
                      int counter = 0;
                                       while (crashFlag == false || counter < 60)
                                       {
                                           Delay.Seconds(1);
                                           counter++;
                                           WinForms.MessageBox.Show(counter.ToString());

                                       }

                                       Log.LogWrite("첫번째대기");
                                       Delay.Seconds(3);

                                       // job Loading 완료까지 대기
                                      System.IO.FileInfo fi = new System.IO.FileInfo(jobList[i].ToString());
                                       if (fi.Length > 104857600)
                                       {
                                           Duration timeout = Convert.ToInt32(fi.Length / 8);
                                           JobLoading_Repository.Instance.SPIGUI.JobLoadProgressBar.ProgressBarInfo.WaitForNotExists(timeout);
                                           Log.LogWrite("큰파일두번째대기");
                                           Delay.Seconds(30);
                                           Log.LogWrite("큰파일세번째대기");
                                       }
                                       else
                                       {
                                           JobLoading_Repository.Instance.SPIGUI.JobLoadProgressBar.ProgressBarInfo.WaitForNotExists(600000);
                                           Log.LogWrite("두번째대기");
                                           Delay.Seconds(30);
                                           JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo.WaitForNotExists(600000);
                                           Log.LogWrite("세번째대기");
                                       }

                                       Delay.Seconds(10);
                                       Log.LogWrite("대기끝");
                                       JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo.WaitForNotExists(600000);*/
                    // Job Loading 완료 후 정상 Loading 되었는지 확인
                    Delay.Seconds(3);
                    if (crashFlag)
                    {
                        crashFlag = false;
                        throw new Exception("Crash");
                    }
                    //Log.LogWrite("--첫번째 크래시 체크 완료--");
                    /*
                    if (crashFlag == false)
                    {
                        
                        lvJob.Items[i].SubItems.Add("Success");
                        cm.SaveCSV(sw, lvJob.Items[i]);
                        
                        Log.LogWrite(currentJobName + "_" + "Job Loading Succcess");
                        
                        if (currentJobName.Length > 20)
                        {
                            currentJobName.Split('_');
                            currentJobName = currentJobName.Substring(0, (currentJobName.Length) - 9);
                        }
                        
                        currentJobName = lvJob.Items[i].Text;
                        currentJobName = currentJobName.Substring(0, (currentJobName.Length) - 4);
                        for (int timer = 0; timer <= 99999; timer++)
                        {
                            JobLoading_Repository.Instance.SPIGUI.SPIGUI.LoadedJob.MoveTo("26;19");
                            loadedJobName = cm.UC_chkTextType();
                                Delay.Seconds(1);
                            //if (loadedJobName.Contains(currentJobName))
                            if(loadedJobName.Length > 0)
                            {
                                lvJob.Items[i].SubItems.Add("Success");
                                cm.SaveCSV(sw, lvJob.Items[i]);
                                Log.LogWrite(currentJobName + "_" + "Job Loading Succcess");
                                break;
                            }
                            else if (timer == 99999)
                            {
                                lvJob.Items[i].SubItems.Add("Fail");
                                cm.SaveCSV(sw, lvJob.Items[i]);
                                Log.LogWrite(currentJobName + "_" + "Job Loading Fail");

                                break;
                            }

                        }
                    }else
                    {
                        crashFlag = false;
                        throw new Exception("Crash");
                    }
                    */
                    JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.DoubleClick();
                    //Log.LogWrite("--quantity창 종료버튼 클릭--");
                    //JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo.WaitForNotExists(10000000);

                    // GUI 첫 실행일 경우 job loading 한번 더 동작
                    if (guiFirstFlag)
                    {
                        JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ProductionQuantityTitleInfo.WaitForExists(10000000);
                        Delay.Seconds(2);
                        JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.DoubleClick();
                        guiFirstFlag = false;
                    }
                    
                    Delay.Seconds(10);
                    
                    if (Ranorex.Validate.Exists("/form[@title='Error Report']", 100, "Text", false))
                    {
                        //Log.LogWrite("--crash if문 진입--");
                        if (crashFlag)
                        {
                            crashFlag = false;
                            
                            throw new Exception("Crash");
                        }
                    }
                    /*
                    while (!Ranorex.Validate.Exists(JobLoading_Repository.Instance.CrashUI.ErrorReport.ErrorReportInfo, "Text", false))
                    {
                        Delay.Seconds(1);

                        if (Ranorex.Validate.Exists(JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo, "Text", false))
                        {
                            Delay.Seconds(1);

                        }else
                        {
                            break;
                        }

                        if (crashFlag)
                        {
                            crashFlag = false;
                            throw new Exception("Crash");
                        }
                    }

    */
                    while (Ranorex.Validate.Exists(JobLoading_Repository.Instance.SPIGUI.LoadJobFile.LoadDualLaneJOBFileInfo, "Text", false))
                    {
                        Delay.Seconds(1);
                        
                        
                    }
                    

                    if (crashFlag)
                    {
                        crashFlag = false;
                        Log.LogWrite("--crash true--");
                        throw new Exception("Crash "+currentJobName);
                    }

                    if (i!= jobList.Count)
                    {
                        //Log.LogWrite("----Open Icon Click2----");
                        JobLoading_Repository.Instance.SPIGUI.SPIGUI.OpenIcon.Click();
                    }

                    lvJob.Items[i].SubItems.Add("Success");
                    cm.SaveCSV(sw, lvJob.Items[i]);
                    Log.LogWrite("---"+currentJobName + "_" + "Job Loading Succcess!!!---");
                    Delay.Seconds(3);

                }
                catch (Exception ex)
                {
                    Log.LogWrite(ex.ToString());
                    lvJob.Items[i].SubItems.Add("Fail");
                    cm.SaveCSV(sw, lvJob.Items[i]);
                    Log.LogWrite("---"+currentJobName + "_" + "Job Loading Fail---");
                    Process[] guiProcess = Process.GetProcessesByName("KY-3030");
                    if (guiProcess.GetLength(0) >0)
                    {
                        guiProcess[0].Kill();
                        Delay.Seconds(5);
                    }
                    guiProcess = Process.GetProcessesByName("KSMARTVisApp");
                    if (guiProcess.GetLength(0) > 0)
                    {
                        guiProcess[0].Kill();
                        Delay.Seconds(5);
                    }
                    Log.LogWrite("----Exception 끝----");
                }
            }
            //cm.SaveCSV(sw, lvJob);
            return;
        
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"D:\";
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                folderPathText.Text = dialog.FileName;
                strJobPath = folderPathText.Text;
                jobList = st.GetJobList(strJobPath);
                DisplayJobList(strJobPath);
                
                this.Refresh();
            }
        }
    }
}
