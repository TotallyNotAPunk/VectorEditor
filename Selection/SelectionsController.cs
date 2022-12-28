using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    interface ISelections
    {
        void DragSelectionsTo(int x, int y);
        void ReleaseSelection();
        void DeleteSelections();

    }
    class SelectionsController : ISelections
    {
        public SelectionsController(SelectionStore ss)
        {
            SelectionStore = ss;  
        }
                
        private SelectionStore selectionStore;
        public SelectionStore SelectionStore
        {
            get { return selectionStore; }
            private set { selectionStore = value; }
        }

        public void SelectAndGrabItem(GraphItem item, int x, int y)
        {
            Selection s = item.CreateSelection();
            SelectionStore.Add(s);
            SelectionStore.TryGrab(x, y);              
        }

        void ISelections.DeleteSelections()
        {
            SelectionStore.Clear();
        }

        void ISelections.DragSelectionsTo(int x, int y)
        {
            if (SelectionStore.ActiveSelection != null)
            {                
                if (SelectionStore.ActiveSelection.TryDragTo(x, y))
                {
                    //Console.WriteLine("Координаты изменились!");                                        
                }
            }
               
        }

        void ISelections.ReleaseSelection()
        {
            SelectionStore.Release();
        }
    }
}
