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
    internal class CSemiCircle : Figure
    {
        //Atributos
        private float scRadio;
        private float scPerimeter;
        private float scArea;
        private Graphics scGraph;
        private const float SF = 20;
        private Pen scPen;
        
        //Métodos
        public CSemiCircle()
        {
            scRadio = 0.0f;
            scPerimeter = 0.0f; scArea = 0.0f;
        }
        public void ReadData(TextBox txtRadio)
        {
            try
            {
                scRadio = float.Parse(txtRadio.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            scPerimeter = (float)(Math.PI * scRadio + 2 * scRadio);
        }
        public override void FigureArea()
        {
            scArea = (float)(Math.PI * scRadio * scRadio / 2);
        }

        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = scPerimeter.ToString();
            txtArea.Text = scArea.ToString();
        }
        public void InitializeData(TextBox txtRadio, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            scRadio = 0.0f;
            scPerimeter = 0.0f; scArea = 0.0f;
            txtRadio.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (scRadio <= 0)
            {
                MessageBox.Show("El radio debe ser mayor a 0.", "Error");
                return;
            }

            scGraph = picCanvas.CreateGraphics();
            scPen = new Pen(Color.Blue, 3);
            float diameter = scRadio * 2 * SF;
            float centerX = (picCanvas.Width - diameter) / 2; // Centrar en el eje X
            float centerY = (picCanvas.Height - diameter) / 2; // Centrar en el eje Y
            scGraph.DrawArc(scPen, centerX, centerY, diameter, diameter, 0, 180);

            // Dibujar la línea recta para cerrar el semicírculo
            scGraph.DrawLine(scPen, centerX, centerY + diameter / 2, centerX + diameter, centerY + diameter / 2);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
