using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditor;


namespace VectorEditor
{
    public enum FigureType
    { 
        Line,
        Rect
    }
    public interface IFactory
    {
        FigureType FigureType { get; set; }     
        void CreateAndGrabItem(int x, int y);
        void grabItem(int x, int y);
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
        public void grabItem(int x, int y) 
        {
            SelectionsController.SelectionStore.TryGrab(x, y).TryGrab(x,y);
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
            {
                FillProps tmpFillProp = new FillProps(fillProp.Color);
                property.Add(tmpConProp);
                property.Add(tmpFillProp);
                Rect rect = new Rect(new Frame(x, y, x, y), property);
                store.Add(rect);
                return rect;
            }           
        }


        public FigureType FigureType { get; set; }
        public Store store { get; set; }
        public ContourProps contProp { get; set; }
        public FillProps fillProp { get; set; }
    }
}
