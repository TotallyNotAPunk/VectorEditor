using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class EmptyState : State
    {
        public EmptyState(EventHandler eh) : base(eh)
        {
        }

        public override StateType ST => StateType.EmptyState;

        public override void LeftMouseUp(int x, int y)
        {
            if (EH.Model.Selections.TryGrab(x, y))
                EH.ChangeStateTo(StateType.SingleSelectionState);//при условии что мы попали по ней
            else 
            if (EH.Model.Selections.TrySelect(x, y, false))
            {
                EH.ChangeStateTo(StateType.SingleSelectionState);//при условии что мы попали по ней
            }

        }
    }
}
