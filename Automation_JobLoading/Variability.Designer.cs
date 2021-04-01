namespace Automation_JobLoading
{
    partial class Variability
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
            this.lvrefver = new System.Windows.Forms.ListView();
            this.colrefver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvtarver = new System.Windows.Forms.ListView();
            this.coltarver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvvajob = new System.Windows.Forms.ListView();
            this.btnresult = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lvcom = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lvrefver
            // 
            this.lvrefver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colrefver});
            this.lvrefver.Location = new System.Drawing.Point(36, 36);
            this.lvrefver.Name = "lvrefver";
            this.lvrefver.Size = new System.Drawing.Size(215, 230);
            this.lvrefver.TabIndex = 0;
            this.lvrefver.UseCompatibleStateImageBehavior = false;
            // 
            // lvtarver
            // 
            this.lvtarver.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coltarver});
            this.lvtarver.Location = new System.Drawing.Point(313, 36);
            this.lvtarver.Name = "lvtarver";
            this.lvtarver.Size = new System.Drawing.Size(205, 230);
            this.lvtarver.TabIndex = 1;
            this.lvtarver.UseCompatibleStateImageBehavior = false;
            // 
            // coltarver
            // 
            this.coltarver.Width = 129;
            // 
            // lvvajob
            // 
            this.lvvajob.Location = new System.Drawing.Point(38, 296);
            this.lvvajob.Name = "lvvajob";
            this.lvvajob.Size = new System.Drawing.Size(488, 310);
            this.lvvajob.TabIndex = 2;
            this.lvvajob.UseCompatibleStateImageBehavior = false;
            // 
            // btnresult
            // 
            this.btnresult.Location = new System.Drawing.Point(451, 625);
            this.btnresult.Name = "btnresult";
            this.btnresult.Size = new System.Drawing.Size(75, 23);
            this.btnresult.TabIndex = 3;
            this.btnresult.Text = "Result";
            this.btnresult.UseVisualStyleBackColor = true;
            this.btnresult.Click += new System.EventHandler(this.btnresult_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(248, 373);
            this.dataGridView1.TabIndex = 4;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(303, 36);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(237, 373);
            this.dataGridView2.TabIndex = 5;
            // 
            // lvcom
            // 
            this.lvcom.Location = new System.Drawing.Point(98, 169);
            this.lvcom.Name = "lvcom";
            this.lvcom.Size = new System.Drawing.Size(381, 202);
            this.lvcom.TabIndex = 6;
            this.lvcom.UseCompatibleStateImageBehavior = false;
            this.lvcom.SelectedIndexChanged += new System.EventHandler(this.lvcom_SelectedIndexChanged);
            // 
            // Variability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 671);
            this.Controls.Add(this.lvcom);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnresult);
            this.Controls.Add(this.lvvajob);
            this.Controls.Add(this.lvtarver);
            this.Controls.Add(this.lvrefver);
            this.Name = "Variability";
            this.Text = "Variability";
            this.Load += new System.EventHandler(this.Variability_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvrefver;
        private System.Windows.Forms.ListView lvtarver;
        private System.Windows.Forms.ListView lvvajob;
        private System.Windows.Forms.Button btnresult;
        private System.Windows.Forms.ColumnHeader colrefver;
        private System.Windows.Forms.ColumnHeader coltarver;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ListView lvcom;
    }
}