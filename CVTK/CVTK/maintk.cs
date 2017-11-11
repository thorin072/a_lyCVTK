using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

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
        /// <param name="eps"></param>
        public void FindContours(Image<Gray, byte> bin, double eps)
        {
            int Xmin = 0, Xmax = bin.Width, Step = 100;

            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            var points = ContoursProcessor.GetImagePoints(bin, eps);

            var contours = ContoursProcessor.GetImageContours(bin,eps);
            var x = points.Select(_ => _.X).ToArray();
            var y = points.Select(_ => _.Y).ToArray();
            ExcelProcessor.Pointtofile(x,y);
            chart1.Series[0].Points.DataBindXY(x, y);
        }

        //Может рассматриваться ситуация , что входными могут быть XY YZ ZX
        //Так же может быть очень не оптимальной , может есть более эффективное решение для преобразований
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
        public void Scalle(int Xwight, int Yheight , int Z ,int imgH, int imgW , ref int aftersclH, ref int aftersclW)
        {
            aftersclH = imgH;
            aftersclW = imgW;
            float k = (float)imgH / imgW; // коэф изображения
            label3.Text = k.ToString();
            if (Xwight > imgW && Yheight > imgH) // изображение мешьше раб.обл
            {
                aftersclH = imgH;
                aftersclW = imgW;

            }
            else // изображение больше раб.обл
            {
                // случай квадрата
                if ((imgH % 2 == 0) && (imgW % 2 == 0))
                {

                    if (k == 1)
                    {
                        while (aftersclH > Yheight)
                        {
                            aftersclH = (int)(aftersclH / 1.5);
                        }
                        while (aftersclW > Xwight)
                        {
                            aftersclW = (int)(aftersclW / 1.5);
                        }
                    }

                    if ((k > 0.6) && (k < 0.68))
                    {
                        while (aftersclH > Yheight)
                        {
                            aftersclH = (int)(aftersclH / 2.5);
                        }
                        while (aftersclW > Xwight)
                        {
                            aftersclW = (int)(aftersclW / 1.1);
                        }
                    }
                    if ((k > 0.68) && (k < 0.8))
                    {
                        while (aftersclH > Yheight)
                        {
                            aftersclH = (int)(aftersclH / 1.5);
                        }
                        while (aftersclW > Xwight)
                        {
                            aftersclW = (int)(aftersclW / 1.5);
                        }
                    }
                    if ((k > 1) && (k < 1.3))
                    {
                        while (aftersclH > Yheight)
                        {
                            aftersclH = (int)(aftersclH / 1.1);
                        }
                        while (aftersclW > Xwight)
                        {
                            aftersclW = (int)(aftersclW / 1.6);
                        }
                    }
                    if ((k > 1.3) && (k < 1.6))
                    {
                        while (aftersclH > Yheight)
                        {
                            aftersclH = (int)(aftersclH / 1.1);
                        }
                        while (aftersclW > Xwight)
                        {
                            aftersclW = (int)(aftersclW / 2);
                        }
                    }
                }

                // четная высота , и нечетная ширина 
                if ((imgH % 2 == 0) && (imgW % 2 != 0))
                {
                    float onepast = imgW;
                    while ((onepast % 3 != 0) && (onepast > 2))
                    {
                        onepast = (float)onepast / 3;
                    }
                    while (aftersclH > Yheight)
                    {
                        aftersclH = aftersclH / 2;
                    }
                    while (aftersclW > Xwight)
                    {
                        aftersclW = (int)(aftersclW / onepast);
                    }
                    aftersclW = -1;
                }

                // нечетная высота , и четная ширина 
                if ((imgH % 2 != 0) && (imgW % 2 == 0))
                {
                    float onepast = imgW;
                    while ((onepast % 3 != 0) && (onepast > 2))
                    {
                        onepast = (float)onepast / 3;
                    }
                    while (aftersclH > Yheight)
                    {
                        aftersclH = (int)(aftersclH / onepast);
                    }
                    while (aftersclW > Xwight)
                    {
                        aftersclW = aftersclW / 2;
                    }
                    aftersclH = -1;
                }
            }
        }

        /// <summary>
        ///  Функция вызова отрисовки контуров Canny
        /// </summary>
        /// <param name="tresch">верхняя граница</param>
        /// <param name="tresch2">нижняя граница</param>
        /// <param name="eps">дельта для  CvInvoke.ApproxPolyDP , изменяет количество точек </param>
        public void ApplyCanny(double tresch, double tresch2, double eps)
        {
            if (_imgInput == null)
            {
                statimg.Text = "Не загружено";
                return;
            }

            Scalle((int)valueX.Value, (int)valueY.Value, (int)valueZ.Value, _imgInput.Height, _imgInput.Width, ref aftersclH, ref aftersclW);
            sclsizeimg.Text = aftersclH.ToString() + "*" + aftersclW.ToString();

            Image<Bgr, byte> newinput = _imgInput.Resize(aftersclW, aftersclH, Inter.Linear); // создание нового обьекта , уже трансформированного 
            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(newinput.Width, newinput.Width, new Gray(0)); // создать новый обьект изображения Canny

            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            contourgrh.Image = _imgCanny.ToBitmap(); // вывести на экран результат Канни

            
            newinput = newinput.Rotate(180,new Bgr (255,255,255), false);
            newinput = newinput.Flip(FlipType.Horizontal);
            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            FindContours(_imgCanny, eps);
            

        }


        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // диалог открытия изображения
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                contourgrh.Image = null;
                _imgInput = new Image<Bgr, byte>(ofd.FileName);// инициализация обькта из переменной ofd
                statimg.Text = "Загружено";
                size.Text = _imgInput.Height.ToString() + "*" + _imgInput.Width.ToString();
                contourgrh.Invalidate();
                ApplyCanny(100, 50, 0.0015);//вызов с наальными параметрами 
            }
        }

        private void настройкаКонтураToolStripMenuItem_Click(object sender, EventArgs e) // вызов окна с настройками контура 
        {
            canny cparmt = new CVTK.canny(this);
            cparmt.StartPosition = FormStartPosition.CenterParent;
            cparmt.Show();
        }
    }
}
