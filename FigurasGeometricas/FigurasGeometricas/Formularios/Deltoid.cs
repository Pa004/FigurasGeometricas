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
    public partial class Deltoid : Form
    {
        private CDeltoid ObjDeltoid = new CDeltoid(); 
        public Deltoid()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjDeltoid.ReadData(txtSSide, txtLSide, txtDiagonalMayor, txtDiagonalMenor);
            ObjDeltoid.FigurePerimeter();
            ObjDeltoid.FigureArea();
            ObjDeltoid.PrintData(txtPerimeter, txtArea);
            ObjDeltoid.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjDeltoid.InitializeData(txtSSide, txtLSide, txtDiagonalMayor, txtDiagonalMenor, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjDeltoid.CloseForm(this);
        }
    }
}
