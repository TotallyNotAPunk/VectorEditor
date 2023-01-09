using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    abstract class GraphItem
    {
        public Point BodyHitPoint { get; set; }
        public InternalGroupFrame InternalGroupFrame { get; set; }

        public Frame Frame { get; private set;}
        public GraphItem(Frame _frame)
        {
            if (Frame == null)
            {
                Frame = _frame;
                BodyHitPoint = new Point();
            }
        }
        public abstract GraphItem Copy(GraphItem item, int px);
        public void SetInternalGroupFrame(Frame frame)
        {
            InternalGroupFrame = new InternalGroupFrame(
                (double)(Frame.X - frame.X) / (frame.X2 - frame.X), 
                (double)(Frame.Y - frame.Y) / (frame.Y2 - frame.Y),
                (double)(Frame.X2 - Frame.X) / (frame.X2 - frame.X),
                (double)(Frame.Y2 - Frame.Y) / (frame.Y2 - frame.Y));
        }

        public virtual void SetNewFrame(Frame frame)
        {
            Frame = new Frame(
                (int)(frame.X + (InternalGroupFrame.Point.X * (frame.X2 - frame.X))),
                (int)(frame.Y + (InternalGroupFrame.Point.Y * (frame.Y2 - frame.Y))),
                (int)(Frame.X + ((frame.X2 - frame.X) * InternalGroupFrame.Width)),
                (int)(Frame.Y + ((frame.Y2 - frame.Y) * InternalGroupFrame.Height)));
        }

        public abstract void Draw(GraphSystem gs);

        public abstract Selection CreateSelection();

        public abstract bool InBody(int x, int y);
        
    }

    class PointDouble
    {
        public PointDouble(double x, double y)
        {
            X = x;
            Y = y;
        }

        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

    }

    class InternalGroupFrame
    {        
        private PointDouble point;
        public PointDouble Point
        {
            get { return point; }
            set { point = value; }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
       
        public InternalGroupFrame(double x, double y, double _width, double _height)
        {
            Point = new PointDouble(x, y);
            Width= _width;
            Height= _height;
        }
    }
}
