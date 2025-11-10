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
            GfList = new List<GeometryFigure>();
        }

        List<GeometryFigure> gfList;

        public List<GeometryFigure> GfList { get => gfList; set => gfList = value; }

        public void Add(GeometryFigure figure)
        {
            GfList.Add(figure);
        }

        public string Print()
        {
            string s = "Figure list: " + Environment.NewLine;
            foreach (GeometryFigure figure in GfList)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            return s;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
