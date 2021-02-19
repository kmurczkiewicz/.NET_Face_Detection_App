namespace _18896_FinalProject
{
    partial class FormGeneratedImage
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
            this.generatedImage = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.downloadBar = new System.Windows.Forms.ProgressBar();
            this.labelDownload = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.generatedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // generatedImage
            // 
            this.generatedImage.Location = new System.Drawing.Point(13, 13);
            this.generatedImage.Name = "generatedImage";
            this.generatedImage.Size = new System.Drawing.Size(720, 480);
            this.generatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.generatedImage.TabIndex = 0;
            this.generatedImage.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(651, 507);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 31);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // downloadBar
            // 
            this.downloadBar.Location = new System.Drawing.Point(13, 507);
            this.downloadBar.Name = "downloadBar";
            this.downloadBar.Size = new System.Drawing.Size(632, 31);
            this.downloadBar.TabIndex = 2;
            // 
            // labelDownload
            // 
            this.labelDownload.AutoSize = true;
            this.labelDownload.BackColor = System.Drawing.Color.White;
            this.labelDownload.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDownload.Location = new System.Drawing.Point(329, 513);
            this.labelDownload.Name = "labelDownload";
            this.labelDownload.Size = new System.Drawing.Size(0, 18);
            this.labelDownload.TabIndex = 3;
            // 
            // FormGeneratedImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 553);
            this.Controls.Add(this.labelDownload);
            this.Controls.Add(this.downloadBar);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.generatedImage);
            this.Name = "FormGeneratedImage";
            this.Text = "FormGeneratedImage";
            ((System.ComponentModel.ISupportInitialize)(this.generatedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox generatedImage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ProgressBar downloadBar;
        private System.Windows.Forms.Label labelDownload;
    }
}