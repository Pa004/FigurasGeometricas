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
    internal class CStar : Figure
    {
        // Atributos
        private float sRadiusOuter; // Radio de las puntas
        private float sRadiusInner; // Radio entre puntas
        private float sPerimeter;
        private float sArea;
        private const float SF = 20;
        private Pen sPen;

        // Métodos
        public void ReadData(TextBox txtOuter, TextBox txtInner)
        {
            try
            {
                sRadiusOuter = float.Parse(txtOuter.Text);
                sRadiusInner = float.Parse(txtInner.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...", "Mensaje de error");
            }
        }

        public override void FigurePerimeter()
        {
            int n = 5; // 5 puntas
            double angle = Math.PI / n;
            sPerimeter = (float)(2 * n * Math.Sqrt(
                sRadiusOuter * sRadiusOuter +
                sRadiusInner * sRadiusInner -
                2 * sRadiusOuter * sRadiusInner * Math.Cos(angle)
            ));
        }

        public override void FigureArea()
        {
            int n = 5; // 5 puntas
            double angle = 2 * Math.PI / n;
            sArea = (float)((n / 2.0) * sRadiusOuter * sRadiusInner * Math.Sin(angle));
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = sPerimeter.ToString();
            txtArea.Text = sArea.ToString();
        }

        public void InitializeData(TextBox txtOuter, TextBox txtInner, TextBox txtPerimeter, 
                                    TextBox txtArea, PictureBox picCanvas)
        {
            sRadiusOuter = 0.0f; sRadiusInner = 0.0f;
            sPerimeter = 0.0f; sArea = 0.0f;

            txtOuter.Text = ""; txtInner.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            txtOuter.Focus(); txtInner.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (sRadiusOuter <= 0 || sRadiusInner <= 0)
            {
                MessageBox.Show("Los radios deben ser mayores a 0.", "Error");
                return;
            }

            Graphics eGraph = picCanvas.CreateGraphics();
            Pen ePen = new Pen(Color.Blue, 3);
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            PointF[] starPoints = new PointF[10];
            double angle = -Math.PI / 2; // Apunta hacia arriba

            for (int i = 0; i < 10; i++)
            {
                float radius = (i % 2 == 0) ? sRadiusOuter * SF : sRadiusInner * SF;
                float x = centerX + (float)(radius * Math.Cos(angle));
                float y = centerY + (float)(radius * Math.Sin(angle));

                starPoints[i] = new PointF(x, y);
                angle += Math.PI / 5;
            }

            // Dibujar la estrella conectando los puntos
            eGraph.DrawPolygon(ePen, starPoints);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
