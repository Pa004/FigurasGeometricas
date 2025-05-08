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
    public partial class Rhomboid : Form
    {
        private CRhomboid ObjRhomboid = new CRhomboid(); 
        public Rhomboid()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjRhomboid.ReadData(txtBase, txtSide, txtHeight);
            ObjRhomboid.FigurePerimeter();
            ObjRhomboid.FigureArea();
            ObjRhomboid.PrintData(txtPerimeter, txtArea);
            ObjRhomboid.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjRhomboid.InitializeData(txtBase, txtSide, txtHeight, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRhomboid.CloseForm(this);
        }
    }
}
