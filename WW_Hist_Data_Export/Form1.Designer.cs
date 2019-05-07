namespace WW_Hist_Data_Export
{
    partial class Form1
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
            this.btnExport = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.nmBatchSize = new System.Windows.Forms.NumericUpDown();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.chkSystemTags = new System.Windows.Forms.CheckBox();
            this.lblIndexLabel = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmBatchSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(28, 135);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(28, 109);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(203, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(237, 109);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // nmBatchSize
            // 
            this.nmBatchSize.Location = new System.Drawing.Point(28, 67);
            this.nmBatchSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmBatchSize.Name = "nmBatchSize";
            this.nmBatchSize.Size = new System.Drawing.Size(120, 20);
            this.nmBatchSize.TabIndex = 3;
            this.nmBatchSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nmBatchSize.ValueChanged += new System.EventHandler(this.NmBatchSize_ValueChanged);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(25, 96);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(61, 13);
            this.lblFolder.TabIndex = 4;
            this.lblFolder.Text = "Folder Path";
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.AutoSize = true;
            this.lblBatchSize.Location = new System.Drawing.Point(25, 51);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(80, 13);
            this.lblBatchSize.TabIndex = 5;
            this.lblBatchSize.Text = "Tags per Batch";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(234, 51);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 13);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Start Date";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(237, 67);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 7;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(464, 67);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 9;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(461, 51);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(52, 13);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "End Date";
            // 
            // chkSystemTags
            // 
            this.chkSystemTags.AutoSize = true;
            this.chkSystemTags.Location = new System.Drawing.Point(670, 67);
            this.chkSystemTags.Name = "chkSystemTags";
            this.chkSystemTags.Size = new System.Drawing.Size(115, 17);
            this.chkSystemTags.TabIndex = 11;
            this.chkSystemTags.Text = "Allow System Tags";
            this.chkSystemTags.UseVisualStyleBackColor = true;
            // 
            // lblIndexLabel
            // 
            this.lblIndexLabel.AutoSize = true;
            this.lblIndexLabel.Location = new System.Drawing.Point(475, 162);
            this.lblIndexLabel.Name = "lblIndexLabel";
            this.lblIndexLabel.Size = new System.Drawing.Size(33, 13);
            this.lblIndexLabel.TabIndex = 12;
            this.lblIndexLabel.Text = "Index";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(516, 162);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(35, 13);
            this.lblIndex.TabIndex = 13;
            this.lblIndex.Text = "label2";
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessing.Location = new System.Drawing.Point(27, 160);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(350, 73);
            this.lblProcessing.TabIndex = 17;
            this.lblProcessing.Text = "Processing";
            this.lblProcessing.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(478, 179);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(92, 13);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "xxxx-xx-xx xx:xx:xx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.lblIndexLabel);
            this.Controls.Add(this.chkSystemTags);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblBatchSize);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.nmBatchSize);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnExport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nmBatchSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.NumericUpDown nmBatchSize;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.CheckBox chkSystemTags;
        private System.Windows.Forms.Label lblIndexLabel;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Label lblDate;
    }
}

