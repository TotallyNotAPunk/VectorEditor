using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal interface IGrProperties
    {
        IContourProps ContourProps { get; }
        IFillProps FillProps { get; }
    }
    internal class GrPropChannel : IGrProperties
    {
        public GrPropChannel(Factory f)
        {            
            contProp = f.contProp;
            fillProp = f.fillProp;
        }

        private ContourProps contProp;
        public IContourProps ContourProps => contProp;
        private FillProps fillProp;
        public IFillProps FillProps => fillProp;
    }
}
