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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.heigthpause = new System.Windows.Forms.NumericUpDown();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infosize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infopcontr = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infopoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infotime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoexcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.visualCheck = new System.Windows.Forms.Button();
            this.FoundCheck = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualgraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heigthpause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Найденные контуры:";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(711, 24);
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
            chartArea1.Name = "ChartArea1";
            this.visualgraph.ChartAreas.Add(chartArea1);
            this.visualgraph.Location = new System.Drawing.Point(227, 27);
            this.visualgraph.Name = "visualgraph";
            this.visualgraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.visualgraph.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Indigo;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Name = "Series2";
            this.visualgraph.Series.Add(series1);
            this.visualgraph.Series.Add(series2);
            this.visualgraph.Size = new System.Drawing.Size(483, 474);
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
            this.groupBox1.Location = new System.Drawing.Point(15, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(78, 48);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.heigthpause);
            this.groupBox3.Controls.Add(this.height);
            this.groupBox3.Location = new System.Drawing.Point(18, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(91, 39);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.infosize,
            this.toolStripStatusLabel3,
            this.infopcontr,
            this.toolStripStatusLabel5,
            this.infopoint,
            this.toolStripStatusLabel7,
            this.infotime,
            this.toolStripStatusLabel9,
            this.infoexcel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(711, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "Размер изобр.:";
            // 
            // infosize
            // 
            this.infosize.BackColor = System.Drawing.Color.Transparent;
            this.infosize.Name = "infosize";
            this.infosize.Size = new System.Drawing.Size(27, 17);
            this.infosize.Text = "null";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel3.Text = "|Кол-во контуров:";
            // 
            // infopcontr
            // 
            this.infopcontr.BackColor = System.Drawing.Color.Transparent;
            this.infopcontr.Name = "infopcontr";
            this.infopcontr.Size = new System.Drawing.Size(27, 17);
            this.infopcontr.Text = "null";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel5.Text = "|Кол-во точек:";
            // 
            // infopoint
            // 
            this.infopoint.BackColor = System.Drawing.Color.Transparent;
            this.infopoint.Name = "infopoint";
            this.infopoint.Size = new System.Drawing.Size(27, 17);
            this.infopoint.Text = "null";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel7.Text = "|Время построения:";
            // 
            // infotime
            // 
            this.infotime.AutoSize = false;
            this.infotime.BackColor = System.Drawing.Color.Transparent;
            this.infotime.Name = "infotime";
            this.infotime.Size = new System.Drawing.Size(23, 17);
            this.infotime.Text = "null";
            this.infotime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel9.Text = "|Статус файла Ecxel:";
            // 
            // infoexcel
            // 
            this.infoexcel.BackColor = System.Drawing.Color.Transparent;
            this.infoexcel.Name = "infoexcel";
            this.infoexcel.Size = new System.Drawing.Size(27, 17);
            this.infoexcel.Text = "null";
            // 
            // tree
            // 
            this.tree.CheckBoxes = true;
            this.tree.Location = new System.Drawing.Point(3, 19);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(219, 170);
            this.tree.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Удалить узел";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.tree);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.visualCheck);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.FoundCheck);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 34);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(227, 266);
            this.flowLayoutPanel1.TabIndex = 32;
            // 
            // visualCheck
            // 
            this.visualCheck.Location = new System.Drawing.Point(98, 195);
            this.visualCheck.Name = "visualCheck";
            this.visualCheck.Size = new System.Drawing.Size(65, 23);
            this.visualCheck.TabIndex = 32;
            this.visualCheck.Text = "Визуализировать";
            this.visualCheck.UseVisualStyleBackColor = true;
            this.visualCheck.Click += new System.EventHandler(this.button2_Click);
            // 
            // FoundCheck
            // 
            this.FoundCheck.Location = new System.Drawing.Point(3, 224);
            this.FoundCheck.Name = "FoundCheck";
            this.FoundCheck.Size = new System.Drawing.Size(219, 23);
            this.FoundCheck.TabIndex = 33;
            this.FoundCheck.Text = "Поиск ключевых";
            this.FoundCheck.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "null";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 519);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.visualgraph);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CVTK";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visualgraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heigthpause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown heigthpause;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel infosize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel infopcontr;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel infopoint;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel infotime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel infoexcel;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button visualCheck;
        private System.Windows.Forms.Button FoundCheck;
        private System.Windows.Forms.Button button2;
    }
}

