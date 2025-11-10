using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IAddFigure
    {
        void Add(GeometryFigure figure);

        void Save();
    }
}
