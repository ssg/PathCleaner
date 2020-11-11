namespace PathCleaner
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "C:\\Program Files\\Something",
            "Missing path",
            "Missing path"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "C:\\Windows",
            "No executables"}, -1);
            this.problemList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cleanupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // problemList
            // 
            this.problemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.problemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.problemList.FullRowSelect = true;
            this.problemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.problemList.HideSelection = false;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.problemList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6});
            this.problemList.Location = new System.Drawing.Point(18, 38);
            this.problemList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.problemList.Name = "problemList";
            this.problemList.Size = new System.Drawing.Size(856, 476);
            this.problemList.TabIndex = 0;
            this.problemList.UseCompatibleStateImageBehavior = false;
            this.problemList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Path";
            this.columnHeader1.Width = 411;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Reason";
            this.columnHeader2.Width = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Problematic items in PATH:";
            // 
            // cleanupButton
            // 
            this.cleanupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cleanupButton.Location = new System.Drawing.Point(18, 526);
            this.cleanupButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cleanupButton.Name = "cleanupButton";
            this.cleanupButton.Size = new System.Drawing.Size(204, 45);
            this.cleanupButton.TabIndex = 4;
            this.cleanupButton.Text = "Remove Selected";
            this.cleanupButton.UseVisualStyleBackColor = true;
            this.cleanupButton.Click += new System.EventHandler(this.cleanupButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.cleanupButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 589);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.problemList);
            this.Controls.Add(this.cleanupButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Path Cleaner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView problemList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cleanupButton;
    }
}

