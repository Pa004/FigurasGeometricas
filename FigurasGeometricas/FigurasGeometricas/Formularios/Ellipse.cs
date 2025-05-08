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
    public partial class Ellipse : Form
    {
        private CEllipse ObjEllipse = new CEllipse(); 
        public Ellipse()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjEllipse.ReadData(txtRadioX, txtRadioY);
            ObjEllipse.FigurePerimeter();
            ObjEllipse.FigureArea();
            ObjEllipse.PrintData(txtPerimeter, txtArea);
            ObjEllipse.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjEllipse.InitializeData(txtRadioX, txtRadioY, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjEllipse.CloseForm(this);
        }
    }
}
