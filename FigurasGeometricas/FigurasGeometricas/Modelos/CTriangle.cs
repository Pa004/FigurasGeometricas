using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CTriangle : Figure
    {
        //Atributos
        private float Side1;
        private float Side2;
        private float Side3;
        private float tPerimeter;
        private float tArea;
        private Graphics tGraph;
        private const float SF = 20;
        private Pen tPen;

        //Métodos
        public CTriangle()
        {
            Side1 = 0.0f; Side2 = 0.0f; Side3 = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;
        }
        public void ReadData(TextBox txtSide1, TextBox txtSide2, TextBox txtSide3)
        {
            try
            {
                Side1 = float.Parse(txtSide1.Text);
                Side2 = float.Parse(txtSide2.Text);
                Side3 = float.Parse(txtSide3.Text);

                if (!IsValidTriangle())
                {
                    MessageBox.Show("Los lados ingresados no forman un triángulo válido.", "Error");
                    Side1 = Side2 = Side3 = 0.0f;
                }
            }
            catch
            {
                MessageBox.Show("Ingreso no válido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            tPerimeter = Side1 + Side2 + Side3;
        }
        public override void FigureArea()
        {
            float s = (Side1 + Side2 + Side3) / 2;
            tArea = (float)Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
        }
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = tPerimeter.ToString();
            txtArea.Text = tArea.ToString();
        }
        public void InitializeData(TextBox txtSide1, TextBox txtSide2, TextBox txtSide3, 
                                    TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            Side1 = 0.0f; Side2 = 0.0f; Side3 = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;

            txtSide1.Text = ""; txtSide2.Text = ""; txtSide3.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtSide1.Focus(); txtSide2.Focus(); txtSide3.Focus();
            picCanvas.Refresh();
        }

        private bool IsValidTriangle()
        {
            return (Side1 + Side2 > Side3) &&
                   (Side1 + Side3 > Side2) &&
                   (Side2 + Side3 > Side1);
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (!IsValidTriangle())
            {
                MessageBox.Show("Los lados ingresados no forman un triángulo válido.", "Error");
                return;
            }

            tGraph = picCanvas.CreateGraphics();
            tPen = new Pen(Color.Blue, 3);
            PointF pointA = new PointF(0, 0);
            PointF pointB = new PointF(Side1 * SF, 0);
            PointF pointC = new PointF(
                (float)((Math.Pow(Side2, 2) - Math.Pow(Side3, 2) + Math.Pow(Side1, 2)) / (2 * Side1)) * SF,
                (float)(Math.Sqrt(Math.Pow(Side2, 2) - Math.Pow(((Math.Pow(Side2, 2) - Math.Pow(Side3, 2) + Math.Pow(Side1, 2)) / (2 * Side1)), 2))) * SF
            );

            float minX = Math.Min(pointA.X, Math.Min(pointB.X, pointC.X));
            float minY = Math.Min(pointA.Y, Math.Min(pointB.Y, pointC.Y));
            float maxX = Math.Max(pointA.X, Math.Max(pointB.X, pointC.X));
            float maxY = Math.Max(pointA.Y, Math.Max(pointB.Y, pointC.Y));
            float triangleWidth = maxX - minX;
            float triangleHeight = maxY - minY;
            float offsetX = (picCanvas.Width - triangleWidth) / 2 - minX;
            float offsetY = (picCanvas.Height - triangleHeight) / 2 - minY;

            pointA = new PointF(pointA.X + offsetX, pointA.Y + offsetY);
            pointB = new PointF(pointB.X + offsetX, pointB.Y + offsetY);
            pointC = new PointF(pointC.X + offsetX, pointC.Y + offsetY);

            // Dibujar el triángulo
            tGraph.DrawPolygon(tPen, new PointF[] { pointA, pointB, pointC });
        }


        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
