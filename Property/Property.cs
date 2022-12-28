using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    abstract class Property
    {
        abstract public void Apply(GraphSystem gs);
    }
}
