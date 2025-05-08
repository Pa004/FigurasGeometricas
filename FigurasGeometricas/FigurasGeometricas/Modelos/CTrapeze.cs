using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FigurasGeometricas.Modelos
{
    internal class CTrapeze : Figure
    {
        //Atributos
        private float tBaseMayor;
        private float tBaseMenor;
        private float tHeight;
        private float tPerimeter;
        private float tArea;
        private Graphics tGraph;
        private const float SF = 20;
        private Pen tPen;
        
        //Métodos
        public CTrapeze()
        {
            tBaseMayor = 0.0f; tBaseMenor = 0.0f; tHeight = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;
        }
        public void ReadData(TextBox txtBaseMayor, TextBox txtBaseMenor, TextBox txtHeight)
        {
            try
            {
                tBaseMayor = float.Parse(txtBaseMayor.Text);
                tBaseMenor = float.Parse(txtBaseMenor.Text);
                tHeight = float.Parse(txtHeight.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            float lado = (float)Math.Sqrt(Math.Pow((tBaseMayor - tBaseMenor) / 2.0, 2) + Math.Pow(tHeight, 2));
            tPerimeter = tBaseMayor + tBaseMenor + 2 * lado;
        }
        public override void FigureArea()
        {
            tArea = ((tBaseMayor + tBaseMenor) * tHeight) / 2;
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = tPerimeter.ToString();
            txtArea.Text = tArea.ToString();
        }
        public void InitializeData(TextBox txtBaseMayor, TextBox txtBaseMenor, TextBox txtHeight, 
                                    TextBox txtPerimeter,TextBox txtArea, PictureBox picCanvas)
        {
            tBaseMayor = 0.0f; tBaseMenor = 0.0f; tHeight = 0.0f;
            tPerimeter = 0.0f; tArea = 0.0f;
            txtBaseMayor.Text = ""; txtBaseMenor.Text = "";
            txtHeight.Text = ""; txtPerimeter.Text = ""; txtArea.Text = "";
            txtBaseMayor.Focus(); txtBaseMenor.Focus(); txtHeight.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (tBaseMayor <= 0 || tBaseMenor <= 0 || tHeight <= 0)
            {
                MessageBox.Show("Las dimensiones deben ser mayores a 0.", "Error");
                return;
            }

            tGraph = picCanvas.CreateGraphics();
            tPen = new Pen(Color.Blue, 3);
            float centerX = picCanvas.Width / 2; // Centrar horizontalmente
            float centerY = picCanvas.Height / 2; // Centrar verticalmente

            // Coordenadas de la base mayor
            PointF pointA = new PointF(centerX - (tBaseMayor * SF) / 2, centerY - (tHeight * SF) / 2);
            PointF pointB = new PointF(pointA.X + tBaseMayor * SF, pointA.Y);

            // Coordenadas de la base menor
            float offsetX = (tBaseMayor - tBaseMenor) / 2 * SF;
            PointF pointD = new PointF(pointA.X + offsetX, pointA.Y + tHeight * SF);
            PointF pointC = new PointF(pointD.X + tBaseMenor * SF, pointD.Y);

            // Dibujar el trapecio
            tGraph.DrawPolygon(tPen, new PointF[] { pointA, pointB, pointC, pointD });
        }


        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
