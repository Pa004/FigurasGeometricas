using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CDeltoid : Figure
    {
        //Atributos
        private float dSSide;  // Lado corto
        private float dLSide;  // Lado largo
        private float dDiagonalMayor;
        private float dDiagonalMenor;
        private float dPerimeter;
        private float dArea;
        private const float SF = 20;
        private Pen dPen;

        //Métodos
        public CDeltoid()
        {
            dSSide = 0.0f; dLSide = 0.0f;
            dDiagonalMayor = 0.0f; dDiagonalMenor = 0.0f;
            dPerimeter = 0.0f; dArea = 0.0f;
        }

        public void ReadData(TextBox txtSSide, TextBox txtLSide, TextBox txtDiagonalMayor, TextBox txtDiagonalMenor)
        {
            try
            {
                dSSide = float.Parse(txtSSide.Text);
                dLSide = float.Parse(txtLSide.Text);
                dDiagonalMayor = float.Parse(txtDiagonalMayor.Text);
                dDiagonalMenor = float.Parse(txtDiagonalMenor.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido....", "Mensaje de error");
            }
        }

        public override void FigurePerimeter()
        {
            dPerimeter = 2 * (dSSide + dLSide);
        }

        public override void FigureArea()
        {
            dArea = (dDiagonalMayor * dDiagonalMenor) / 2;
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = dPerimeter.ToString();
            txtArea.Text = dArea.ToString();
        }

        public void InitializeData(TextBox txtSSide, TextBox txtLSide, TextBox txtDiagonalMayor, TextBox txtDiagonalMenor,
                                    TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            dSSide = 0.0f; dLSide = 0.0f;
            dDiagonalMayor = 0.0f; dDiagonalMenor = 0.0f;
            dPerimeter = 0.0f; dArea = 0.0f;

            txtSSide.Text = ""; txtLSide.Text = "";
            txtDiagonalMayor.Text = ""; txtDiagonalMenor.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            txtSSide.Focus();  
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (dDiagonalMayor <= 0 || dDiagonalMenor <= 0)
            {
                MessageBox.Show("Las diagonales deben ser mayores a 0.", "Error");
                return;
            }

            Graphics dGraph = picCanvas.CreateGraphics();
            dPen = new Pen(Color.Blue, 3);
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            PointF pointA = new PointF(centerX, centerY - (dDiagonalMayor * SF) / 2); // Vértice superior
            PointF pointB = new PointF(centerX + (dDiagonalMenor * SF) / 2, centerY); // Vértice derecho
            PointF pointC = new PointF(centerX, centerY + (dDiagonalMayor * SF) / 2); // Vértice inferior
            PointF pointD = new PointF(centerX - (dDiagonalMenor * SF) / 2, centerY); // Vértice izquierdo

            // Dibujar el deltoide
            dGraph.DrawPolygon(dPen, new PointF[] { pointA, pointB, pointC, pointD });
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }

    }
}
