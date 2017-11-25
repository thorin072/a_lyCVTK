namespace CVTK
{
    partial class canny
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericth2 = new System.Windows.Forms.NumericUpDown();
            this.numericth1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericth1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numericth2);
            this.groupBox1.Controls.Add(this.numericth1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка фильтра";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 20);
            this.button1.TabIndex = 12;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericth2
            // 
            this.numericth2.Location = new System.Drawing.Point(80, 47);
            this.numericth2.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericth2.Name = "numericth2";
            this.numericth2.Size = new System.Drawing.Size(104, 20);
            this.numericth2.TabIndex = 6;
            // 
            // numericth1
            // 
            this.numericth1.Location = new System.Drawing.Point(80, 21);
            this.numericth1.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericth1.Name = "numericth1";
            this.numericth1.Size = new System.Drawing.Size(104, 20);
            this.numericth1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Граница 1: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Граница 2:";
            // 
            // canny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(220, 124);
            this.Controls.Add(this.groupBox1);
            this.Name = "canny";
            this.Text = "Настройки контуров";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericth1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericth2;
        private System.Windows.Forms.NumericUpDown numericth1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}