﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace Automation_JobLoading.Module
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The ConvertJob recording.
    /// </summary>
    [TestModule("bfbea05a-315d-4cd3-9756-b5a16af76b39", ModuleType.Recording, 1)]
    public partial class ConvertJob : ITestModule
    {
        /// <summary>
        /// Holds an instance of the Automation_JobLoading.JobLoading_Repository repository.
        /// </summary>
        public static Automation_JobLoading.JobLoading_Repository repo = Automation_JobLoading.JobLoading_Repository.Instance;

        static ConvertJob instance = new ConvertJob();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConvertJob()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static ConvertJob Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.0")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.0")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FormOperator.Supervisor1' at 36;45.", repo.FormOperator.Supervisor1Info, new RecordItemIndex(0));
            //repo.FormOperator.Supervisor1.Click("36;45");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Down item 'FormOperator.Password' at 22;4.", repo.FormOperator.PasswordInfo, new RecordItemIndex(1));
            //repo.FormOperator.Password.MoveTo("22;4");
            //Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Up item 'FormOperator.Password' at 33;12.", repo.FormOperator.PasswordInfo, new RecordItemIndex(2));
            //repo.FormOperator.Password.MoveTo("33;12");
            //Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FormOperator.ButtonOK' at 49;7.", repo.FormOperator.ButtonOKInfo, new RecordItemIndex(3));
            //repo.FormOperator.ButtonOK.Click("49;7");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Down item 'ComponentID.ShellView.ItemsView' at 621;37.", repo.ComponentID.ShellView.ItemsViewInfo, new RecordItemIndex(4));
            //repo.ComponentID.ShellView.ItemsView.MoveTo("621;37");
            //Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Up item 'ComponentID.ShellView.ItemsView' at 621;37.", repo.ComponentID.ShellView.ItemsViewInfo, new RecordItemIndex(5));
            //repo.ComponentID.ShellView.ItemsView.MoveTo("621;37");
            //Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'EditComponentID.Tools' at 15;3.", repo.EditComponentID.ToolsInfo, new RecordItemIndex(6));
            //repo.EditComponentID.Tools.Click("15;3");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'CEditor.ConvertJobFileVersion' at 135;11.", repo.CEditor.ConvertJobFileVersionInfo, new RecordItemIndex(7));
            //repo.CEditor.ConvertJobFileVersion.Click("135;11");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.ButtonYes1' at 57;12.", repo.ComponentID.ButtonYes1Info, new RecordItemIndex(8));
            //repo.ComponentID.ButtonYes1.Click("57;12");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.ButtonOK1' at 56;9.", repo.ComponentID.ButtonOK1Info, new RecordItemIndex(9));
            //repo.ComponentID.ButtonOK1.Click("56;9");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.ButtonOK1' at 56;9.", repo.ComponentID.ButtonOK1Info, new RecordItemIndex(10));
            //repo.ComponentID.ButtonOK1.Click("56;9");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Up item 'EditComponentID.LoadJob' at 6;9.", repo.EditComponentID.LoadJobInfo, new RecordItemIndex(11));
            //repo.EditComponentID.LoadJob.MoveTo("6;9");
            //Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Click item 'ComponentID.ButtonOpen' at 32;17.", repo.ComponentID.ButtonOpenInfo, new RecordItemIndex(12));
            //repo.ComponentID.ButtonOpen.Click(System.Windows.Forms.MouseButtons.Right, "32;17");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.ToolBar1001' at 490;9.", repo.ComponentID.ToolBar1001Info, new RecordItemIndex(13));
            //repo.ComponentID.ToolBar1001.Click("490;9");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.TextBox' at 97;3.", repo.ComponentID.TextBoxInfo, new RecordItemIndex(14));
            //repo.ComponentID.TextBox.Click("97;3");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'ComponentID.TextBox' at 108;7.", repo.ComponentID.TextBoxInfo, new RecordItemIndex(15));
            //repo.ComponentID.TextBox.Click("108;7");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Wait", "Waiting 5s for the attribute 'Text' to contain the specified value 'Job File Ver'. Associated repository item: 'EditComponentID.SomeListItem'", repo.EditComponentID.SomeListItemInfo, new RecordItemIndex(16));
            //repo.EditComponentID.SomeListItemInfo.WaitForAttributeContains(5000, "Text", "Job File Ver");
            
            //Report.Log(ReportLevel.Info, "Wait", "Waiting 5s for the attribute 'Value' to equal the specified value '29700'. Associated repository item: 'EditComponentID.ProgressBar20WndClass'", repo.EditComponentID.ProgressBar20WndClassInfo, new RecordItemIndex(17));
            //repo.EditComponentID.ProgressBar20WndClassInfo.WaitForAttributeEqual(5000, "Value", "29700");
            
            //Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>'try again.') on item 'ComponentID.PopupMessage'.", repo.ComponentID.PopupMessageInfo, new RecordItemIndex(18));
            //Validate.AttributeContains(repo.ComponentID.PopupMessageInfo, "Text", "try again.");
            //Delay.Milliseconds(0);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'VisionAnalysisToolVersion273.Text1035' at 77;6.", repo.VisionAnalysisToolVersion273.Text1035Info, new RecordItemIndex(19));
            //repo.VisionAnalysisToolVersion273.Text1035.Click("77;6");
            //Delay.Milliseconds(200);
            
            //Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'VisionAnalysisToolVersion273.Text1035' at 77;6.", repo.VisionAnalysisToolVersion273.Text1035Info, new RecordItemIndex(20));
            //repo.VisionAnalysisToolVersion273.Text1035.Click("77;6");
            //Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}