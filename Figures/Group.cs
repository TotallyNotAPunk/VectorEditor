using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class Group : GraphItem
    {
        public Group(Frame _frame) : base(_frame)
        {
            graphItems = new List<GraphItem>();
        }
        public void ChangeItemsInGroup()
        {
            foreach (GraphItem item in graphItems)            
                item.SetNewFrame(Frame);            
        }

        public override void SetNewFrame(Frame frame)
        {
            base.SetNewFrame(frame);
            ChangeItemsInGroup();
        }

        public List<GraphItem> graphItems;

        public override Selection CreateSelection()
        {
           return new GroupSelection(this);
        }

        public override void Draw(GraphSystem gs)
        {
            foreach (GraphItem item in graphItems)
            {
                item.Draw(gs);
            }
        }

        public override bool InBody(int x, int y)
        {
            foreach (GraphItem item in graphItems)
            {
                if (item.InBody(x, y))
                {
                    BodyHitPoint = new System.Drawing.Point(x, y);
                    return true;
                }
            }
            return false;
        }
        public override GraphItem Copy(GraphItem item, int px)
        {
            List<GraphItem>  items = new List<GraphItem>();
            foreach (GraphItem item2 in ((Group)item).graphItems)
            {
                items.Add(item2.Copy(item2, px));
            }
            Group copy = Factory.NewGroup(items);
            return copy;
        }
    }
}
