using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gantt_Tool
{
    public partial class ReadModel : Form
    {
        public ReadModel()
        {
            InitializeComponent();
        }

        private void ReadModel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.InitialDirectory;
        }
        
    }
}
