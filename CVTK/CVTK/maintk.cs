﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Collections.Generic;

namespace CVTK
{
    public partial class MainCV : Form
    {
        Image<Bgr, byte> _imgInput; // создать обьект исходного изображения
        int aftersclH = 0, aftersclW = 0;

        public MainCV()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поиск контуров изображения и отрисовка на плоскости
        /// </summary>
        /// <param name="bin"></param>
        public void FindContours(Image<Gray, byte> bin)
        {
            var points = ContoursProcessor.GetImagePoints(bin); // собираем лист всех точек
            info.AppendText("Количество контуров: " + points.Count + "\r\n");
            var top_point = ContoursProcessor.GetTopPoint(bin); // собираем лист аппроксимированых точек 
            top_point = ContoursProcessor.Sort_Top_Point(top_point);


            //var end_point = ContoursProcessor.Found_lines(points);
            // info.AppendText("Количество точек: " + end_point.Item1.Count + "\r\n");
          

            var x = points.Select(_ => _.X).ToArray();
            var y = points.Select(_ => _.Y).ToArray();
            var x1 = top_point.Select(_ => _.X).ToArray();
            var y1 = top_point.Select(_ => _.Y).ToArray();

            chart1.Series[0].Points.DataBindXY(x, y);
            chart1.Series[1].Points.DataBindXY(x1, y1);

            float[] fx = new float[points.Count];
            float[] fy = new float[points.Count];
            float[] fxTop = new float[top_point.Count];
            float[] fyTop = new float[top_point.Count];

            for (int i = 0; i < x.Length; ++i)
            {
                fx[i] = (float)x[i];
            }

            for (int i = 0; i < x.Length; ++i)
            {
                fy[i] = (float)y[i];
            }

            for (int i = 0; i < x1.Length; ++i)
            {
                fxTop[i] = (float)x1[i];
            }

            for (int i = 0; i < x1.Length; ++i)
            {
                fyTop[i] = (float)y1[i];
            }

            ExcelProcessor.Pointtofile(fx,fy,fxTop,fyTop);
            info.AppendText("Файл координат создан"+ "\r\n");

        }

        //Может рассматриваться ситуация , что входными могут быть XY YZ ZX
        /// <summary>
        /// Функция масштабирования изображения 
        /// </summary>
        /// <param name="Xwight">длинна области</param>
        /// <param name="Yheight">высота области</param>
        /// <param name="Z"></param>
        /// <param name="imgH">высота изображения</param>
        /// <param name="imgW">длинна изображения</param>
        /// <param name="aftersclH">высота для нового обьекта </param>
        /// <param name="aftersclW">длинна для нового обьекта</param>
        /// 

        public void ResizeImg(int nWidth, int nHeight, ref int aftersclH, ref int aftersclW)
        {
            Image result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.Dispose();
            }
            aftersclH = result.Height;
            aftersclW = result.Width;
        }

        /// <summary>
        ///  Функция вызова отрисовки контуров Canny
        /// </summary>
        /// <param name="tresch">верхняя граница</param>
        /// <param name="tresch2">нижняя граница</param>
        /// <param name="eps">дельта для  CvInvoke.ApproxPolyDP , изменяет количество точек </param>
        public void ApplyCanny(double tresch, double tresch2)
        {
            if (_imgInput == null)
            {
                info.AppendText("Не загружено");
                return;
            }
            ResizeImg((int)valueX.Value, (int)valueY.Value, ref aftersclH, ref aftersclW);
            Image<Bgr, byte> newinput = _imgInput.Resize(aftersclW, aftersclH, Inter.Linear); // создание нового обьекта , уже трансформированного 
            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(newinput.Width, newinput.Width, new Gray(0)); // создать новый обьект изображения Canny
            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            contourgrh.Image = _imgCanny.ToBitmap(); // вывести на экран результат Канн
            newinput = newinput.Rotate(180, new Bgr(255, 255, 255), false);
            newinput = newinput.Flip(FlipType.Horizontal);
            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            FindContours(_imgCanny);
        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // диалог открытия изображения
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                contourgrh.Image = null;
                _imgInput = new Image<Bgr, byte>(ofd.FileName);// инициализация обькта из переменной ofd
                info.Clear();
                info.AppendText("Изображение загружено" + "\r\n");
                info.AppendText("Размеры изображения: " + Math.Round((_imgInput.Height / 37.795)).ToString() + "*" + Math.Round((_imgInput.Width / 37.795)).ToString() + " cм = " + _imgInput.Height + "*" + _imgInput.Width + " px" + "\r\n");
                contourgrh.Invalidate();
                ApplyCanny(150, 150);//вызов с наальными параметрами 
            }
        }



        private void valueX_ValueChanged(object sender, EventArgs e)
        {
            var sm = Math.Round((int)valueX.Value / 37.7952755905511);
            xsm.Text = sm.ToString() + " cм";

        }

        private void valueY_ValueChanged(object sender, EventArgs e)
        {
            var sm = Math.Round((int)valueY.Value / 37.7952755905511);
            ysm.Text = sm.ToString() + " cм";
        }

        private void перестроитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.AppendText("---UPDATE---" + "\r\n");
            ApplyCanny(150, 150);//вызов с наальными параметрами 

        }


        private void настройкаКонтураToolStripMenuItem_Click(object sender, EventArgs e) // вызов окна с настройками контура 
        {
            canny cparmt = new CVTK.canny(this);
            cparmt.StartPosition = FormStartPosition.CenterParent;
            cparmt.Show();
        }
    }
}
