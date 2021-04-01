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
	
    public class Inspection
    {
    	public void VATFile()
        {
    		Process[] process = Process.GetProcessesByName("KY-3030");
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }
            process = Process.GetProcessesByName("KSMARTVisApp");
            if (process.GetLength(0) == 0)
            {
            	process[0].Start();
            	Delay.Seconds(300);
            }
                // SPIGUI Simul 실행
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.SimulationApply.Click();
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.SimulationApplyCompleteInfo.WaitForAttributeContains(60000, "Text", "Complete");
                Delay.Seconds(3);
                
            }

    	
    	public void SPIGUION()
        {
    		
            try
            {
                //SPUGUI 실행 
                JobLoading_Repository.Instance.WinMCSLoader.MCSCompleteInfo.WaitForAttributeContains(80000,"Text","[GUI Init] Complete");
                JobLoading_Repository.Instance.VisionAnalysisToolVersion273.KY3030Start.Click();
                Delay.Seconds(3000);

                // Latest Job Open 창 > Yes 후 Close (Vision Error 미발생) 
                Delay.Duration(10000,false);
                JobLoading_Repository.Instance.SPIGUI.LatestOpenJob.OpenJobTitleBarInfo.WaitForAttributeContains(80000,"Text","Open");
                JobLoading_Repository.Instance.SPIGUI.LatestOpenJob.ButtonYes.Click();
                JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.Click();

                // User Login 창 Login
                JobLoading_Repository.Instance.FormOperator.TitleBarOperatorInfo.WaitForAttributeContains(60000, "Text", "Operator");
                Delay.Seconds(3);
                JobLoading_Repository.Instance.FormOperator.Supervisor1.Click();
                JobLoading_Repository.Instance.FormOperator.Password.Click();
                Keyboard.Press("21077421");
                JobLoading_Repository.Instance.FormOperator.ButtonOK.Click();
                //Log.LogWrite("---User Login Completed---");

            }
            catch(Exception ex)
            {
                //Log.LogWrite(ex.ToString());
                //Latest Job Open 창 > Yes - Vision Error 발생 
                //VSError();
            }
    	}
    	public void VSError()
    	{
    		/* SPI 실행 후 레포에 아이템 넣고 활성화하기 
    		if (Ranorex.Validate.Exists(JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.VisionErrorTitle,null,false)){
        		JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.VisionErrorTitle.Click();
	        	Delay.Milliseconds(2000);
	        	JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.VisionErrorTitle.Focus();
	        	JobLoading_Repository.Instance.SPIGUI.VisionErrorPopup.ButtonOK.Click();
	        	
	        	//report 수집 (cmd)
	        	repo.CWindowsSystem32CmdExe.CWindowsSystem32CmdExe.Click();
	        	Delay.Milliseconds(5000);
	        	//repo.CWindowsSystem32CmdExe.CWindowsSystem32CmdExe.PressKeys("{Return}");
	            //Delay.Milliseconds(2000);
	            
	           
	        	//에러팝업종료
	        	repo.VisionErrorReferenceError02041.ThunderRT6UserControlDC1.Click();
	        	Delay.Milliseconds(2000);
	        	
	        	//에러 발생 캡쳐??? 혹은 잡 네임 남기기?? 등 처리 
	        	//LogWrite("-------Vision Error 발생------");
	        	
	        	//초기 자동검사 진행회수 --> OK (error 상태변경된다) --> if문 위해 넣음
	        	repo.InputProductionQuantity.ThunderRT6UserControlDC.DoubleClick();
	            Delay.Milliseconds(5000);
	            
	            //KSmart 로그인 취소
	            repo.FormOperator.ThunderRT6UserControlDC1.Click();
	            Delay.Milliseconds(200);
	            repo.Kohyoung3DInspectionHMIForKY3030.Button확인.Click();
	            
	            //report 수집 (cmd)완료 시 아무키나 누르세요
	        	Delay.Milliseconds(25000);	
	        	repo.CWindowsSystem32CmdExe.CWindowsSystem32CmdExe.Focus();
	        	repo.CWindowsSystem32CmdExe.CWindowsSystem32CmdExe.DoubleClick();	
	        	repo.CWindowsSystem32CmdExe.CWindowsSystem32CmdExe.PressKeys("{Return}");
	            Delay.Milliseconds(2000);
	            //LogWrite("-------다음 잡 파일 실행------");
	            
	            //gui 종료
	            foreach (Process spigui in Process.GetProcesses()) {
        			if(spigui.ProcessName.ToUpper().StartsWith("KY-3030"))
	            		spigui.Kill();
        			}
    		}   */
    	}
    	
    	public void PCBSetting()
    	{
    		//pcb count setting 클릭
    		JobLoading_Repository.Instance.SPIGUI.SPIGUI.Setting.DoubleClick();
    		JobLoading_Repository.Instance.SPIGUI.SPIGUI.PCBQty.DoubleClick();
            Delay.Milliseconds(500);
            
            // pcb count unlimited 설정
            JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.UnlimitedInfo.Exists();
            
            if (JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.Enabled ) {
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.DoubleClick();
            }
            else{
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Unlimited.Click();
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.DoubleClick();     	
                }
           
                  // pcb count 100설정 3개이상(if), 이하(else)
                if (JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.SelectionText != null) {
	            	for (int i = 0; i <JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.SelectionLength; i++) {
	            			JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("{Right}");
	            		}
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("0");
	            	for (int i = 0; i < JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.SelectionLength-1; i++) {
	            			JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("{Left}");
	            			JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("{Delete}");
	            			}
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("100");
            	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.Click();
            }
	        	else{  // pcb count 100설정 3개 이하(else)
	        	 JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("0000");
	            	 for (int i = 0; i < JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.SelectionLength-1; i++) {
	            			JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("{Left}");
	            			}
	        	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.DoubleClick();
	        	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.Text.PressKeys("100");
	        	JobLoading_Repository.Instance.SPIGUI.InputProductionQuantity.ButtonOK.Click();
	        	}
    	
    	}
    	
        	
    	public void InsDone()
    	{
    		//자동검사 실행
            JobLoading_Repository.Instance.SPIGUI.SPIGUI.ButtonInsStart.DoubleClick();
            
            //Pass 눌러야할때 
            if (JobLoading_Repository.Instance.SPIGUI.SPIGUI.DEFECTInfo.Exists()) {
            	JobLoading_Repository.Instance.SPIGUI.SPIGUI.PASS.Click();
            	
            }
            
            //자동으로 자동검사 진행 될 때 
        
            
            //defect view 완료 시 종료 
            //Delay.Duration(300000,false); //자동검사 완료 시 확인방법?????????
        	/*if(Ranorex.Validate.Exists(JobLoading_Repository.Instance.SolderPaste3DInspectionSystemKoh.STOP,null,false)
        		||(Ranorex.Validate.Exists(JobLoading_Repository.Instance.SolderPaste3DInspectionSystemKoh.Graphic,null,false))
        	    ||(Ranorex.Validate.Exists(JobLoading_Repository.Instance.SolderPaste3DInspectionSystemKoh.STOP,null,false)))
        		{
        		foreach (Process spigui in Process.GetProcesses()) {
	            	if(spigui.ProcessName.ToUpper().StartsWith("KY-3030"))
	            		
	            		spigui.Kill();
        				}
   				 } */
            
    	}
            
	}
} 