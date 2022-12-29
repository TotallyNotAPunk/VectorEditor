using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    abstract class Selection
    {
        public Selection(GraphItem _item)
        {
            Item= _item;
            IsGrab = false;
        }

        public bool bodyIsActive = false;
        

        private bool isGrab;
        public bool IsGrab
        {
            get { return isGrab; }
            set 
            { 
                isGrab = value;
                bodyIsActive = true;
            }
        }


        protected const int px = 5;

        

        private Point grabPoint;
        public Point GrabPoint
        {
            get { return grabPoint; }
            set { grabPoint = value; }
        }

        private GraphItem item;
        public GraphItem Item
        {
            get { return item; }
            protected set { item = value; }
        }

        public virtual bool frameTryDragTo(int x, int y)
        {
            if (IsGrab)
            {
                if (Item.Frame.X == GrabPoint.X & Item.Frame.Y == GrabPoint.Y)
                {
                    Item.Frame.X = x;
                    Item.Frame.Y = y;
                    GrabPoint = new Point(x, y);
                }
                else if (Item.Frame.X2 == GrabPoint.X & Item.Frame.Y2 == GrabPoint.Y)
                {
                    Item.Frame.X2 = x;
                    Item.Frame.Y2 = y;
                    GrabPoint = new Point(x, y);
                }
                else if (Item.Frame.X == GrabPoint.X & Item.Frame.Y2 == GrabPoint.Y)
                {
                    Item.Frame.X = x;
                    Item.Frame.Y2 = y;
                    GrabPoint = new Point(x, y);
                }
                else if (Item.Frame.X2 == GrabPoint.X & Item.Frame.Y == GrabPoint.Y)
                {
                    Item.Frame.X2 = x;
                    Item.Frame.Y = y;
                    GrabPoint = new Point(x, y);
                }
                
                return true;
            }
            else 
            if (bodyIsActive)
            {
                Item.Frame.X += x - Item.BodyHitPoint.X;
                Item.Frame.X2 += x - Item.BodyHitPoint.X;
                Item.Frame.Y += y - Item.BodyHitPoint.Y;
                Item.Frame.Y2 += y - Item.BodyHitPoint.Y;

                Item.InBody(x, y);
               
                return true;
            }

            else
                return false;
        }

        public virtual bool TryGrab(int x, int y)
        {
            if (Item.Frame.X - px <= x & x <= Item.Frame.X + px & Item.Frame.Y - px <= y & y <= Item.Frame.Y + px)
            {
                GrabPoint = new Point(Item.Frame.X, Item.Frame.Y);
                IsGrab = true;
                return true;
            }
            if (Item.Frame.X2 - px <= x & x <= Item.Frame.X2 + px & Item.Frame.Y2 - px <= y & y <= Item.Frame.Y2 + px)
            {
                GrabPoint = new Point(Item.Frame.X2, Item.Frame.Y2);
                IsGrab = true;
                return true;
            }

            if (Item.Frame.X - px <= x & x <= Item.Frame.X + px & Item.Frame.Y2 - px <= y & y <= Item.Frame.Y2 + px)
            {
                GrabPoint = new Point(Item.Frame.X, Item.Frame.Y2);
                IsGrab = true;
                return true;
            }

            if (Item.Frame.X2 - px <= x & x <= Item.Frame.X2 + px & Item.Frame.Y - px <= y & y <= Item.Frame.Y + px)
            {
                GrabPoint = new Point(Item.Frame.X2, Item.Frame.Y);
                IsGrab = true;
                return true;
            }


            return false;
        }

        public bool TryDragTo(int x, int y)
        {
            if(frameTryDragTo(x, y))
            {
                if(Item is Group)                
                    ((Group)Item).ChangeItemsInGroup();
                
                return true;
            }
            return false;
        }

        public void ReleaseGrab()
        {
            IsGrab = false;
            bodyIsActive= false;
        }

        public virtual void DrawSelectionMark(GraphSystem gs)// Выделение для элипса и квадрата
        {
            List<Point> points = new List<Point>
            {
                new Point(this.Item.Frame.X, this.Item.Frame.Y),
                new Point(this.Item.Frame.X2, this.Item.Frame.Y),
                new Point(this.Item.Frame.X2, this.Item.Frame.Y2),
                new Point(this.Item.Frame.X, this.Item.Frame.Y2)
            };
            gs.graphics.DrawPolygon(gs.penFrame, points.ToArray());

            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y - px, 2 * px, 2 * px));

            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));

            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X - px, this.Item.Frame.Y2 - px, 2 * px, 2 * px));

            gs.graphics.DrawRectangle(gs.penSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y - px, 2 * px, 2 * px));
            gs.graphics.FillRectangle(gs.sbSelection, new System.Drawing.Rectangle(this.Item.Frame.X2 - px, this.Item.Frame.Y - px, 2 * px, 2 * px));
        }

    }
}
