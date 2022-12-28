using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class StateStore: List<State>
    {
        public StateStore(EventHandler eh)
        {
            State createState= new CreateState(eh);
            State dragState = new DragState(eh);
            this.Add(createState);
            this.Add(dragState);                
        }
        public State this[StateType st] => this.First(func => func.ST == st);                 
    }
}
