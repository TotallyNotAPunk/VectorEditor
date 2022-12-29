using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VectorEditor;

namespace VectorEditor
{
    public enum FigureType 
    { 
        Line,
        Rect,
        Ellipse
    }
    public interface IFactory
    {
        FigureType FigureType { get; set; }
        void CreateAndGrabItem(int x, int y);
    }
    class Factory : IFactory
    {
        public Factory(Store store, SelectionsController sc)
        {
            this.store = store;
            FigureType = FigureType.Line;
            contProp = new ContourProps(System.Drawing.Color.Black, 5);
            fillProp = new FillProps(System.Drawing.Color.White);
            SelectionsController = sc;
        }       

        public void CreateAndGrabItem(int x, int y)
        {
            GraphItem item = CreateItem(x,y);
            SelectionsController.SelectAndGrabItem(item, x, y);
        }

        private SelectionsController selectionsController;
        public SelectionsController SelectionsController
        {
            get { return selectionsController; }
            set { selectionsController = value; }
        }
        public GraphItem CreateItem(int x, int y)
        {            
            PropList property = new PropList();
            ContourProps tmpConProp = new ContourProps(contProp.Color, contProp.LineWidth);
            if (FigureType == FigureType.Line)
            {                
                property.Add(tmpConProp);
                Line line = new Line(new Frame(x, y, x, y), property);
                store.Add(line);
                return line;
            }
            else
            if (FigureType == FigureType.Rect)
            {
                FillProps tmpFillProp = new FillProps(fillProp.Color);
                property.Add(tmpConProp);
                property.Add(tmpFillProp);
                Rect rect = new Rect(new Frame(x, y, x, y), property);
                store.Add(rect);
                return rect;
            }  
            else
            {
                FillProps tmpFillProp = new FillProps(fillProp.Color);
                property.Add(tmpConProp);
                property.Add(tmpFillProp);
                Ellipse ellipse = new Ellipse(new Frame(x, y, x, y), property);
                store.Add(ellipse);
                return ellipse;
            }
        }

        public static Group NewGroup(List<GraphItem> items)
        {          
            Frame baseFrame = new Frame(items[0].Frame.X, items[0].Frame.Y, items[0].Frame.X2, items[0].Frame.Y2);

            for (int i = 1; i < items.Count; i++)
            {
                int tmpX = findMin(new List<int>() { baseFrame.X, baseFrame.X2, items[i].Frame.X, items[i].Frame.X2 });
                int tmpY = findMin(new List<int>() { baseFrame.Y, baseFrame.Y2, items[i].Frame.Y, items[i].Frame.Y2 });

                int tmpX2 = findMax(new List<int>() { baseFrame.X, baseFrame.X2, items[i].Frame.X, items[i].Frame.X2 });
                int tmpY2 = findMax(new List<int>() { baseFrame.Y, baseFrame.Y2, items[i].Frame.Y, items[i].Frame.Y2 });

                baseFrame.X = tmpX;
                baseFrame.Y = tmpY;

                baseFrame.X2 = tmpX2;
                baseFrame.Y2 = tmpY2;

            }
            Group group = new Group(baseFrame);
            group.graphItems.AddRange(new List<GraphItem>(items));

            foreach (var item in group.graphItems)
            {
                item.SetInternalGroupFrame(group.Frame);
            }
            group.ChangeItemsInGroup();
            
            return group;
        }

        private static int findMin(List<int> values)
        {
            int min = values[0];
            foreach (int item in values)
            {
                if (item <= min)
                    min = item; 
            }
            return min;
        }

        private static int findMax(List<int> values)
        {
            int max = values[0];
            foreach (int item in values)
            {
                if (item >= max)
                    max = item;
            }
            return max;
        }



        public FigureType FigureType { get; set; }
        public Store store { get; set; }
        public ContourProps contProp { get; set; }
        public FillProps fillProp { get; set; }
    }
}
