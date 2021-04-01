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
using System.Data.OleDb;

namespace Automation_JobLoading
{
    public partial class Variability : System.Windows.Forms.Form
    //public partial class Variability : Form  
    {
        string strFilePath = @"D:\SPIAuto_hailey\Sim_List\";
        //version (\\10.1.10.47\Version Control\04_SW_Version\SPI - Renewal\3. Hotfix\Vision\1.9.3\Release)
        string strRefverPath = @"S:\SPIVersion\Ref\";
        string strTarverPath = @"S:\SPIVersion\Tar\";
        string strMDBPath = @"C:\KohYoung\KY-3030\Data\";
        
        public Variability()
        {
            InitializeComponent();
        }

        private void Variability_Load(object sender, EventArgs e)
        {
            //VersionList
            DirectoryInfo DI_REF = new DirectoryInfo(strRefverPath);
            if (DI_REF.Exists)
            {
                foreach (var di in DI_REF.GetFiles())
                {
                    WinForms.ListViewItem rlvi = new WinForms.ListViewItem(di.Name);
                    lvrefver.Items.Add(rlvi);
                }
            }
            DirectoryInfo DI_TAR = new DirectoryInfo(strTarverPath);
            if (DI_REF.Exists)
            {
                foreach (var di in DI_TAR.GetFiles())
                {
                    WinForms.ListViewItem rlvi = new WinForms.ListViewItem(di.Name);
                    lvtarver.Items.Add(rlvi);
                }
            }

            //Sim List
            DirectoryInfo DI = new DirectoryInfo(strFilePath);
            if (DI.Exists)
            {
                DirectoryInfo[] CInfo = DI.GetDirectories();
                foreach (DirectoryInfo di in CInfo)
                {
                    WinForms.ListViewItem jlvi = new WinForms.ListViewItem(di.Name);
                    lvvajob.Items.Add(jlvi);
                }
            }

        }

        private void btnresult_Click(object sender, EventArgs e)
        {
            //dmb 비교
            //var dateMDB = System.DateTime.Now.ToString("yyyy" + "\\"+ "MM");
            var dateyyyy = System.DateTime.Now.ToString("yyyy");
            var datemm = System.DateTime.Now.ToString("MM");
            var dateMDB = dateyyyy + "\\" + datemm;

            var PADPath = strMDBPath + dateMDB + "\\0001.mdb";   //0001.mdb
            var PCBPath = strMDBPath + dateMDB + "\\202103.mdb";// "\\+'dateyyyy'+'datemm'+.mdb"; 202103.mdb


            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + PADPath);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            conn.Open();

            //Table Join - Barcode(버전 구분) + 검사 시간&PADID(정렬) 
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();


            string sql = @"SELECT a.IDNO,PadID,PCBName,BarCode,STIME,SIzeX FROM PadResult a inner join [" + PCBPath + "].[PCBRESULT] b on  a.IDNO =  b.IDNO where BarCode = '4.10.2.2' order by STIME asc, PadID asc";
            string sql2 = @"SELECT a.IDNO,PadID,PCBName,BarCode,STIME,SIzeX FROM PadResult a inner join [" + PCBPath + "].[PCBRESULT] b on  a.IDNO =  b.IDNO where BarCode = '4.10.2.3' order by STIME asc, PadID asc ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            OleDbDataAdapter adapter2 = new OleDbDataAdapter(sql2, conn);

            adapter.Fill(dt);
            adapter2.Fill(dt2);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;

            //데이터 테이블 비교 
            DataTable result = new DataTable();
            
            //WinForms.ListViewItem lv_res = new WinForms.ListViewItem();
            for (int i = 0; i < dt.Rows.Count; i++) //IDNO,PCBID 다음값부터 진행 
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString() != dt2.Rows[i][j].ToString())
                    {


                        //lv_res.SubItems.Add(dt.Rows[j].ToString());
                        //lv_res.SubItems.Add(dt2.Rows[j].ToString());

                        result.Rows.Add(dt.Rows[i][j].ToString(), dt2.Rows[i][j].ToString());
                        ///result.Rows.Add(dt2.Rows[i][j].ToString());
                        //WinForms.MessageBox.Show(result.Rows.ToString());
                        //lv_res.Text = dt2.Rows[i][j].ToString();
                        //WinForms.MessageBox.Show(lv_res.Text); 

                        //lv_res.Text = dt.Rows[i][j].ToString(); 
                        //WinForms.MessageBox.Show(lv_res.Text);

                       
                    }
                }
                //lvcom.Items.Add(result);
            }

            

            /*
            //데이터 테이블 비교 
            for (int i = 0; i < dt.Rows.Count; i++) //IDNO,PCBID 다음값부터 진행 
            {
                WinForms.ListViewItem lv_res = new WinForms.ListViewItem();

                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString() != dt2.Rows[i][j].ToString())
                    {

                        //lv_res.SubItems.Add(dt.Rows[j].ToString());
                        //lv_res.SubItems.Add(dt2.Rows[j].ToString());
                        lv_res.Text = dt.Rows[i][j].ToString();
                        lv_res.Text = dt2.Rows[i][j].ToString(); 
                        //WinForms.MessageBox.Show(lv_res.Text); 

                        //lv_res.Text = dt.Rows[i][j].ToString(); 
                        //WinForms.MessageBox.Show(lv_res.Text);


                    }
                }
                lvcom.Items.Add(lv_res);

            } */



            /*          //Table Join - Barcode(버전 구분) + 검사 시간&PADID(정렬) 
                      using (DataTable dt = new DataTable())
                      {
                          //@"SELECT PadID, SizeX, SizeY, Result,BRDir, Volume, Height, Area, OffsetX, OffsetY FROM PadResult
                          //WHERE PadID IN (SELECT PadID FROM PadResult GROUP BY PadID HAVING COUNT(*) > 1   
                          string sql = @"SELECT a.IDNO,PadID,PCBName,BarCode,STIME FROM PadResult a inner join [" + PCBPath + "].[PCBRESULT] b on  a.IDNO =  b.IDNO where BarCode = '4.10.2.2' order by STIME asc, PadID asc";


                          //string sql = @"SELECT [PCBRESULT].[IDNO] FROM [" + PCBPath + "].[PCBRESULT]";  //pcbresult 가져오기 성공 
                          //string sql =  @"SELECT a.IDNO, b.IDNO ,PCBName FROM PadResult a, [" + PCBPath + "].[PCBRESULT] b where  a.IDNO =  b.IDNO" //통합 성공
                          //string sql = @"SELECT * FROM PadResult a inner join [" + PCBPath + "].[PCBRESULT] b on  a.IDNO =  b.IDNO"  //join 성공 


                          using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                          {

                              adapter.Fill(dt);
                          }
                          dataGridView1.DataSource = dt;



                      }
                      using (DataTable dt2 = new DataTable()) {
                          string sql2 = @"SELECT a.IDNO,PadID,PCBName,BarCode,STIME FROM PadResult a inner join [" + PCBPath + "].[PCBRESULT] b on  a.IDNO =  b.IDNO where BarCode = '4.10.2.3' order by STIME asc, PadID asc ";
                          using (OleDbDataAdapter adapter2 = new OleDbDataAdapter(sql2, conn))
                          {

                              adapter2.Fill(dt2);
                          }
                          dataGridView2.DataSource = dt2;

          */




        }
    

        private void lvcom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
