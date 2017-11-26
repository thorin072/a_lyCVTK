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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCV));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перестроитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.info = new System.Windows.Forms.RichTextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ysm = new System.Windows.Forms.Label();
            this.xsm = new System.Windows.Forms.Label();
            this.valueY = new System.Windows.Forms.NumericUpDown();
            this.valueX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.contourgrh = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourgrh)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Рабочая область:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(524, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Область контура:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.info);
            this.groupBox1.Location = new System.Drawing.Point(527, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 111);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инфо";
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.White;
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.info.EnableAutoDragDrop = true;
            this.info.Location = new System.Drawing.Point(6, 19);
            this.info.Name = "info";
            this.info.ReadOnly = true;
            this.info.Size = new System.Drawing.Size(344, 86);
            this.info.TabIndex = 25;
            this.info.Text = "";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(-18, 48);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(539, 500);
            this.chart1.TabIndex = 23;
            this.chart1.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ysm);
            this.groupBox2.Controls.Add(this.xsm);
            this.groupBox2.Controls.Add(this.valueY);
            this.groupBox2.Controls.Add(this.valueX);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(527, 463);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 69);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Размеры раб.обл";
            // 
            // ysm
            // 
            this.ysm.AutoSize = true;
            this.ysm.Location = new System.Drawing.Point(191, 42);
            this.ysm.Name = "ysm";
            this.ysm.Size = new System.Drawing.Size(31, 13);
            this.ysm.TabIndex = 27;
            this.ysm.Text = "none";
            // 
            // xsm
            // 
            this.xsm.AutoSize = true;
            this.xsm.Location = new System.Drawing.Point(78, 42);
            this.xsm.Name = "xsm";
            this.xsm.Size = new System.Drawing.Size(31, 13);
            this.xsm.TabIndex = 26;
            this.xsm.Text = "none";
            // 
            // valueY
            // 
            this.valueY.Location = new System.Drawing.Point(194, 19);
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
            this.valueX.Location = new System.Drawing.Point(81, 19);
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
            this.label6.Location = new System.Drawing.Point(66, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "X                          px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y                         px";
            // 
            // contourgrh
            // 
            this.contourgrh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contourgrh.Location = new System.Drawing.Point(527, 59);
            this.contourgrh.Name = "contourgrh";
            this.contourgrh.Size = new System.Drawing.Size(356, 281);
            this.contourgrh.TabIndex = 20;
            this.contourgrh.TabStop = false;
            // 
            // MainCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(892, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contourgrh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainCV";
            this.Text = "MainCV";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourgrh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьИзображениеToolStripMenuItem;
        private System.Windows.Forms.PictureBox contourgrh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown valueY;
        private System.Windows.Forms.NumericUpDown valueX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem перестроитьToolStripMenuItem;
        private System.Windows.Forms.RichTextBox info;
        private System.Windows.Forms.Label xsm;
        private System.Windows.Forms.Label ysm;
    }
}

