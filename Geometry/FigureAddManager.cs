using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class FigureAddManager : IAddFigure, IRemove //, IGetFigureList
    {
        public GeometryContext gc { get; set; }

        public List<GeometryFigure> GfList
        {
            get
            {
                var gl = new List<GeometryFigure>();
                gl = gl.Union(gc.Rectangles.ToList()).
                    Union(gc.Squares.ToList()).
                    Union(gc.Polygons.ToList()).ToList();
                Debug.WriteLine(gl.Count());
                return gl;
            }
        }
        public FigureAddManager(GeometryContext _gc)
        {
            gc = _gc;
        }
        public void Add(GeometryFigure figure)
        {
            try
            {
                if (figure is Rectangle)
                {
                    gc.Rectangles.Add((Rectangle)figure);
                }
                else if (figure is Square)
                {
                    gc.Squares.Add((Square)figure);
                }
                else if (figure is Polygon)
                {
                    gc.Polygons.Add((Polygon)figure);
                }
                else { return; }
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        public bool Remove(GeometryFigure figure)
        {
            try
            {
                if (figure is Rectangle)
                {
                    gc.Rectangles.Remove((Rectangle)figure);
                }
                else if (figure is Square)
                {
                    gc.Squares.Remove((Square)figure);
                }
                else if (figure is Polygon)
                {
                    gc.Polygons.Remove((Polygon)figure);
                }
                else { return false; }
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void Save()
        {
            gc.SaveChanges();
        }
    }
}
