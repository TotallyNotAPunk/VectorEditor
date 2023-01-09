using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class SingleSelectState : State
    {
        public SingleSelectState(EventHandler eh) : base(eh)
        {
        }

        public override StateType ST => StateType.SingleSelectionState;

        public override void LeftMouseDown(int x, int y)
        {
            if (EH.Model.Selections.TryGrab(x, y) || EH.Model.Selections.TrySelect(x, y, CtrlIsPressed))
            {
                if (EH.Model.Selections.Count == 1)                 
                { 
                    this.EH.ChangeStateTo(StateType.DragState);
                }                                                       
            }          
        }

        public override void LeftMouseUp(int x, int y)
        {                        
            if (!EH.Model.Selections.TrySelect(x, y, CtrlIsPressed))
            {
                this.EH.ChangeStateTo(StateType.EmptyState);
                EH.Model.Selections.ReleaseSelection();
            }            
            else
            {
                if (EH.Model.Selections.Count > 1)
                    this.EH.ChangeStateTo(StateType.MultiSelectionState);
            }
        }

        public override void Ungrouping()
        {
            EH.Model.Selections.Ungrouping();
            this.EH.ChangeStateTo(StateType.MultiSelectionState);
        }

    }
}
