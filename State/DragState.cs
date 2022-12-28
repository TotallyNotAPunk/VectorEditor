using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class DragState: State
    {
        public DragState(EventHandler eh) : base(eh)
        {
        }

        public override StateType ST => StateType.DragState;

        public override void MouseMove(int x, int y)
        {
            EH.Model.Selections.DragSelectionsTo(x, y);
        }

        public override void LeftMouseUp(int x, int y)
        {
            EH.Model.Selections.DragSelectionsTo(x, y);
            //EH.Model.Selections.ReleaseSelection();
            EH.ChangeStateTo(StateType.CreateState);
        }

        public override void LeftMouseDown(int x, int y)
        {
            
        }

    }
}
