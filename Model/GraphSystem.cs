using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class GraphSystem
    {
        public Graphics graphics { get; set; }

        public Pen penSelection;
        public SolidBrush sbSelection;
        public Pen penFrame;

        private Pen pen;
        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }
        private Color fillColor;
        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }
        public GraphSystem(Graphics gr)
        {
            graphics = gr;
            Pen = new Pen(Color.Black);
            penSelection = new Pen(Color.Black);
            sbSelection = new SolidBrush(Color.Gray);
            penFrame = new Pen(Color.Black);
            penFrame.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public void Line(int x, int y, int x2, int y2)
        {
            graphics.DrawLine(Pen, x, y, x2, y2);
        }

        public void Rect(int x, int y, int x2, int y2)
        {            
            List<Point> points = new List<Point>
            {
                new Point(x, y),
                new Point(x2, y),
                new Point(x2, y2),
                new Point(x, y2)
            };
            
            graphics.DrawPolygon(Pen, points.ToArray());           
            graphics.FillPolygon(new SolidBrush(FillColor), points.ToArray());
        }

        public void Ellipse(int x, int y, int x2, int y2)
        {
            

            RectangleF rf = new RectangleF(findMin(new List<int> { x, x2}), findMin(new List<int> { y, y2}), Math.Abs(x2-x), Math.Abs(y2 - y));
            
            graphics.DrawEllipse(Pen, rf);
            graphics.FillEllipse(new SolidBrush(FillColor), rf);
        }

        private static int findMin(List<int> values)
        {
            int min = values[0];
            foreach (int item in values)
            {
                if (item <= min)
                    min = item;
            }
            return min;
        }

    }
}
