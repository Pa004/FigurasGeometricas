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
    public partial class Star : Form
    {
        private CStar ObjStar = new CStar(); 
        public Star()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjStar.ReadData(txtOuter, txtInner);
            ObjStar.FigurePerimeter();
            ObjStar.FigureArea();
            ObjStar.PrintData(txtPerimeter, txtArea);
            ObjStar.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjStar.InitializeData(txtOuter, txtInner, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjStar.CloseForm(this);
        }
    }
}
