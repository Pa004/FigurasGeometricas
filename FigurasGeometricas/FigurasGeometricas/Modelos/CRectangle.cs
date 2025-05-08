using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CRectangle : Figure
    {
        //Atributos
        private float mWidth;
        private float mHeight;
        private float mPerimeter;
        private float mArea;
        private Graphics mGraph;
        private const float SF = 20;
        private Pen mPen;

        //Métodos
        public CRectangle()
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
        }
        public void ReadData(TextBox txtWidth, TextBox txtHeigth)
        {
            try
            {
                mWidth = float.Parse(txtWidth.Text);
                mHeight = float.Parse(txtHeigth.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            mPerimeter = 2 * mWidth + 2 * mHeight;
        }
        public override void FigureArea()
        {
            mArea = mWidth * mHeight;
        }
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }
        public void InitializeData(TextBox txtWidht, TextBox txtHeight, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            mWidth = 0.0f; mHeight = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;

            txtWidht.Text = ""; txtHeight.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtWidht.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Blue, 3);
            mGraph.DrawRectangle(mPen, 0, 0, mWidth * SF, mHeight * SF);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
