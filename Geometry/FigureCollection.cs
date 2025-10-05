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
    public class FigureCollection : IAddFigure
    {
        public FigureCollection() {
            GfList = new List<GeometryFigure>();
        }


        List<GeometryFigure> gfList;
        //vajag public property, lai strādātu serializācija
        public List<GeometryFigure> GfList { get => gfList; set => gfList = value; }

        //nepieciešams, lai implementētu interfeisu IAddFigure
        public void Add(GeometryFigure figure)
        {
            GfList.Add(figure);
        }

        //izdrukā informāciju par figūru sarakstu, izmantos DataManager
        public string Print()
        {
            string s = "Figure list: " + Environment.NewLine;
            foreach (GeometryFigure figure in GfList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            return s;
        }
    }
}
