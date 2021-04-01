using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.Runtime.InteropServices; //나스연동용 추가
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace Automation_JobLoading.Module
{
    public partial class NormalJob
    {
        
        [DllImport("user32.dll")]
		static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        const uint MOUSEMOVE = 0x0001;      // 마우스 이동
        const uint ABSOLUTEMOVE = 0x8000;   // 전역 위치
        const uint LBUTTONDOWN = 0x0002;    // 왼쪽 마우스 버튼 눌림
        const uint LBUTTONUP = 0x0004;      // 왼쪽 마우스 버튼 떼어짐
        const uint RBUTTONDOWN = 0x0008;    // 오른쪽 마우스 버튼 눌림
        const uint RBUTTONUP = 0x00010;      // 오른쪽 마우스 버튼 떼어짐

        public void VAsetting()
        {
            //테스트용
            // Latest Job Open 창 > Yes 후 Close (Vision Error 미발생) 
                Delay.Duration(30000,false);
                //JobLoading_Repository.Instance.SPIGUI.SPIGUI.SIMULATIONInfo.WaitForAttributeContains(60000,"Text","SIMULATION");
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
                  
            
                  
                  //자동검사 실행
            JobLoading_Repository.Instance.SPIGUI.SPIGUI.ButtonInsStart.DoubleClick();
            
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

        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

    }
}
