using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Automation_JobLoading.Class
{
    class Setting
    {
        
        ArrayList jobList = new ArrayList();

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filPath);


        public ArrayList GetJobList(string strSFolder)
        {
            
            string[] strFiles = Directory.GetFiles(strSFolder);
            string[] strFolders = Directory.GetDirectories(strSFolder);
            

            foreach (string strFile in strFiles)
            {
                if (strFile.Contains(".mdb"))
                {
                    jobList.Add(strFile);
                    
                }
            }
            if(strFolders.Length > 0)
            {
                foreach (string strFolder in strFolders)
                {
                    GetJobList(strFolder);
                }
            }
           
            return jobList;

        }
        public void SetFOREIGN_MATERIAL()
        {
            string strIniPath = @"C:\KohYoung\KY-3030\KY3030.ini";
            WritePrivateProfileString("BASIC", "FOREIGN_MATERIA", "0", strIniPath);
        }
        public void SetRegistry()
        {
            string strRegPath = @"SOFTWARE\kohyoung\KSMART\Rs232Controller\Unit_1";
            string strRegPathSec = @"SOFTWARE\kohyoung\KSMART\Grabber\Unit_1";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(strRegPath, true);
            key.GetValue("RealHw");
            key.SetValue("RealHw", "FALSE", RegistryValueKind.String);

            RegistryKey keySec = Registry.LocalMachine.OpenSubKey(strRegPathSec, true);
            key.SetValue("RealHw", "FALSE", RegistryValueKind.String);
        }
    }
}
