using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Formularios
{
    public partial class Cover : Form
    {
        public Cover()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Options optionsForm = new Options();
            this.Hide();
            optionsForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
