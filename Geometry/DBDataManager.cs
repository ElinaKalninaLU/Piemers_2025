using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class DBDataManager : IDataManager
    {
        public FigureAddManager fc { get; set; }
        public GeometryContext gc { get; set; }

        public DBDataManager()
        {
            gc = new GeometryContext();
           fc = new FigureAddManager(gc);
        }

        public bool CreateTestData()
        {
            var sq = new Square();
            sq.Edge = 1;
            gc.Squares.Add(sq);
            Rectangle rec = new();
            rec.Height = 1;
            rec.Width = 2;
            gc.Rectangles.Add(rec);
            Polygon poly = new Polygon(1, 1, 0, 1, 1, 0, 0, 0);
            gc.Polygons.Add(poly);
            return true;
        }

        public bool Load()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string Print()
        {
            string s = "Rectangles: " + Environment.NewLine;
            foreach (var figure in gc.Rectangles)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            s += "Squares: " + Environment.NewLine;
            foreach (var figure in gc.Squares)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            s += "Polygons: " + Environment.NewLine;
            foreach (var figure in gc.Polygons)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            s += "Points: " + Environment.NewLine;
            foreach (var figure in gc.Points)
            {
                s += figure.ToString() + Environment.NewLine;
            }
            return s;

        }

        public bool Reset()
        {
            //     fc = new FigureCollection();
            return true;
        }

        public bool Save()
        {
            try
            {
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
