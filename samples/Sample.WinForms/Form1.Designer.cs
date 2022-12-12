namespace Sample.WinForms
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSignWithoutTS = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveWithoutTS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveWithTS = new System.Windows.Forms.Button();
            this.btnApplyTS = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(540, 202);
            this.textBox1.TabIndex = 1;
            // 
            // btnSignWithoutTS
            // 
            this.btnSignWithoutTS.Location = new System.Drawing.Point(12, 32);
            this.btnSignWithoutTS.Name = "btnSignWithoutTS";
            this.btnSignWithoutTS.Size = new System.Drawing.Size(230, 47);
            this.btnSignWithoutTS.TabIndex = 0;
            this.btnSignWithoutTS.Text = "Sign with RSA/GOST key";
            this.btnSignWithoutTS.UseVisualStyleBackColor = true;
            this.btnSignWithoutTS.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(248, 218);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(540, 202);
            this.textBox2.TabIndex = 2;
            // 
            // btnSaveWithoutTS
            // 
            this.btnSaveWithoutTS.Location = new System.Drawing.Point(12, 290);
            this.btnSaveWithoutTS.Name = "btnSaveWithoutTS";
            this.btnSaveWithoutTS.Size = new System.Drawing.Size(230, 47);
            this.btnSaveWithoutTS.TabIndex = 3;
            this.btnSaveWithoutTS.Text = "Save as file";
            this.btnSaveWithoutTS.UseVisualStyleBackColor = true;
            this.btnSaveWithoutTS.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Raw data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "CMS with TS";
            // 
            // btnSaveWithTS
            // 
            this.btnSaveWithTS.Location = new System.Drawing.Point(12, 446);
            this.btnSaveWithTS.Name = "btnSaveWithTS";
            this.btnSaveWithTS.Size = new System.Drawing.Size(230, 47);
            this.btnSaveWithTS.TabIndex = 7;
            this.btnSaveWithTS.Text = "Save as file";
            this.btnSaveWithTS.UseVisualStyleBackColor = true;
            this.btnSaveWithTS.Click += new System.EventHandler(this.btnSaveWithTS_Click);
            // 
            // btnApplyTS
            // 
            this.btnApplyTS.Location = new System.Drawing.Point(12, 237);
            this.btnApplyTS.Name = "btnApplyTS";
            this.btnApplyTS.Size = new System.Drawing.Size(230, 47);
            this.btnApplyTS.TabIndex = 6;
            this.btnApplyTS.Text = "Apply TS with RSA/GOST key";
            this.btnApplyTS.UseVisualStyleBackColor = true;
            this.btnApplyTS.Click += new System.EventHandler(this.btnApplyTS_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(248, 429);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(540, 202);
            this.textBox3.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "CMS w/o TS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 640);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnSaveWithTS);
            this.Controls.Add(this.btnApplyTS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveWithoutTS);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnSignWithoutTS);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSignWithoutTS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveWithoutTS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveWithTS;
        private System.Windows.Forms.Button btnApplyTS;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
    }
}

