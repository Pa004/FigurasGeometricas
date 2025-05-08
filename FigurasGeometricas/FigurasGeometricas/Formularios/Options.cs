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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangle tr = new Triangle(); 
            this.Hide(); 
            tr.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Square sq = new Square();
            this.Hide();
            sq.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rectangle rc = new Rectangle();
            this.Hide();
            rc.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Circle cr = new Circle();
            this.Hide();
            cr.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ellipse el = new Ellipse();
            this.Hide();
            el.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SemiCircle sc = new SemiCircle();
            this.Hide();
            sc.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Trapeze tp = new Trapeze();
            this.Hide();
            tp.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Trapezoid tz = new Trapezoid();
            this.Hide();
            tz.ShowDialog();
            this.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Rhombus rm = new Rhombus();
            this.Hide();
            rm.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Rhomboid rm = new Rhomboid();
            this.Hide();
            rm.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Deltoid dl = new Deltoid();
            this.Hide();
            dl.ShowDialog();
            this.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Star st = new Star();
            this.Hide();
            st.ShowDialog();
            this.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
