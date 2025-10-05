using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Geometry
{
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Polygon))]

    public class FigureCollection2 : IAddFigure
    {
        public FigureCollection2() {
            SqList = new();
            RcList = new();
            plList = new();
        }


        List<Square> sqList;
        List<Rectangle> rcList;
        List<Polygon> plList;

        public List<Square> SqList { get => sqList; set => sqList = value; }
        public List<Rectangle> RcList { get => rcList; set => rcList = value; }
        public List<Polygon> PlList { get => plList; set => plList = value; }

        //vajag public property, lai strādātu serializācija

        //nepieciešams, lai implementētu interfeisu IAddFigure
        public void Add(GeometryFigure figure)
        {
            if (figure is Square)
            {
                SqList.Add((Square)figure);
            }
            else if (figure is Rectangle)
            {
                RcList.Add((Rectangle)figure);
            }
            else if (figure is Polygon)
            {
                PlList.Add((Polygon)figure);
            }

        }

        //izdrukā informāciju par figūru sarakstu, izmantos DataManager
        public string Print()
        {
            string s = "Square list: " + Environment.NewLine;
            foreach (Square figure in SqList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            s += "Rectangle list: " + Environment.NewLine;
            foreach (Rectangle figure in RcList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            s += "Polygon list: " + Environment.NewLine;
            foreach (Polygon figure in PlList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            return s;
        }
    }
}
