using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditor
{
    class LineSelection : Selection
    {
        public LineSelection(Line _item) : base(_item)
        {

        }

        public override bool frameTryDragTo(int x, int y)
        {
            if (selectionIsGrab)
            {                                
                if (this.Item.Frame.X == this.GrabPoint.X & this.Item.Frame.Y == this.GrabPoint.Y)
                {
                    this.Item.Frame.X = x;
                    this.Item.Frame.Y = y;
                    this.GrabPoint = new Point(x, y);
                }
                else if (this.Item.Frame.X2 == this.GrabPoint.X & this.Item.Frame.Y2 == this.GrabPoint.Y)
                {
                    this.Item.Frame.X2 = x;
                    this.Item.Frame.Y2 = y;
                    this.GrabPoint = new Point(x, y);
                }
                return true;
            }
            else
                return false;
        }

        public override void DrawSelectionMark(GraphSystem gs)
        {
            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y - px, 2 * px, 2 * px));

            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));
            /*
            gs.graphics.DrawEllipse(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y - px, 2 * px, 2 * px));
            gs.graphics.DrawEllipse(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));
            */
        }

        
        
        public override bool TryGrab(int x, int y)// попытка захватить какой-либо маркер линии
        {

            if (Item.Frame.X - px <= x & x <= Item.Frame.X + px    &    Item.Frame.Y - px <= y & y <= Item.Frame.Y + px)
            {
                GrabPoint= new Point(Item.Frame.X, Item.Frame.Y);
                selectionIsGrab = true;
                return true;
            }
            if (Item.Frame.X2 - px <= x & x <= Item.Frame.X2 + px    &    Item.Frame.Y2 - px <= y & y <= Item.Frame.Y2 + px)
            {
                GrabPoint = new Point(Item.Frame.X2, Item.Frame.Y2);
                selectionIsGrab = true;
                return true;
            }
            return false;
        }
    }
}
