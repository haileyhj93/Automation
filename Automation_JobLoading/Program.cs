/*
 * Created by Ranorex
 * User: T5810
 * Date: 2020-10-06
 * Time: 오후 3:52
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */

using Ranorex;
using Ranorex.Core.Testing;
using System;
using System.Windows.Forms;

namespace Automation_JobLoading
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
        /// <summary>
        /// Program entry point.
        /// </summary>
        /// 
        static Class.Log Log = new Class.Log();
        [STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            /*
            try
            {
                PopupWatcher pwVisionError = new PopupWatcher();
                Log.LogWrite("Return1");

                pwVisionError.Watch("/form[@title~'Vision Error.*']", SaveErrorImage);
                Log.LogWrite("Return2");

                pwVisionError.Start();
                Log.LogWrite("Return3");
                
            }
            catch (Exception e)
            {
                Report.Error("Unexpected exception occurred: " + e.ToString());
                
            }
            */

            
            
        }


    }
}
