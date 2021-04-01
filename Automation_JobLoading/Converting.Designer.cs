/*
 * Created by Ranorex
 * User: T5810
 * Date: 2020-10-06
 * Time: 오후 3:52
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;

namespace Automation_JobLoading
{
	partial class Converting
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.Run = new System.Windows.Forms.Button();
            this.lvJob = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderPathText = new System.Windows.Forms.TextBox();
            this.selectFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(10, 440);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(685, 61);
            this.Run.TabIndex = 0;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // lvJob
            // 
            this.lvJob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvJob.FullRowSelect = true;
            this.lvJob.GridLines = true;
            this.lvJob.Location = new System.Drawing.Point(10, 61);
            this.lvJob.Name = "lvJob";
            this.lvJob.Size = new System.Drawing.Size(685, 360);
            this.lvJob.TabIndex = 1;
            this.lvJob.UseCompatibleStateImageBehavior = false;
            this.lvJob.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Job Name";
            this.columnHeader1.Width = 457;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Job Convert";
            this.columnHeader2.Width = 92;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Job Loading Result";
            this.columnHeader3.Width = 124;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(671, 430);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 7);
            label1.TabIndex = 2;
            label1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // folderPathText
            // 
            this.folderPathText.Location = new System.Drawing.Point(11, 16);
            this.folderPathText.Name = "folderPathText";
            this.folderPathText.Size = new System.Drawing.Size(549, 20);
            this.folderPathText.TabIndex = 3;
            // 
            // selectFolder
            // 
            this.selectFolder.Location = new System.Drawing.Point(567, 14);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(127, 24);
            this.selectFolder.TabIndex = 4;
            this.selectFolder.Text = "폴더 선택";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 511);
            this.Controls.Add(this.selectFolder);
            this.Controls.Add(this.folderPathText);
            this.Controls.Add(label1);
            this.Controls.Add(this.lvJob);
            this.Controls.Add(this.Run);
            this.Name = "MainForm";
            this.Text = "Automation_JobLoading";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}


        private System.Windows.Forms.Button Run;
        public System.Windows.Forms.ListView lvJob;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        static public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderPathText;
        private System.Windows.Forms.Button selectFolder;
    }
}
