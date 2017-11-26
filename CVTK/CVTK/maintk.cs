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
        public MainCV()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поиск контуров изображения и отрисовка на плоскости
        /// </summary>
        /// <param name="bin"></param>
        private void FindContours(Image<Gray, byte> bin)
        {
            var points = ContoursProcessor.GetImagePoints(bin, ChainApproxMethod.ChainApproxNone); // собираем лист всех точек
            info.AppendText("Количество контуров: " + points.Count + "\r\n");
            var topPoint = ContoursProcessor.GetImagePoints(bin, ChainApproxMethod.ChainApproxSimple); // собираем лист аппроксимированых точек 
            topPoint = SearchDirect.SortTopPoint(topPoint);
            //Для полного контура
            var x = points.Select(_ => _.X).ToArray();
            var flX = x.Select(n => (float)n).ToArray();
            var y = points.Select(_ => _.Y).ToArray();
            var flY = y.Select(n => (float)n).ToArray();

            chart1.Series[0].Points.DataBindXY(x, y); // визуализация полного контура
            //Для вершин 
            var xT = topPoint.Select(_ => _.X).ToArray();
            var flXTop = xT.Select(n => (float)n).ToArray();
            var yT = topPoint.Select(_ => _.Y).ToArray();
            var flYTop = yT.Select(n => (float)n).ToArray();

            chart1.Series[1].Points.DataBindXY(xT, yT); // визуализация вершин
            ExcelProcessor.PointToFile(flX, flY, flXTop, flYTop);
            info.AppendText("Файл координат создан" + "\r\n");
        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // диалог открытия изображения
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    contourgrh.Image = null;
                    Image<Bgr, byte> _imgInput = new Image<Bgr, byte>(ofd.FileName);// инициализация обькта из переменной ofd                                                         
                    contourgrh.Invalidate();
                    var Rsize = GrayImg.ResizeImg((int)valueX.Value, (int)valueY.Value);
                    var imgCanny = GrayImg.ApplyCanny(100, 150, Rsize.Item1, Rsize.Item2, _imgInput);
                    contourgrh.Image = imgCanny.ToBitmap();
                    FindContours(imgCanny);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }

    }
}
