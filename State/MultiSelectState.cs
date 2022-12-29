using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class MultiSelectState : State
    {
        public MultiSelectState(EventHandler eh) : base(eh)
        {
        }

        public override StateType ST => StateType.MultiSelectionState;

        public override void Grouping()
        {

            if (EH.Model.Selections.Grouping())
            {
                EH.ChangeStateTo(StateType.SingleSelectionState);            
            }
        }
        
        public override void LeftMouseUp(int x, int y)
        {
            if (!EH.Model.Selections.TrySelect(x, y, true))
                base.EscPress();
        } 

    }
}
