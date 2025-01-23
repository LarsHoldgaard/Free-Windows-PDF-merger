namespace FreePdfMerger
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private ListView listViewPDFFiles;
        private ColumnHeader columnHeaderFilePath;
        private Button btnBrowse;
        private Button btnUp;
        private Button btnDown;
        private Button btnMerge;
        private Label lblTotalPages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listViewPDFFiles = new System.Windows.Forms.ListView();
            this.columnHeaderFilePath = new System.Windows.Forms.ColumnHeader();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.lblTotalPages = new System.Windows.Forms.Label();

            // 
            // listViewPDFFiles
            // 
            this.listViewPDFFiles.AllowDrop = true;
            this.listViewPDFFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                this.columnHeaderFilePath
            });
            this.listViewPDFFiles.FullRowSelect = true;
            this.listViewPDFFiles.GridLines = true;
            this.listViewPDFFiles.HideSelection = false;
            this.listViewPDFFiles.Location = new System.Drawing.Point(12, 12);
            this.listViewPDFFiles.Name = "listViewPDFFiles";
            this.listViewPDFFiles.Size = new System.Drawing.Size(560, 300);
            this.listViewPDFFiles.TabIndex = 0;
            this.listViewPDFFiles.UseCompatibleStateImageBehavior = false;
            this.listViewPDFFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFilePath
            // 
            this.columnHeaderFilePath.Text = "PDF File Path";
            this.columnHeaderFilePath.Width = 550;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 320);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(580, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(580, 41);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(580, 320);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(12, 360);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(78, 15);
            this.lblTotalPages.TabIndex = 5;
            this.lblTotalPages.Text = "Total Pages: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 395);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.listViewPDFFiles);
            this.Name = "Form1";
            this.Text = "Free PDF Merger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}