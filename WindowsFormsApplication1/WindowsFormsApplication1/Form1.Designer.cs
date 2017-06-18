namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.capturedImageBox = new Emgu.CV.UI.ImageBox();
            this.forgroundImageBox = new Emgu.CV.UI.ImageBox();
            this.Cam2 = new Emgu.CV.UI.ImageBox();
            this.imageTranformLeft = new Emgu.CV.UI.ImageBox();
            this.Cam3 = new Emgu.CV.UI.ImageBox();
            this.Cam4 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTranformLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam4)).BeginInit();
            this.SuspendLayout();
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.Location = new System.Drawing.Point(193, 28);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(493, 239);
            this.capturedImageBox.TabIndex = 2;
            this.capturedImageBox.TabStop = false;
            // 
            // forgroundImageBox
            // 
            this.forgroundImageBox.Location = new System.Drawing.Point(322, 808);
            this.forgroundImageBox.Name = "forgroundImageBox";
            this.forgroundImageBox.Size = new System.Drawing.Size(26, 24);
            this.forgroundImageBox.TabIndex = 3;
            this.forgroundImageBox.TabStop = false;
            // 
            // Cam2
            // 
            this.Cam2.Location = new System.Drawing.Point(692, 28);
            this.Cam2.Name = "Cam2";
            this.Cam2.Size = new System.Drawing.Size(254, 484);
            this.Cam2.TabIndex = 4;
            this.Cam2.TabStop = false;
            this.Cam2.Click += new System.EventHandler(this.Cam2_Click);
            // 
            // imageTranformLeft
            // 
            this.imageTranformLeft.Location = new System.Drawing.Point(243, 808);
            this.imageTranformLeft.Name = "imageTranformLeft";
            this.imageTranformLeft.Size = new System.Drawing.Size(73, 24);
            this.imageTranformLeft.TabIndex = 6;
            this.imageTranformLeft.TabStop = false;
            // 
            // Cam3
            // 
            this.Cam3.Location = new System.Drawing.Point(193, 273);
            this.Cam3.Name = "Cam3";
            this.Cam3.Size = new System.Drawing.Size(493, 239);
            this.Cam3.TabIndex = 8;
            this.Cam3.TabStop = false;
            // 
            // Cam4
            // 
            this.Cam4.Location = new System.Drawing.Point(12, 27);
            this.Cam4.Name = "Cam4";
            this.Cam4.Size = new System.Drawing.Size(175, 484);
            this.Cam4.TabIndex = 9;
            this.Cam4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 749);
            this.Controls.Add(this.Cam4);
            this.Controls.Add(this.Cam3);
            this.Controls.Add(this.imageTranformLeft);
            this.Controls.Add(this.Cam2);
            this.Controls.Add(this.forgroundImageBox);
            this.Controls.Add(this.capturedImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forgroundImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageTranformLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cam4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox capturedImageBox;
        private Emgu.CV.UI.ImageBox forgroundImageBox;
        private Emgu.CV.UI.ImageBox Cam2;
        private Emgu.CV.UI.ImageBox imageTranformLeft;
        private Emgu.CV.UI.ImageBox Cam3;
        private Emgu.CV.UI.ImageBox Cam4;
    }
}

