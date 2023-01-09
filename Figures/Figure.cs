using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal abstract class Figure : GraphItem
    {
        public PropList propList;

        public Figure(Frame frame, PropList propList) : base(frame)
        {
            this.propList = propList;
        }

        public override void Draw(GraphSystem gs)
        {            
            propList.Aplly(gs);
            DrawGeometry(gs);
        }

        abstract protected void DrawGeometry(GraphSystem gs);
        public abstract Figure FigureCopy(Figure item, int px);
        public override GraphItem Copy(GraphItem item, int px) 
        {return FigureCopy((Figure)item, px);}
    }
}
