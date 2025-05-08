using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CTrapezoid : Figure
    {
        // Atributos
        private float tSide1;
        private float tSide2;
        private float tSide3;
        private float tSide4;
        private float tHeight;
        private float tPerimeter;
        private float tArea;
        private Graphics tGraph;
        private const float SF = 20;
        private Pen tPen;

        // Métodos
        public CTrapezoid()
        {
            tSide1 = 0.0f; tSide2 = 0.0f; tSide3 = 0.0f; tSide4 = 0.0f;
            tHeight = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;
        }

        public void ReadData(TextBox txtSide1, TextBox txtSide2, TextBox txtSide3, TextBox txtSide4, 
                                TextBox txtHeight)
        {
            try
            {
                tSide1 = float.Parse(txtSide1.Text);
                tSide2 = float.Parse(txtSide2.Text);
                tSide3 = float.Parse(txtSide3.Text);
                tSide4 = float.Parse(txtSide4.Text);
                tHeight = float.Parse(txtHeight.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido....", "Mensaje de error");
            }
        }

        public override void FigurePerimeter()
        {
            tPerimeter = tSide1 + tSide2 + tSide3 + tSide4;
        }

        public override void FigureArea()
        {
            tArea = ((tSide1 + tSide3) * tHeight) / 2;
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = tPerimeter.ToString();
            txtArea.Text = tArea.ToString();
        }

        public void InitializeData(TextBox txtSide1, TextBox txtSide2, TextBox txtSide3, 
                                    TextBox txtSide4, TextBox txtHeight, TextBox txtPerimeter, 
                                    TextBox txtArea, PictureBox picCanvas)
        {
            tSide1 = tSide2 = tSide3 = tSide4 = tHeight = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;

            txtSide1.Text = ""; txtSide2.Text = ""; txtSide3.Text = ""; txtSide4.Text = ""; txtHeight.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            txtSide1.Focus(); txtSide2.Focus(); txtSide3.Focus(); txtSide4.Focus(); txtHeight.Focus();

            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (tSide1 <= 0 || tSide2 <= 0 || tSide3 <= 0 || tSide4 <= 0)
            {
                MessageBox.Show("Las dimensiones deben ser mayores a 0.", "Error");
                return;
            }

            tGraph = picCanvas.CreateGraphics();
            tPen = new Pen(Color.Blue, 3);

            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;
            PointF pointA = new PointF(centerX - (tSide1 * SF) / 2, centerY - (tHeight * SF) / 2);
            PointF pointB = new PointF(pointA.X + tSide1 * SF, pointA.Y);
            PointF pointD = new PointF(centerX - (tSide3 * SF) / 2, pointA.Y + tHeight * SF);
            PointF pointC = new PointF(pointD.X + tSide3 * SF, pointD.Y);

            tGraph.DrawPolygon(tPen, new PointF[] { pointA, pointB, pointC, pointD });
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
