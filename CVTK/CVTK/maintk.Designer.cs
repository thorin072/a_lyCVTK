namespace CVTK
{
    partial class MainCV
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCV));
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ysm = new System.Windows.Forms.Label();
            this.xsm = new System.Windows.Forms.Label();
            this.valueY = new System.Windows.Forms.NumericUpDown();
            this.valueX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.infosize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.infopoint = new System.Windows.Forms.Label();
            this.infoex = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перестроитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(148, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Визуализация найденных контуров:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(-22, 50);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Name = "Series1";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Color = System.Drawing.Color.Red;
            series8.Name = "Series2";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(538, 454);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "chart1";
            // 
            // ysm
            // 
            this.ysm.AutoSize = true;
            this.ysm.Location = new System.Drawing.Point(18, 87);
            this.ysm.Name = "ysm";
            this.ysm.Size = new System.Drawing.Size(31, 13);
            this.ysm.TabIndex = 27;
            this.ysm.Text = "none";
            // 
            // xsm
            // 
            this.xsm.AutoSize = true;
            this.xsm.Location = new System.Drawing.Point(18, 48);
            this.xsm.Name = "xsm";
            this.xsm.Size = new System.Drawing.Size(31, 13);
            this.xsm.TabIndex = 26;
            this.xsm.Text = "none";
            // 
            // valueY
            // 
            this.valueY.Location = new System.Drawing.Point(21, 64);
            this.valueY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valueY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valueY.Name = "valueY";
            this.valueY.Size = new System.Drawing.Size(69, 20);
            this.valueY.TabIndex = 1;
            this.valueY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.valueY.ValueChanged += new System.EventHandler(this.valueY_ValueChanged);
            // 
            // valueX
            // 
            this.valueX.Location = new System.Drawing.Point(21, 25);
            this.valueX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.valueX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valueX.Name = "valueX";
            this.valueX.Size = new System.Drawing.Size(69, 20);
            this.valueX.TabIndex = 0;
            this.valueX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.valueX.ValueChanged += new System.EventHandler(this.valueX_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "X                          px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y                         px";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ysm);
            this.panel1.Controls.Add(this.valueY);
            this.panel1.Controls.Add(this.xsm);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.valueX);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(15, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 119);
            this.panel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Размеры рабочей области: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.infoex);
            this.panel2.Controls.Add(this.infopoint);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.infosize);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(180, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 121);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.Location = new System.Drawing.Point(345, 494);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 121);
            this.panel3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Размер изображения:";
            // 
            // infosize
            // 
            this.infosize.AutoSize = true;
            this.infosize.Location = new System.Drawing.Point(3, 22);
            this.infosize.Name = "infosize";
            this.infosize.Size = new System.Drawing.Size(10, 13);
            this.infosize.TabIndex = 2;
            this.infosize.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Кол-во точек:";
            // 
            // infopoint
            // 
            this.infopoint.AutoSize = true;
            this.infopoint.Location = new System.Drawing.Point(3, 55);
            this.infopoint.Name = "infopoint";
            this.infopoint.Size = new System.Drawing.Size(10, 13);
            this.infopoint.TabIndex = 5;
            this.infopoint.Text = "-";
            // 
            // infoex
            // 
            this.infoex.AutoSize = true;
            this.infoex.Location = new System.Drawing.Point(25, 80);
            this.infoex.Name = "infoex";
            this.infoex.Size = new System.Drawing.Size(60, 13);
            this.infoex.TabIndex = 6;
            this.infoex.Text = "Не создан";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CVTK.Properties.Resources.excel;
            this.pictureBox1.Location = new System.Drawing.Point(6, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИзображениеToolStripMenuItem,
            this.перестроитьToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // открытьИзображениеToolStripMenuItem
            // 
            this.открытьИзображениеToolStripMenuItem.Image = global::CVTK.Properties.Resources.box_picture;
            this.открытьИзображениеToolStripMenuItem.Name = "открытьИзображениеToolStripMenuItem";
            this.открытьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.открытьИзображениеToolStripMenuItem.Text = "Открыть изображение...";
            this.открытьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.открытьИзображениеToolStripMenuItem_Click);
            // 
            // перестроитьToolStripMenuItem
            // 
            this.перестроитьToolStripMenuItem.Image = global::CVTK.Properties.Resources.reload;
            this.перестроитьToolStripMenuItem.Name = "перестроитьToolStripMenuItem";
            this.перестроитьToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.перестроитьToolStripMenuItem.Text = "Перестроить ";
            this.перестроитьToolStripMenuItem.Click += new System.EventHandler(this.перестроитьToolStripMenuItem_Click);
            // 
            // MainCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 629);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainCV";
            this.Text = "MainCV";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьИзображениеToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown valueY;
        private System.Windows.Forms.NumericUpDown valueX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem перестроитьToolStripMenuItem;
        private System.Windows.Forms.Label xsm;
        private System.Windows.Forms.Label ysm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label infoex;
        private System.Windows.Forms.Label infopoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label infosize;
        private System.Windows.Forms.Label label2;
    }
}

