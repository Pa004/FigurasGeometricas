using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FigurasGeometricas.Modelos;

namespace FigurasGeometricas.Formularios
{
    public partial class Trapeze : Form
    {
        private CTrapeze ObjTrapeze = new CTrapeze(); 
        public Trapeze()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjTrapeze.ReadData(txtBaseMayor, txtBaseMenor, txtHeight);
            ObjTrapeze.FigurePerimeter();
            ObjTrapeze.FigureArea();
            ObjTrapeze.PrintData(txtPerimeter, txtArea);
            ObjTrapeze.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTrapeze.InitializeData(txtBaseMayor, txtBaseMenor, txtHeight, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTrapeze.CloseForm(this);
        }

        private void Trapeze_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void picCanvas_Click(object sender, EventArgs e)
        {

        }
    }
}
