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
        }

        public bool selectionIsGrab = false;
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
            private set { item = value; }
        }


        public virtual bool frameTryDragTo(int x, int y)
        {
            if (selectionIsGrab)
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
                return false;
        }

        public abstract bool TryGrab(int x, int y);

        public bool TryDragTo(int x, int y)
        {
            return this.frameTryDragTo(x, y);
        }
        
        public void ReleaseGrab()
        {
            selectionIsGrab = false;
        }
        
        public abstract void DrawSelectionMark(GraphSystem gs);

    }
}
