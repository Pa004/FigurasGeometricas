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
    public partial class Trapezoid : Form
    {
        private CTrapezoid ObjTrapezoid = new CTrapezoid(); 
        public Trapezoid()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjTrapezoid.ReadData(txtSide1, txtSide2, txtSide3, txtSide4, txtHeight);
            ObjTrapezoid.FigurePerimeter();
            ObjTrapezoid.FigureArea();
            ObjTrapezoid.PrintData(txtPerimeter, txtArea);
            ObjTrapezoid.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTrapezoid.InitializeData(txtSide1, txtSide2, txtSide3, txtSide4, txtHeight, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTrapezoid.CloseForm(this);
        }
    }
}
