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
    public partial class SemiCircle : Form
    {
        private CSemiCircle ObjSemiCircle = new CSemiCircle(); 
        public SemiCircle()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjSemiCircle.ReadData(txtRadio);
            ObjSemiCircle.FigurePerimeter();
            ObjSemiCircle.FigureArea();
            ObjSemiCircle.PrintData(txtPerimeter, txtArea);
            ObjSemiCircle.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjSemiCircle.InitializeData(txtRadio, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjSemiCircle.CloseForm(this);
        }
    }
}
