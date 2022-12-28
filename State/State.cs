using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    public enum StateType
    {
        CreateState,
        DragState
    }

    abstract class State
    {

        public virtual void MouseMove(int x, int y) { }

        public virtual void LeftMouseUp(int x, int y) { }

        public virtual void LeftMouseDown(int x, int y) { }
        
        public abstract StateType ST { get; }

        private EventHandler eh;

        protected State(EventHandler eh)
        {
            EH = eh;
        }

        public EventHandler EH
        {
            set { eh = value; } get { return eh; }            
        }

    }
}
