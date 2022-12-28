using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorEditor
{
    public partial class Form1 : Form
    {
        IController IContrl;
        
        public Form1(object model)
        {            
            InitializeComponent();
            IContrl = new Controller(model);
            IContrl.Model.GrController.SetPort(panel2.CreateGraphics());               
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;
                IContrl.IEvHandler.LeftMouseDown(x, y);
                IContrl.Model.GrController.Repaint();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;
                IContrl.IEvHandler.LeftMouseUp(x, y);
                IContrl.Model.GrController.Repaint();
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;
                IContrl.IEvHandler.LeftMouseMove(x, y);
                IContrl.Model.GrController.Repaint();
            }
        }

        private void buttonContourColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ContourColor.BackColor = dialog.Color;
                    IContrl.Model.GrProperties.ContourProps.Color = dialog.Color;
                }
            }
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ContourColor.BackColor = dialog.Color;
                    IContrl.Model.GrProperties.FillProps.Color = dialog.Color;
                }
            }
        }

        private void widthBar_Scroll(object sender, EventArgs e)
        {
            IContrl.Model.GrProperties.ContourProps.LineWidth = widthBar.Value;
        }

        private void FigureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (FigureBox.SelectedIndex)
            {
                case (0):
                    IContrl.Model.Factory.FigureType = FigureType.Line;
                    break;
                case (1):
                    IContrl.Model.Factory.FigureType = FigureType.Rect;
                    break;
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            IContrl.Model.GrController.SetPort(panel2.CreateGraphics());
            IContrl.Model.GrController.Repaint();
        }
    }
}