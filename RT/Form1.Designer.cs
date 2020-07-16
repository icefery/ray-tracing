namespace RT
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.nameBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1600, 900);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // testBtn
            // 
            this.testBtn.Font = new System.Drawing.Font("微软雅黑",
                                                        9F,
                                                        System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point,
                                                        ((byte) (134)));
            this.testBtn.Location = new System.Drawing.Point(1400, 0);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(200, 30);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "测试";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // nameBtn
            // 
            this.nameBtn.Font = new System.Drawing.Font("微软雅黑",
                                                        9F,
                                                        System.Drawing.FontStyle.Regular,
                                                        System.Drawing.GraphicsUnit.Point,
                                                        ((byte) (0)));
            this.nameBtn.Location = new System.Drawing.Point(0, 0);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(200, 30);
            this.nameBtn.TabIndex = 2;
            this.nameBtn.Text = "201831063120-郝杰";
            this.nameBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 937);
            this.Controls.Add(this.nameBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button nameBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button testBtn;

        #endregion
    }
}