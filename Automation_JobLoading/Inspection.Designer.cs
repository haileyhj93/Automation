namespace Automation_JobLoading
{
    partial class Inspection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvnorjob = new System.Windows.Forms.ListView();
            this.chJob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_run = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvnorjob
            // 
            this.lvnorjob.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chJob});
            this.lvnorjob.Location = new System.Drawing.Point(12, 34);
            this.lvnorjob.Name = "lvnorjob";
            this.lvnorjob.Size = new System.Drawing.Size(684, 427);
            this.lvnorjob.TabIndex = 0;
            this.lvnorjob.UseCompatibleStateImageBehavior = false;
            this.lvnorjob.View = System.Windows.Forms.View.Details;
            this.lvnorjob.SelectedIndexChanged += new System.EventHandler(this.lvnorjob_SelectedIndexChanged);
            // 
            // chJob
            // 
            this.chJob.Text = "JobName";
            this.chJob.Width = 681;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(621, 5);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 473);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.lvnorjob);
            this.Name = "Inspection";
            this.Text = "Inspection";
            this.Load += new System.EventHandler(this.Inspection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvnorjob;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.ColumnHeader chJob;
    }
}