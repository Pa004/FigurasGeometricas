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
    public partial class Triangle : Form
    {
        private CTriangle ObjTriangle = new CTriangle();
        public Triangle()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ObjTriangle.ReadData(txtSide1, txtSide2, txtSide3);
            ObjTriangle.FigurePerimeter();
            ObjTriangle.FigureArea();
            ObjTriangle.PrintData(txtPerimeter, txtArea);
            ObjTriangle.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTriangle.InitializeData(txtSide1, txtSide2, txtSide3,
                                    txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTriangle.CloseForm(this);
        }

        private void Triangle_Load(object sender, EventArgs e)
        {
            ObjTriangle.InitializeData(txtSide1, txtSide2, txtSide3,
                                    txtPerimeter, txtArea, picCanvas);
        }
    }
}
