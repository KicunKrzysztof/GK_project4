using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3d_basic
{
    public partial class Form1 : Form
    {
        private Engine engine;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine(pictureBox); 
        }
    }
}
