using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
namespace CVTK
{
    public partial class canny : Form
    {
    
        MainCV _main;
        
        public canny()
        {
            InitializeComponent();
        }
        public canny(MainCV hm)
        {
            InitializeComponent();
            _main = hm;

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(_main != null)
            {
                double a;
                double.TryParse(textBox1.Text,out a);
                _main.ApplyCanny((double)numericth1.Value, (double)numericth2.Value, a);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
