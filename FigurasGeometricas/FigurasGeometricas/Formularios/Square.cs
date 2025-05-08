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
    public partial class Square : Form
    {
        private CSquare ObjSquare = new CSquare(); 
        public Square()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjSquare.ReadData(txtSide);
            ObjSquare.FigurePerimeter();
            ObjSquare.FigureArea();
            ObjSquare.PrintData(txtPerimeter, txtArea);
            ObjSquare.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjSquare.InitializeData(txtSide, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjSquare.CloseForm(this);
        }
    }
}
