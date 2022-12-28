using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    interface IController
    {
        IModel Model { get; set; }
        IEventHandler IEvHandler { get; }
    }
    internal class Controller : IController
    {
        public Controller(object Model)
        {            
            this.Model = (IModel)Model;  
            eh = new EventHandler((IModel)Model);
        }

        public IModel Model { get; set; }

        private EventHandler eh;
        public IEventHandler IEvHandler { get => eh; }
    }
}
