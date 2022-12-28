using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    internal class EventHandler : IEventHandler
    {
        private IModel model;
        public IModel Model { get => model; set => model = value; }
        public EventHandler(IModel model)
        {
            Model = model;
            StateStore= new StateStore(this);
            State = StateStore[StateType.CreateState];                    
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

        public void ChangeStateTo(StateType st) => State = StateStore[st];

        public void LeftMouseUp(int x, int y) => State.LeftMouseUp(x, y);                    
        public void LeftMouseDown(int x, int y) => State.LeftMouseDown(x, y);
        public void LeftMouseMove(int x, int y) => State.MouseMove(x, y);               
    }
}
