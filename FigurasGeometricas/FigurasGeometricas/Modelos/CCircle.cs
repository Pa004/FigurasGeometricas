using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FigurasGeometricas.Modelos
{
    internal class CCircle : Figure
    {
        //Atributos
        private float cRadio;
        private float cPerimeter;
        private float cArea;
        private Graphics cGraph;
        private const float SF = 20;
        private Pen cPen;

        //Métodos
        public CCircle()
        {
            cRadio = 0.0f;
            cPerimeter = 0.0f; cArea = 0.0f;
        }
        public void ReadData(TextBox txtRadio)
        {
            try
            {
                cRadio = float.Parse(txtRadio.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            cPerimeter = (float)(2 * Math.PI * cRadio);
        }
        public override void FigureArea()
        {
            cArea = (float)(Math.PI * cRadio * cRadio);
        }
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = cPerimeter.ToString();
            txtArea.Text = cArea.ToString();
        }
        public void InitializeData(TextBox txtRadio, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            cRadio = 0.0f;
            cPerimeter = 0.0f; cArea = 0.0f;
            txtRadio.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (cRadio <= 0)
            {
                MessageBox.Show("El radio debe ser mayor a 0.", "Error");
                return;
            }

            cGraph = picCanvas.CreateGraphics();
            cPen = new Pen(Color.Blue, 3);

            float diameter = cRadio * 2 * SF;
            float centerX = (picCanvas.Width - diameter) / 2;
            float centerY = (picCanvas.Height - diameter) / 2;

            // Dibujar el círculo
            cGraph.DrawEllipse(cPen, centerX, centerY, diameter, diameter);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
