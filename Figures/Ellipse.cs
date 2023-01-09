using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class Ellipse : Figure
    {
        public Ellipse(Frame frame, PropList propList) : base(frame, propList)
        {
        }

        public override Selection CreateSelection()
        {
            return new EllipseSelection(this);
        }

        public override bool InBody(int x, int y)
        {
            if (this.Frame.X <= x & x <= this.Frame.X2 & this.Frame.Y <= y & y <= this.Frame.Y2
                 || this.Frame.X >= x & x >= this.Frame.X2 & this.Frame.Y >= y & y >= this.Frame.Y2

                 || this.Frame.X <= x & x <= this.Frame.X2 & this.Frame.Y >= y & y >= this.Frame.Y2
                 || this.Frame.X >= x & x >= this.Frame.X2 & this.Frame.Y <= y & y <= this.Frame.Y2
                )
            {
                BodyHitPoint = new System.Drawing.Point(x, y);
                return true;
            }

            return false;
        }

        protected override void DrawGeometry(GraphSystem gs)
        {
            gs.Ellipse(Frame.X, Frame.Y, Frame.X2, Frame.Y2);
        }

        public override Figure FigureCopy(Figure item, int px)
        {
            Ellipse copy = new Ellipse(new Frame(item.Frame.X+px, item.Frame.Y + px, item.Frame.X2 + px, item.Frame.Y2 + px), item.propList);
            return copy;
        }
    }
}
