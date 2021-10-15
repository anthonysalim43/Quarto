using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StartMenu
{
    public partial class Files : Form
    {
        public Files()
        {
            InitializeComponent();
        }
       
        private void Files_Load(object sender, EventArgs e)
        {
            
            for (int i = 1; i <= 5; i++)
            {
                FileStream fs1 = new FileStream("Game" + i.ToString() + ".data", FileMode.Create);
                fs1.Close();
            }
            for (int i = 1; i <= 5; i++)
            {
                FileStream fs2 = new FileStream("Game" + i.ToString() + "vsCPU.data", FileMode.Create);
                fs2.Close();
            }
            FileStream fs3 = new FileStream("Colors.data", FileMode.Create);
            fs3.Close();
        }
    }
}
