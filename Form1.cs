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

            this.KeyPreview = true;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            IContrl.IEvHandler.CtrlIsPressed = Control.ModifierKeys == Keys.Control;
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
            IContrl.IEvHandler.CtrlIsPressed = Control.ModifierKeys == Keys.Control;
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
            IContrl.IEvHandler.CtrlIsPressed = Control.ModifierKeys == Keys.Control;
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
                    FillColor.BackColor = dialog.Color;
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
                case (2):
                    IContrl.Model.Factory.FigureType = FigureType.Ellipse;
                    break;
            }
            IContrl.IEvHandler.EscPress();//сбрасываем всё
            IContrl.IEvHandler.SetDefaultState();//принудительно переходим в состояние create state
            IContrl.Model.GrController.Repaint();
        }
        private void buttonGrouping_Click(object sender, EventArgs e)
        {
            IContrl.IEvHandler.Grouping();
            IContrl.Model.GrController.Repaint();
        }

        private void buttonUngrouping_Click(object sender, EventArgs e)
        {
            IContrl.IEvHandler.Ungrouping();
            IContrl.Model.GrController.Repaint();            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                IContrl.IEvHandler.EscPress();
            }

            if (e.KeyValue == (char)Keys.Delete)
            {
                IContrl.IEvHandler.Delete();
            }

            IContrl.Model.GrController.Repaint();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            IContrl.Model.GrController.SetPort(panel2.CreateGraphics());
            IContrl.Model.GrController.Repaint();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            IContrl.IEvHandler.Copy();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            IContrl.IEvHandler.Paste();
            IContrl.Model.GrController.Repaint();
        }
    }
}