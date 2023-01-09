using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
        interface IContourProps
    {
        int LineWidth { get; set; }
        Color Color { get; set; }
    }
    class ContourProps : Property, IContourProps
    {
        Color color = Color.Black;
        int lineWidth = 5;

        public ContourProps(Color _color, int _thickness)
        {
            color = _color;
            lineWidth = _thickness;
        }

        public int LineWidth { get => lineWidth; set => lineWidth = value; }
        public Color Color { get => color; set => color = value; }

        public override void Apply(GraphSystem gs)
        {
            gs.Pen.Color = color;
            gs.Pen.Width = lineWidth;
        }
    }
}
