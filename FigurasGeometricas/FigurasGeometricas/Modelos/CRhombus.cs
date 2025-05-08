using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CRhombus : Figure
    {
        //Atributos
        private float rSide;
        private float rLDiagonal;
        private float rSDiagonal;
        private float rPerimeter;
        private float rArea;
        private const float SF = 20;
        private Pen rPen;

        //Métodos
        public CRhombus()
        {
            rSide = 0.0f; rLDiagonal = 0.0f; rSDiagonal = 0.0f;
            rPerimeter = 0.0f; rArea = 0.0f;
        }
        public void ReadData(TextBox txtSide, TextBox txtLDiagonal, TextBox txtSDiagonal)
        {
            try
            {
                rSide = float.Parse(txtSide.Text);
                rLDiagonal = float.Parse(txtLDiagonal.Text);
                rSDiagonal = float.Parse(txtSDiagonal.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            rPerimeter = 4 * rSide;
        }
        public override void FigureArea()
        {
            rArea = (rLDiagonal * rSDiagonal) / 2;
        }
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = rPerimeter.ToString();
            txtArea.Text = rArea.ToString();
        }

        public void InitializeData(TextBox txtSide, TextBox txtLDiagonal, TextBox txtSDiagonal,
                                    TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            rSide = 0.0f; rLDiagonal = 0.0f; rSDiagonal = 0.0f;
            rPerimeter = 0.0f; rArea = 0.0f;
            txtSide.Text = ""; txtLDiagonal.Text = ""; txtSDiagonal.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (rLDiagonal <= 0 || rSDiagonal <= 0)
            {
                MessageBox.Show("Las diagonales deben ser mayores a 0.", "Error");
                return;
            }

            Graphics rGraph = picCanvas.CreateGraphics();
            rPen = new Pen(Color.Blue, 3);
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            PointF pointA = new PointF(centerX, centerY - (rLDiagonal * SF) / 2); // Vértice superior
            PointF pointB = new PointF(centerX + (rSDiagonal * SF) / 2, centerY); // Vértice derecho
            PointF pointC = new PointF(centerX, centerY + (rLDiagonal * SF) / 2); // Vértice inferior
            PointF pointD = new PointF(centerX - (rSDiagonal * SF) / 2, centerY); // Vértice izquierdo

            // Dibujar el rombo
            rGraph.DrawPolygon(rPen, new PointF[] { pointA, pointB, pointC, pointD });
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
