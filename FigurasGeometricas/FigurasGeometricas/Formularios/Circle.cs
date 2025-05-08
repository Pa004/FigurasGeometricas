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
    public partial class Circle : Form
    {
        private CCircle ObjCircle = new CCircle(); 
        public Circle()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjCircle.ReadData(txtRadio);
            ObjCircle.FigurePerimeter();
            ObjCircle.FigureArea();
            ObjCircle.PrintData(txtPerimeter, txtArea);
            ObjCircle.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjCircle.InitializeData(txtRadio, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjCircle.CloseForm(this);
        }
    }
}
