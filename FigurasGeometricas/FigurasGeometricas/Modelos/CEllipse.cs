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
    internal class CEllipse : Figure
    {
        //Atributos
        private float eRadioX;
        private float eRadioY;
        private float ePerimeter;
        private float eArea;
        private Graphics eGraph;
        private const float SF = 20;
        private Pen ePen;
        
        //Métodos
        public CEllipse()
        {
            eRadioX = 0.0f; eRadioY = 0.0f;
            ePerimeter = 0.0f; eArea = 0.0f;
        }
        public void ReadData(TextBox txtRadioX, TextBox txtRadioY)
        {
            try
            {
                eRadioX = float.Parse(txtRadioX.Text);
                eRadioY = float.Parse(txtRadioY.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no valido....", "Mensaje de error");
            }
        }
        public override void FigurePerimeter()
        {
            ePerimeter = (float)(Math.PI * (3 * (eRadioX + eRadioY) - Math.Sqrt((3 * eRadioX + eRadioY) * (eRadioX + 3 * eRadioY))));
        }
        public override void FigureArea()
        {
            eArea = (float)(Math.PI * eRadioX * eRadioY);
        }

        public void PrintData(TextBox txtRadioX, TextBox txtRadioY)
        {
            txtRadioX.Text = ePerimeter.ToString();
            txtRadioY.Text = eArea.ToString();
        }
        public void InitializeData(TextBox txtRadioX, TextBox txtRadioY, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            eRadioX = 0.0f; eRadioY = 0.0f;
            ePerimeter = 0.0f; eArea = 0.0f;
            txtRadioX.Text = ""; txtRadioY.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";
            txtRadioX.Focus(); txtRadioY.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas)
        {
            if (eRadioX <= 0 || eRadioY <= 0)
            {
                MessageBox.Show("Los semiejes deben ser mayores a 0.", "Error");
                return;
            }

            eGraph = picCanvas.CreateGraphics();
            ePen = new Pen(Color.Blue, 3);

            float width = eRadioX * 2 * SF; // Ancho (diámetro en X) 
            float height = eRadioY * 2 * SF; // Alto (diámetro en Y) 
            float centerX = (picCanvas.Width - width) / 2; // Centrar en el eje X
            float centerY = (picCanvas.Height - height) / 2; // Centrar en el eje Y

            // Dibujar la elipse
            eGraph.DrawEllipse(ePen, centerX, centerY, width, height);
        }

        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
