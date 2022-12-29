using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    public enum StateType
    {
        CreateState,
        DragState,
        SingleSelectionState,
        MultiSelectionState,
        EmptyState
    }

    abstract class State
    {
        public State(EventHandler eh)
        {
            EH = eh;
        }

        public virtual void MouseMove(int x, int y) { }

        public virtual void LeftMouseUp(int x, int y) { }

        public virtual void LeftMouseDown(int x, int y) { }


        private bool ctrlIsPressed;
        public bool CtrlIsPressed
        {
            get { return ctrlIsPressed; }
            set { ctrlIsPressed = value; }
        }       

        public virtual void EscPress() 
        {
            EH.Model.Selections.ReleaseSelection();
            this.EH.ChangeStateTo(StateType.EmptyState);
        }
        public virtual void Delete() 
        {
            EH.Model.Selections.DeleteSelectedItems();
            EH.ChangeStateTo(StateType.EmptyState);
        }

        public virtual void Grouping() { }
        public virtual void Ungrouping() { }

        public abstract StateType ST { get; }

        private EventHandler eh;
        public EventHandler EH
        {
            set { eh = value; } get { return eh; }            
        }

    }
}
