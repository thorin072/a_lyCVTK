//Класс MainCV
using System;
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
        IEnumerable<RobotCommand.RobotPosition> ExcelArr;

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
            var points = CentroMass.DeterminationOfCentromass(bin, ChainApproxMethod.ChainApproxNone);
            List<CentroMass.ContourWithMass> SortedList = points.OrderBy(j => j.Mass.X).ToList(); // сортировка по центру масс (х)
            infopoint.Text = points.Count.ToString();

            var visualXY = new List<Point>();
            ////Заполнение массивов для графика визуализации
            for (int i = 0; i < SortedList.Count; i++)
            {
                visualXY.AddRange(SortedList[i].Contr.ToArray());
            }
            var x = visualXY.Select(_ => _.X).ToArray();
            pointinfo.Text = x.Length.ToString();
            var y = visualXY.Select(_ => _.Y).ToArray();
            visualgraph.Series[0].Points.DataBindXY(x, y); // визуализация полного контура
            //Создание выходного файла
            ExcelArr = Interpretation.InterpretationOfCommands(SortedList, (double)height.Value,(double)heigthpause.Value);
        
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
            try
            {
                infoex.Text = "Перестройка файла";
                var Rsize = GrayImg.ResizeImg((int)valueX.Value, (int)valueY.Value);
                var imgCanny = GrayImg.ApplyCanny(100, 150, Rsize.Item1, Rsize.Item2, img);
                FindContours(imgCanny);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Попытка перестроить нулевое изображение");
            }
        }

        private void создатьФайлExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelProcessor.PointToFile(ExcelArr);
            infoex.Text = "Cоздан";
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(">При первичной и последующем открытии изображения следует установить 'Время построения' для модели" + "\r\n" + ">Для того чтобы реализовать модель контуров выполнить: Файл - Открыть изображение" + "\r\n" + ">Для перерисовки выбранного изображения выполнить: Файл - Перерисовка (будет сжато под указанные размеры в 'Сжатие размеров')" + "\r\n" + ">Для получения выходного файла в формате Excel выполнить: Файл - Создать файл Excel", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
