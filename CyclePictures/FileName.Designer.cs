namespace CyclePictures
{
    partial class FileName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileName));
            this.label1 = new System.Windows.Forms.Label();
            this.CopyToC = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CopyToC
            // 
            this.CopyToC.Location = new System.Drawing.Point(12, 78);
            this.CopyToC.Name = "CopyToC";
            this.CopyToC.Size = new System.Drawing.Size(98, 23);
            this.CopyToC.TabIndex = 1;
            this.CopyToC.Text = "Copy to Clipboard";
            this.CopyToC.UseMnemonic = false;
            this.CopyToC.UseVisualStyleBackColor = true;
            this.CopyToC.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.Location = new System.Drawing.Point(129, 78);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(98, 23);
            this.OpenFolder.TabIndex = 2;
            this.OpenFolder.Text = "Open Folder";
            this.OpenFolder.UseVisualStyleBackColor = true;
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // FileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 113);
            this.Controls.Add(this.OpenFolder);
            this.Controls.Add(this.CopyToC);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileName";
            this.Text = "FileName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CopyToC;
        private System.Windows.Forms.Button OpenFolder;
    }
}