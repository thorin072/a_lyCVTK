//Класс GrayImg
using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace CVTK
{
    /// <summary>
    /// Класс для создание серого изображения, ресайз изображения, наложение фильтра Canny на преобразованное изображение
    /// </summary>
    public static class GrayImg
    {
        /// <summary>
        /// Преобразование изображения
        /// </summary>
        /// <param name="nWidth">Новый размер</param>
        /// <param name="nHeight">Новый размер</param>
        /// <returns></returns>
        public static Tuple<int, int> ResizeImg(int nWidth, int nHeight)
        {
            Image result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.Dispose();
            }
            return Tuple.Create(result.Height, result.Width);
        }

        /// <summary>
        /// Наложение фильтра Canny
        /// </summary>
        /// <param name="tresch">Нижняя граница</param>
        /// <param name="tresch2">Верхняя граница</param>
        /// <param name="rH">Преобразованная высота</param>
        /// <param name="rW">>Преобразованная ширина</param>
        /// <param name="orign">Входное изображение</param>
        /// <returns></returns>
        public static Image<Gray, byte> ApplyCanny(int tresch, int tresch2, int rH, int rW, Image<Bgr, byte> orign)
        {
            Image<Bgr, byte> newinput = orign.Resize(rW, rH, Inter.Linear);
            Image<Gray, byte> _imgCanny = new Image<Gray, byte>(newinput.Width, newinput.Width, new Gray(0)); // создать новый обьект изображения Canny
            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            newinput = newinput.Rotate(180, new Bgr(255, 255, 255), false);
            newinput = newinput.Flip(FlipType.Horizontal);
            _imgCanny = newinput.Canny(tresch, tresch2); // вызов Canny из библиотеки
            return _imgCanny;
        }
    }
}
