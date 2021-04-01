using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_JobLoading.Class
{
    class Log
    {
        private string strFilePath = "";
        private string strDirPath = "";
        public Log()
        {
            this.strFilePath = Environment.CurrentDirectory + @"\Log\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            this.strDirPath = Environment.CurrentDirectory + @"\Log";
        }
        public Log(string str)
        {
            this.strFilePath = str + @"\Log\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            this.strDirPath = str + @"\Log";
        }
        public void LogWrite(string str)
        {
            string strTemp;
            DirectoryInfo di = new DirectoryInfo(this.strDirPath);
            FileInfo fi = new FileInfo(this.strFilePath);
            try
            {
                if (!di.Exists) Directory.CreateDirectory(this.strDirPath);
                if(!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(this.strFilePath))
                    {
                        strTemp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(strTemp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(this.strFilePath))
                    {
                        strTemp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(strTemp);
                        sw.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(this.strFilePath);
                sw.WriteLine(ex.ToString());
            }
        }
    }
}
