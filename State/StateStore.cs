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
            this.Add(new CreateState(eh));
            this.Add(new DragState(eh));
            this.Add(new SingleSelectState(eh));
            this.Add(new MultiSelectState(eh));
            this.Add(new EmptyState(eh));
        }
        public State this[StateType st] => this.First(func => func.ST == st);                 
    }
}
