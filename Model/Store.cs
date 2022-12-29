using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class Store : List<GraphItem>
    {
        public void Delete(List<GraphItem> items)
        {
            foreach (GraphItem grItem in items)
                this.Remove(grItem);
        }

        public GraphItem Item(int x, int y)
        {
            foreach (GraphItem item in this)
            {

                if (item.InBody(x, y))
                    return item;

            }
            
            return null;
        }
        
    }
}
