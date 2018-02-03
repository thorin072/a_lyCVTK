//Класс MainCV
using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Collections.Generic;
using Accord.Imaging;
using Accord.Imaging.Filters;


namespace CVTK
{
    public partial class MainCV : Form
    {
        Image<Bgr, byte> img;
        Image<Gray, byte> img2;
        IEnumerable<RobotCommand.RobotPosition> ExcelArr;

        public class InfoDelete
        {
            public string parent;
            public int counts;
        }

        public MainCV()
        {
            InitializeComponent();
        }

        //---------------------------------------Модуль для обработки грфика---------------------------------------//

        /// <summary>
        /// Поиск контуров изображения и отрисовка на плоскости
        /// </summary>
        /// <param name="bin">Бинарное изображение</param>
        private void FindContours(Image<Gray, byte> bin)
        {
            var points = CentroMass.DeterminationOfCentromass(bin, ChainApproxMethod.ChainApproxNone);
            // var key = KeyPoint.SortTopPoint(points);


            //вывод графа все точек и всех контуров 
            TreePick(points);
            List<CentroMass.ContourWithMass> SortedList = points.OrderBy(j => j.Mass.X).ToList(); // сортировка по центру масс (х)
            infopcontr.Text = points.Count.ToString();

            //var visualXY = new List<Point>();
            //////Заполнение массивов для графика визуализации
            //for (int i = 0; i < SortedList.Count; i++)
            //{
            //    visualXY.AddRange(SortedList[i].Contr.ToArray());
            //}
            //var x = visualXY.Select(_ => _.X).ToArray();
            //infopoint.Text = x.Length.ToString();
            //var y = visualXY.Select(_ => _.Y).ToArray();
            //visualgraph.Series[1].Points.DataBindXY(x, y); // визуализация полного контура

            //PickKey(key);
            ExcelArr = Interpretation.InterpretationOfCommands(SortedList, (double)height.Value, (double)heigthpause.Value).ToList();
            infotime.Text = Interpretation.AllTime.Time.ToString();
        }

        private void PickKey(IList<Point> key)
        {

            var x = key.Select(_ => _.X).ToArray();
            infopoint.Text = x.Length.ToString();
            var y = key.Select(_ => _.Y).ToArray();
            visualgraph.Series[0].Points.DataBindXY(x, y);
        }

        //---------------------------------------Модуль для дерева---------------------------------------//

        /// <summary>
        /// Удаление узлов из дерева
        /// </summary>
        /// <param name="nodes">Дерево (его узлы) </param>
        void RemoveNode(TreeNodeCollection nodes)
        {
            List<TreeNode> checknode = new List<TreeNode>(); // лист чек-точек
            foreach (TreeNode parent in nodes) // уровень контуров
            {
                if (parent.Checked == false)
                {
                    foreach (TreeNode child in parent.Nodes) // уровень точек контура 
                    {
                        if (child.Checked)
                        {
                            checknode.Add(child);
                        }
                        else { continue; }
                    }
                    for (int i = 0; i < checknode.Count; i++)
                    {
                        tree.Nodes.Remove(checknode[i]);
                    }
                    checknode.Clear();
                }
            }
            foreach (TreeNode parent in nodes) // уровень контуров
            {
                if (parent.Checked)
                {
                    checknode.Add(parent);
                }

            }

            for (int i = 0; i < checknode.Count; i++) // удаление списка пустых узлов 
            {
                tree.Nodes.Remove(checknode[i]);
            }

        }

        void VisualPoint(TreeNodeCollection nodes)
        {
            List<Point> point = new List<Point>();
            string buf = "";
            foreach (TreeNode parent in nodes) // уровень контуров
            {
                if (parent.Checked == false)
                {
                    foreach (TreeNode child in parent.Nodes) // уровень точек контура 
                    {
                        if (child.Checked)
                        {
                            buf = child.Text;
                            var sp = buf.Split(';');
                            point.Add(new Point(Convert.ToInt32(sp[0]), Convert.ToInt32(sp[1])));
                        }
                        else { continue; }
                    }
                }
                else
                {
                    foreach (TreeNode child in parent.Nodes) // уровень точек контура 
                    {
                        child.Checked = true;
                        buf = child.Text;
                        var sp = buf.Split(';');
                        point.Add(new Point(Convert.ToInt32(sp[0]), Convert.ToInt32(sp[1])));
                    }
                }
            }
            PickKey(point);
        }

        void nulls(TreeNodeCollection nodes)
        {
            foreach (TreeNode parent in nodes) // уровень контуров
            {
                for (int i = 0; i < parent.Nodes.Count; i++) { parent.Nodes[i].Checked = false; }
            }

        }

