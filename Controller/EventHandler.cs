using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal interface IEventHandler
    {
        void LeftMouseUp(int x, int y);
        void LeftMouseDown(int x, int y);
        void LeftMouseMove(int x, int y);

        void EscPress();
        void Grouping();
        void Ungrouping();
        void Delete();
        bool CtrlIsPressed { get; set; }

        void SetDefaultState();//Create State

        void Copy();
        void Paste();
    }
    internal class EventHandler : IEventHandler
    {
        private IModel model;
        public IModel Model { get => model; set => model = value; }
        public EventHandler(IModel model)
        {
            Model = model;
            StateStore = new StateStore(this);
            State = StateStore[StateType.CreateState];
            ctrlIsPressed = false;
        }

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private StateStore stateStore;
        public StateStore StateStore
        {
            get { return stateStore; }
            set { stateStore = value; }
        }

        bool ctrlIsPressed;
        bool IEventHandler.CtrlIsPressed { get => ctrlIsPressed; set => ctrlIsPressed = value; }

        public void ChangeStateTo(StateType st) 
        {
            State = StateStore[st];
            State.CtrlIsPressed= ctrlIsPressed;
        }
        public void SetDefaultState() => ChangeStateTo(StateType.CreateState);

        public void LeftMouseUp(int x, int y)
        {
            State.CtrlIsPressed = ctrlIsPressed;
            State.LeftMouseUp(x, y); 
        }
        public void LeftMouseDown(int x, int y)
        {
            State.CtrlIsPressed = ctrlIsPressed;
            State.LeftMouseDown(x, y);
        }
        public void LeftMouseMove(int x, int y) => State.MouseMove(x, y);
        public void EscPress() => State.EscPress();

        void IEventHandler.Grouping() => State.Grouping();

        void IEventHandler.Ungrouping() => State.Ungrouping();

        void IEventHandler.Delete() => Model.Selections.DeleteSelectedItems();

        void IEventHandler.Copy() => Model.Factory.CopyItems();
        void IEventHandler.Paste() => Model.Factory.PasteItems();
    }
}
