using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class Rect : Figure
    {
        public Rect(Frame frame, PropList propList) : base(frame, propList)
        {
        }

        public override Selection CreateSelection()
        {
            return new RectSelection(this);   
        }

        protected override void DrawGeometry(GraphSystem gs)
        {
            gs.Rect(this.Frame.X, this.Frame.Y, this.Frame.X2, this.Frame.Y2);
        }
    }
}
