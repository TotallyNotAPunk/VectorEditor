using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class CreateState: State
    {
        public CreateState(EventHandler eh) : base(eh)
        {
        }

        public override StateType ST => StateType.CreateState; 
        
        public override void LeftMouseDown(int x, int y)
        {
            EH.Model.Factory.CreateAndGrabItem(x, y);
            EH.ChangeStateTo(StateType.DragState);
        }
        
    }
}