        private string error(TreeNodeCollection nodes)
        {
            string mes = "";
            List<InfoDelete> checknode = new List<InfoDelete>(); // лист чек-точек
            foreach (TreeNode parent in nodes) // уровень контуров
            {
                InfoDelete inf = new InfoDelete();
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Checked)
                    {
                        inf.counts++;
                    }

                }
                inf.parent = parent.Text;
                checknode.Add(inf);
            }
            foreach (var inf in checknode)
            {
                mes = mes + inf.parent + ": " + inf.counts + "\r\n";
            }
            return mes;

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            nulls(tree.Nodes);
        }
        /// <summary>
        /// Создание дерева
        /// </summary>
        /// <param name="nodes"></param>
        private void TreePick(IList<CentroMass.ContourWithMass> nodes)
        {
            tree.Nodes.Clear();
            for (int i = 0; i < nodes.Count; i++)
            {
                tree.Nodes.Add("Контур " + i.ToString());
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].Contr.Count; j++)
                {
                    tree.Nodes[i].Nodes.Add(nodes[i].Contr[j].X.ToString() + ";" + nodes[i].Contr[j].Y.ToString());
                }
            }
        }

        //удалить
        private void button1_Click(object sender, EventArgs e)
        {
            //  var mes = error(tree.Nodes);
            //   if (MessageBox.Show(mes, "My Application",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            RemoveNode(tree.Nodes);
            //    }
        }

        //визуализировать
        private void button2_Click(object sender, EventArgs e)
        {
            VisualPoint(tree.Nodes);
        }
        //поиск ключевых
        private void FoundCheck_Click(object sender, EventArgs e)
        {

        }

        //---------------------------------------Модуль для обработки меню---------------------------------------//

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
                    img2 = imgCanny;
                    var Picture = GrayImg.ResizeImg(pictureBox1.Height, pictureBox1.Width);// подгонка для первоначального показа
                    Image<Bgr, byte> PictureFirst = _imgInput.Resize(Picture.Item2, Picture.Item1, Inter.Linear);
                    pictureBox1.Image = PictureFirst.Bitmap;
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
                infoexcel.Text = "Перестройка файла";
                var Rsize = GrayImg.ResizeImg((int)valueX.Value, (int)valueY.Value);
                var imgCanny = GrayImg.ApplyCanny(100, 150, Rsize.Item1, Rsize.Item2, img);
                FindContours(imgCanny);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Попытка перестроить нулевое изображение");
            }
        }

        private void создатьФайлExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelProcessor.PointToFile(ExcelArr);
                infoexcel.Text = "Cоздан";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Реализация невозможна. Причины: файл не был открыт, или массив точек пуст!");
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(">Для того чтобы реализовать модель контуров выполнить: Файл - Открыть изображение" + "\r\n" + ">Для перерисовки выбранного изображения выполнить: Файл - Перерисовка (будет сжато под указанные размеры в 'Сжатие размеров')" + "\r\n" + ">Для получения выходного файла в формате Excel выполнить: Файл - Создать файл Excel", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //---------------------------------------Модуль для обработки Accord (ключевых точек)---------------------------------------//
        void CornerFound(Bitmap input)
        {
            double sigma = (double)numSigma.Value;
            float k = (float)numK.Value;
            float threshold = (float)numThreshold.Value;

            // Create a new Harris Corners Detector using the given parameters
            HarrisCornersDetector harris = new HarrisCornersDetector(k)
            {
                Threshold = threshold,
                Sigma = sigma
            };
            // Create a new AForge's Corner Marker Filter
            CornersMarker corners = new CornersMarker(harris, Color.White);
            // input.RotateFlip(RotateFlipType.Rotate180FlipX);
            var OriginCorner = harris.ProcessImage(input); // ОРИГИНАЛ
            var CornerRrev = corners.Apply(input);
            var Picture = GrayImg.ResizeImg(pictureBox1.Height, pictureBox1.Width);// подгонка для первоначального показа
            Bitmap endpick = new Bitmap(CornerRrev, new Size(Picture.Item2, Picture.Item1));
            pictureBox1.Image = endpick;


         
            
          

            listView1.Columns.Add("№", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("X", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("Y", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("Является точкой", 105, HorizontalAlignment.Left);
            listView1.Columns.Add("Класс", 50, HorizontalAlignment.Left);

            ListViewGroup g1 = new ListViewGroup("Контрольные точки");
            listView1.Groups.Add(g1);

            for (int i = 0; i < OriginCorner.Count; i++)
            {
                ListViewItem list = new ListViewItem(g1);
                list.Text = i.ToString();
                list.SubItems.Add(OriginCorner[i].X.ToString());
                list.SubItems.Add(OriginCorner[i].Y.ToString());
                listView1.Items.Add(list);
            }
            listView1.CheckBoxes = true;







            var FakeCorner = harris.ProcessImage(endpick); // Уменьшеное

        }

        private void Detect_Click(object sender, EventArgs e)
        {
            var ImgCorner = img2.Bitmap;
            CornerFound(ImgCorner);

        }

       
    }
}
