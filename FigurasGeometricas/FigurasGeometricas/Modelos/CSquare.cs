using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CSquare : Figure
    {
        //Atributos
        private float mSide;
        private float mPerimeter;
        private float mArea;
        private Graphics mGraph;
        private const float SF = 20;
        private Pen mPen;

        //Métodos
        public CSquare()
        {
            mSide = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
        }
        public void ReadData(TextBox txtSide)
        {
            try
            {
                mSide = float.Parse(txtSide.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            mPerimeter = 4 * mSide;
        }
        public override void FigureArea()
        {
            mArea = mSide * mSide;
        }
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }
        public void InitializeData(TextBox txtSide, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            mSide = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;

            txtSide.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            //Graficar un rectángulo.
            mGraph.DrawRectangle(mPen, 0, 0, mSide * SF, mSide * SF);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
