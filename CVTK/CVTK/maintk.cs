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
        Image<Bgr, byte> img;
        public MainCV()
        {
            InitializeComponent();
        }

        //// result.AddRange(point[i+1].Contr.ToArray()
        /// <summary>
        /// Поиск контуров изображения и отрисовка на плоскости
        /// </summary>
        /// <param name="bin"></param>
        private void FindContours(Image<Gray, byte> bin)
        {
            var points = CentroMass.DeterminationOfCentromass(bin, ChainApproxMethod.ChainApproxNone);
            infopoint.Text = points.Count.ToString();

            var visualXY = new List<Point>();

            ////Для полного контура
            for (int i = 0; i < points.Count; i++)
            {
                visualXY.AddRange(points[i].Contr.ToArray());

            }
             var x = visualXY.Select(_ => _.X).ToArray();
            var  y = visualXY.Select(_ => _.Y).ToArray();
      

            visualgraph.Series[0].Points.DataBindXY(x, y); // визуализация полного контура
           
            //  chart1.Series[1].Points.DataBindXY(xT, yT); // визуализация вершин
            ExcelProcessor.PointToFile(points);
            infoex.Text = "Cоздан";

        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // диалог открытия изображения
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image<Bgr, byte> _imgInput = new Image<Bgr, byte>(ofd.FileName);// инициализация обькта из переменной ofd   
                    infosize.Text = _imgInput.Width.ToString() + "*" + _imgInput.Height.ToString() + "px";
                    // var Rsize = GrayImg.ResizeImg((int)valueX.Value, (int)valueY.Value);
                    // var imgCanny = GrayImg.ApplyCanny(100, 150, Rsize.Item1, Rsize.Item2, _imgInput);
                    var imgCanny = GrayImg.ApplyCanny(100, 150, _imgInput.Width, _imgInput.Height, _imgInput);
                    img = _imgInput;
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
            var Rsize = GrayImg.ResizeImg((int)valueX.Value, (int)valueY.Value);
            var imgCanny = GrayImg.ApplyCanny(100, 150, Rsize.Item1, Rsize.Item2, img);
            FindContours(imgCanny);
        }

    }
}
