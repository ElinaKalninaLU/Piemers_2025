using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class FigureCollection : IAddFigure
    {
        public FigureCollection() {
            gfList = new List<GeometryFigure>();
        }

        List<GeometryFigure> gfList;

        public void Add(GeometryFigure figure)
        {
            gfList.Add(figure);
        }

        public string Print()
        {
            string s = "Figure list: " + Environment.NewLine;
            foreach (GeometryFigure figure in gfList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            return s;
        }
    }
}
