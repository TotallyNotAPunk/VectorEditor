using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    internal class Frame
    {

        public Frame(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;  
            X2 = x2;
            Y2 = y2;
        }        
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int x2;
        public int X2
        {
            get { return x2; }
            set { x2 = value; }
        }

        private int y2;
        public int Y2
        {
            get { return y2; }
            set { y2 = value; }
        }


    }





}
