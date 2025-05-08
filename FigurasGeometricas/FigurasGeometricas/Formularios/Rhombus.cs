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
    public partial class Rhombus : Form
    {
        private CRhombus ObjRhombus = new CRhombus(); 
        public Rhombus()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjRhombus.ReadData(txtSide, txtLDiagonal, txtSDiagonal);
            ObjRhombus.FigurePerimeter();
            ObjRhombus.FigureArea();
            ObjRhombus.PrintData(txtPerimeter, txtArea);
            ObjRhombus.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjRhombus.InitializeData(txtSide, txtLDiagonal, txtSDiagonal, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRhombus.CloseForm(this);
        }
    }
}
