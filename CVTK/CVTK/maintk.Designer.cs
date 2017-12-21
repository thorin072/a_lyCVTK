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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label9 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перестроитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьФайлExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualgraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ysm = new System.Windows.Forms.Label();
            this.xsm = new System.Windows.Forms.Label();
            this.valueY = new System.Windows.Forms.NumericUpDown();
            this.valueX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.infoex = new System.Windows.Forms.Label();
            this.infopoint = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.infosize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.times = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pointinfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.heigthpause = new System.Windows.Forms.NumericUpDown();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualgraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heigthpause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(145, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Визуализация найденных контуров";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(703, 24);
            this.menu.TabIndex = 19;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИзображениеToolStripMenuItem,
            this.перестроитьToolStripMenuItem,
            this.создатьФайлExcelToolStripMenuItem});
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
            // создатьФайлExcelToolStripMenuItem
            // 
            this.создатьФайлExcelToolStripMenuItem.Image = global::CVTK.Properties.Resources.excel;
            this.создатьФайлExcelToolStripMenuItem.Name = "создатьФайлExcelToolStripMenuItem";
            this.создатьФайлExcelToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.создатьФайлExcelToolStripMenuItem.Text = "Создать файл Excel ";
            this.создатьФайлExcelToolStripMenuItem.Click += new System.EventHandler(this.создатьФайлExcelToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Image = global::CVTK.Properties.Resources.if_About_132628;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // visualgraph
            // 
            this.visualgraph.BackColor = System.Drawing.Color.Transparent;
            this.visualgraph.BorderlineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea3.Name = "ChartArea1";
            this.visualgraph.ChartAreas.Add(chartArea3);
            this.visualgraph.Location = new System.Drawing.Point(-25, 27);
            this.visualgraph.Name = "visualgraph";
            this.visualgraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.visualgraph.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.RoyalBlue;
            series3.MarkerSize = 3;
            series3.Name = "Series1";
            this.visualgraph.Series.Add(series3);
            this.visualgraph.Size = new System.Drawing.Size(543, 538);
            this.visualgraph.TabIndex = 23;
            this.visualgraph.Text = "visualgraph";
            // 
            // ysm
            // 
            this.ysm.AutoSize = true;
            this.ysm.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ysm.Location = new System.Drawing.Point(21, 101);
            this.ysm.Name = "ysm";
            this.ysm.Size = new System.Drawing.Size(32, 16);
            this.ysm.TabIndex = 27;
            this.ysm.Text = "none";
            // 
            // xsm
            // 
            this.xsm.AutoSize = true;
            this.xsm.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xsm.Location = new System.Drawing.Point(21, 62);
            this.xsm.Name = "xsm";
            this.xsm.Size = new System.Drawing.Size(32, 16);
            this.xsm.TabIndex = 26;
            this.xsm.Text = "none";
            // 
            // valueY
            // 
            this.valueY.Location = new System.Drawing.Point(24, 78);
            this.valueY.Maximum = new decimal(new int[] {
            210,
            0,
            0,
            0});
            this.valueY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valueY.Name = "valueY";
            this.valueY.Size = new System.Drawing.Size(69, 22);
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
            this.valueX.Location = new System.Drawing.Point(24, 39);
            this.valueX.Maximum = new decimal(new int[] {
            210,
            0,
            0,
            0});
            this.valueX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.valueX.Name = "valueX";
            this.valueX.Size = new System.Drawing.Size(69, 22);
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
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "X                          px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y                         px";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Сжатие размеров:";
            // 
            // infoex
            // 
            this.infoex.AutoSize = true;
            this.infoex.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoex.ForeColor = System.Drawing.Color.DarkBlue;
            this.infoex.Location = new System.Drawing.Point(47, 168);
            this.infoex.Name = "infoex";
            this.infoex.Size = new System.Drawing.Size(62, 16);
            this.infoex.TabIndex = 6;
            this.infoex.Text = "Не создан";
            // 
            // infopoint
            // 
            this.infopoint.AutoSize = true;
            this.infopoint.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infopoint.ForeColor = System.Drawing.Color.DarkBlue;
            this.infopoint.Location = new System.Drawing.Point(6, 65);
            this.infopoint.Name = "infopoint";
            this.infopoint.Size = new System.Drawing.Size(12, 16);
            this.infopoint.TabIndex = 5;
            this.infopoint.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Кол-во контуров:";
            // 
            // infosize
            // 
            this.infosize.AutoSize = true;
            this.infosize.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infosize.ForeColor = System.Drawing.Color.DarkBlue;
            this.infosize.Location = new System.Drawing.Point(6, 33);
            this.infosize.Name = "infosize";
            this.infosize.Size = new System.Drawing.Size(12, 16);
            this.infosize.TabIndex = 2;
            this.infosize.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Размер изображения:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.valueX);
            this.groupBox1.Controls.Add(this.ysm);
            this.groupBox1.Controls.Add(this.xsm);
            this.groupBox1.Controls.Add(this.valueY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(507, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 130);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CVTK.Properties.Resources.excel;
            this.pictureBox1.Location = new System.Drawing.Point(8, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.times);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.pointinfo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.infosize);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.infopoint);
            this.groupBox2.Location = new System.Drawing.Point(507, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 161);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Инфо о контурах";
            // 
            // times
            // 
            this.times.AutoSize = true;
            this.times.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.times.ForeColor = System.Drawing.Color.DarkBlue;
            this.times.Location = new System.Drawing.Point(6, 134);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(12, 16);
            this.times.TabIndex = 9;
            this.times.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Требуется для построения (сек):";
            // 
            // pointinfo
            // 
            this.pointinfo.AutoSize = true;
            this.pointinfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pointinfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.pointinfo.Location = new System.Drawing.Point(6, 101);
            this.pointinfo.Name = "pointinfo";
            this.pointinfo.Size = new System.Drawing.Size(12, 16);
            this.pointinfo.TabIndex = 7;
            this.pointinfo.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Кол-во точек:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.heigthpause);
            this.groupBox3.Controls.Add(this.height);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.time);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.infoex);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(508, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 207);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Для манипулятора";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(8, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Высота для перехода:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(8, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "Высота раб.поверхности:";
            // 
            // heigthpause
            // 
            this.heigthpause.Location = new System.Drawing.Point(7, 79);
            this.heigthpause.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.heigthpause.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heigthpause.Name = "heigthpause";
            this.heigthpause.Size = new System.Drawing.Size(120, 20);
            this.heigthpause.TabIndex = 11;
            this.heigthpause.Value = new decimal(new int[] {
            215,
            0,
            0,
            0});
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(7, 37);
            this.height.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(120, 20);
            this.height.TabIndex = 10;
            this.height.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Время построения:";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(7, 121);
            this.time.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(120, 20);
            this.time.TabIndex = 8;
            this.time.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(25, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Статус файла Excel:";
            // 
            // MainCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 551);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.visualgraph);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Модель для графопостроителя";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualgraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heigthpause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьИзображениеToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart visualgraph;
        private System.Windows.Forms.NumericUpDown valueY;
        private System.Windows.Forms.NumericUpDown valueX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem перестроитьToolStripMenuItem;
        private System.Windows.Forms.Label xsm;
        private System.Windows.Forms.Label ysm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label infoex;
        private System.Windows.Forms.Label infopoint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label infosize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label pointinfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Label times;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown heigthpause;
    }
}

