using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class SelectionStore:List<Selection>
    {
        
        public Selection TryGrab(int x, int y) 
        {           
            for (int i = this.Count -1; i >= 0; i--)
            {
                if (this[i].TryGrab(x, y))
                {
                    activeSelection = this[i];
                    return this[i];
                }
            }

            return null;               
        }

        private Selection activeSelection;
        public Selection ActiveSelection//Grab Selection
        {
            get 
            {
                Selection _active = null;

                foreach (Selection item in this)
                    if (item.IsGrab || item.bodyIsActive)
                    {
                        _active = item;
                    }

                    return _active;
            }
        }

        public void Release()
        {
            activeSelection = null;
            foreach (Selection item in this)
            {
                item.ReleaseGrab();
            }
        }

        public void Draw(GraphSystem gs)
        {
            foreach (Selection item in this)
            {
                if (item.IsGrab || item.bodyIsActive)
                    item.DrawSelectionMark(gs);
            }
        }

    
        public List<GraphItem> GetSelectItems()
        {
            List<GraphItem> items = new List<GraphItem>();

            foreach (Selection item in this)            
                if (item.IsGrab || item.bodyIsActive)
                    items.Add(item.Item);
            
            return items;
        }       
    }
}
