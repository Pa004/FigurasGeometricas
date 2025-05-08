using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CRhomboid : Figure
    {
        //Atributos  
        private float rBase;
        private float rSide;
        private float rHeight;
        private float rPerimeter;
        private float rArea;
        private const float SF = 20;
        private Pen rPen;

        //Métodos  
        public CRhomboid() 
        {
            rBase = 0.0f; rSide = 0.0f; rHeight = 0.0f;
            rPerimeter = 0.0f; rArea = 0.0f;
        }

        public void ReadData(TextBox txtBase, TextBox txtSide, TextBox txtHeight)
        {
            try
            {
                rBase = float.Parse(txtBase.Text);
                rSide = float.Parse(txtSide.Text);
                rHeight = float.Parse(txtHeight.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }

        public override void FigurePerimeter()
        {
            rPerimeter = 2 * (rBase + rSide);
        }

        public override void FigureArea()
        {
            rArea = rBase * rHeight;
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = rPerimeter.ToString();
            txtArea.Text = rArea.ToString();
        }

        public void InitializeData(TextBox txtBase, TextBox txtSide, TextBox txtHeight,
                                    TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            rBase = 0.0f; rSide = 0.0f; rHeight = 0.0f;
            rPerimeter = 0.0f; rArea = 0.0f;
            txtBase.Text = ""; txtSide.Text = ""; txtHeight.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtBase.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (rBase <= 0 || rSide <= 0 || rHeight <= 0)
            {
                MessageBox.Show("Las dimensiones deben ser mayores a 0.", "Error");
                return;
            }

            Graphics rGraph = picCanvas.CreateGraphics();
            rPen = new Pen(Color.Blue, 3); 
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;
            float offsetX = (rSide - rHeight) * SF * 0.5f; 

            PointF pointA = new PointF(centerX - (rBase * SF) / 2, centerY - (rHeight * SF) / 2);
            PointF pointB = new PointF(pointA.X + rBase * SF, pointA.Y);
            PointF pointC = new PointF(pointB.X - offsetX, pointB.Y + rHeight * SF);
            PointF pointD = new PointF(pointA.X - offsetX, pointA.Y + rHeight * SF);

            // Dibujar el romboide  
            rGraph.DrawPolygon(rPen, new PointF[] { pointA, pointB, pointC, pointD });
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
