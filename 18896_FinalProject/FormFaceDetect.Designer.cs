namespace _18896_FinalProject
{
    partial class FormFaceDetect
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
            this.pickDevice = new System.Windows.Forms.ComboBox();
            this.buttonDetect = new System.Windows.Forms.Button();
            this.camPlace = new System.Windows.Forms.PictureBox();
            this.lastDetectedFace = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelLiveImage = new System.Windows.Forms.Label();
            this.labelFace = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.radioHigh = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.groupResolution = new System.Windows.Forms.GroupBox();
            this.radioLow = new System.Windows.Forms.RadioButton();
            this.comboDetectionTarget = new System.Windows.Forms.ComboBox();
            this.labelTarget = new System.Windows.Forms.Label();
            this.btnRandomHuman = new System.Windows.Forms.Button();
            this.btnRandomCat = new System.Windows.Forms.Button();
            this.labelGenerate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.camPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastDetectedFace)).BeginInit();
            this.groupResolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // pickDevice
            // 
            this.pickDevice.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pickDevice.FormattingEnabled = true;
            this.pickDevice.Location = new System.Drawing.Point(104, 9);
            this.pickDevice.Name = "pickDevice";
            this.pickDevice.Size = new System.Drawing.Size(414, 31);
            this.pickDevice.TabIndex = 0;
            // 
            // buttonDetect
            // 
            this.buttonDetect.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDetect.Location = new System.Drawing.Point(524, 9);
            this.buttonDetect.Name = "buttonDetect";
            this.buttonDetect.Size = new System.Drawing.Size(84, 31);
            this.buttonDetect.TabIndex = 1;
            this.buttonDetect.Text = "Detect";
            this.buttonDetect.UseVisualStyleBackColor = true;
            this.buttonDetect.Click += new System.EventHandler(this.buttonDetect_Click);
            // 
            // camPlace
            // 
            this.camPlace.Location = new System.Drawing.Point(12, 74);
            this.camPlace.Name = "camPlace";
            this.camPlace.Size = new System.Drawing.Size(457, 291);
            this.camPlace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.camPlace.TabIndex = 2;
            this.camPlace.TabStop = false;
            // 
            // lastDetectedFace
            // 
            this.lastDetectedFace.Location = new System.Drawing.Point(475, 74);
            this.lastDetectedFace.Name = "lastDetectedFace";
            this.lastDetectedFace.Size = new System.Drawing.Size(461, 291);
            this.lastDetectedFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lastDetectedFace.TabIndex = 3;
            this.lastDetectedFace.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Device: ";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(852, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 31);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelLiveImage
            // 
            this.labelLiveImage.AutoSize = true;
            this.labelLiveImage.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLiveImage.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.labelLiveImage.Location = new System.Drawing.Point(175, 372);
            this.labelLiveImage.Name = "labelLiveImage";
            this.labelLiveImage.Size = new System.Drawing.Size(121, 23);
            this.labelLiveImage.TabIndex = 6;
            this.labelLiveImage.Text = "Live image!";
            // 
            // labelFace
            // 
            this.labelFace.AutoSize = true;
            this.labelFace.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFace.Location = new System.Drawing.Point(635, 372);
            this.labelFace.Name = "labelFace";
            this.labelFace.Size = new System.Drawing.Size(111, 23);
            this.labelFace.TabIndex = 7;
            this.labelFace.Text = "Last face -";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(743, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radioHigh
            // 
            this.radioHigh.AutoSize = true;
            this.radioHigh.Location = new System.Drawing.Point(6, 19);
            this.radioHigh.Name = "radioHigh";
            this.radioHigh.Size = new System.Drawing.Size(161, 22);
            this.radioHigh.TabIndex = 9;
            this.radioHigh.TabStop = true;
            this.radioHigh.Text = "High - 1280x720";
            this.radioHigh.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            this.radioMedium.AutoSize = true;
            this.radioMedium.Location = new System.Drawing.Point(6, 42);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(177, 22);
            this.radioMedium.TabIndex = 10;
            this.radioMedium.TabStop = true;
            this.radioMedium.Text = "Medium - 640x480";
            this.radioMedium.UseVisualStyleBackColor = true;
            // 
            // groupResolution
            // 
            this.groupResolution.Controls.Add(this.radioLow);
            this.groupResolution.Controls.Add(this.radioHigh);
            this.groupResolution.Controls.Add(this.radioMedium);
            this.groupResolution.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupResolution.Location = new System.Drawing.Point(475, 398);
            this.groupResolution.Name = "groupResolution";
            this.groupResolution.Size = new System.Drawing.Size(461, 129);
            this.groupResolution.TabIndex = 11;
            this.groupResolution.TabStop = false;
            this.groupResolution.Text = "Save quality";
            // 
            // radioLow
            // 
            this.radioLow.AutoSize = true;
            this.radioLow.Location = new System.Drawing.Point(6, 65);
            this.radioLow.Name = "radioLow";
            this.radioLow.Size = new System.Drawing.Size(146, 22);
            this.radioLow.TabIndex = 11;
            this.radioLow.TabStop = true;
            this.radioLow.Text = "Low - 320x240";
            this.radioLow.UseVisualStyleBackColor = true;
            // 
            // comboDetectionTarget
            // 
            this.comboDetectionTarget.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboDetectionTarget.FormattingEnabled = true;
            this.comboDetectionTarget.Items.AddRange(new object[] {
            "Human faces",
            "Human faces with eyes",
            "Eyes only",
            "Cat faces"});
            this.comboDetectionTarget.Location = new System.Drawing.Point(16, 443);
            this.comboDetectionTarget.Name = "comboDetectionTarget";
            this.comboDetectionTarget.Size = new System.Drawing.Size(256, 26);
            this.comboDetectionTarget.TabIndex = 12;
            this.comboDetectionTarget.SelectedIndexChanged += new System.EventHandler(this.comboDetectionTarget_SelectedIndexChanged);
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTarget.Location = new System.Drawing.Point(12, 417);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(189, 23);
            this.labelTarget.TabIndex = 13;
            this.labelTarget.Text = "Target detection";
            // 
            // btnRandomHuman
            // 
            this.btnRandomHuman.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRandomHuman.Location = new System.Drawing.Point(116, 488);
            this.btnRandomHuman.Name = "btnRandomHuman";
            this.btnRandomHuman.Size = new System.Drawing.Size(96, 26);
            this.btnRandomHuman.TabIndex = 14;
            this.btnRandomHuman.Text = "Human";
            this.btnRandomHuman.UseVisualStyleBackColor = true;
            this.btnRandomHuman.Click += new System.EventHandler(this.btnRandomHuman_Click);
            // 
            // btnRandomCat
            // 
            this.btnRandomCat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRandomCat.Location = new System.Drawing.Point(218, 488);
            this.btnRandomCat.Name = "btnRandomCat";
            this.btnRandomCat.Size = new System.Drawing.Size(96, 26);
            this.btnRandomCat.TabIndex = 15;
            this.btnRandomCat.Text = "Cat";
            this.btnRandomCat.UseVisualStyleBackColor = true;
            this.btnRandomCat.Click += new System.EventHandler(this.btnRandomCat_Click);
            // 
            // labelGenerate
            // 
            this.labelGenerate.AutoSize = true;
            this.labelGenerate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGenerate.Location = new System.Drawing.Point(8, 492);
            this.labelGenerate.Name = "labelGenerate";
            this.labelGenerate.Size = new System.Drawing.Size(102, 18);
            this.labelGenerate.TabIndex = 16;
            this.labelGenerate.Text = "Generate: ";
            // 
            // FormFaceDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(948, 536);
            this.Controls.Add(this.labelGenerate);
            this.Controls.Add(this.btnRandomCat);
            this.Controls.Add(this.btnRandomHuman);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.comboDetectionTarget);
            this.Controls.Add(this.groupResolution);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.labelLiveImage);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastDetectedFace);
            this.Controls.Add(this.camPlace);
            this.Controls.Add(this.buttonDetect);
            this.Controls.Add(this.pickDevice);
            this.Name = "FormFaceDetect";
            this.Text = "Face Detection Mode";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastDetectedFace)).EndInit();
            this.groupResolution.ResumeLayout(false);
            this.groupResolution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pickDevice;
        private System.Windows.Forms.Button buttonDetect;
        private System.Windows.Forms.PictureBox camPlace;
        private System.Windows.Forms.PictureBox lastDetectedFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelLiveImage;
        private System.Windows.Forms.Label labelFace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radioHigh;
        private System.Windows.Forms.RadioButton radioMedium;
        private System.Windows.Forms.GroupBox groupResolution;
        private System.Windows.Forms.RadioButton radioLow;
        private System.Windows.Forms.ComboBox comboDetectionTarget;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.Button btnRandomHuman;
        private System.Windows.Forms.Button btnRandomCat;
        private System.Windows.Forms.Label labelGenerate;
    }
}

