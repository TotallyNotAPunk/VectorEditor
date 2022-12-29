using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    class GroupSelection : Selection
    {

        List<Selection> selectionList;
        public GroupSelection(Group _item) : base(_item)
        {
            selectionList = new List<Selection>();
        }
    }
}
