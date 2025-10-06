using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Polygon:GeometryFigure
    {
        List<Point> points;

        public List<Point> Points { get => points; set => points = value; }

        public Polygon()
        {
            points = new List<Point>();
        }
        public Polygon(params int[] points) : this()
        {
            if (points.Length > 0 && points.Length % 2 == 0)
            {
                int i = 0;
                int x = 0;
                foreach (var p in points)
                {
                    if (i % 2 == 0)
                    {
                        x = p;
                    }
                    else
                    {
                        Points.Add(new Point(x, p));
                    }
                    i++;
                }
            }
        }
        public override string? ToString()
        {
            string pList = "";
            foreach (var point in Points)
            {
                pList += point.ToString() + ", ";
            }
            if (pList != "" && pList.Length > 2) { pList = pList.Substring(0, pList.Length - 2); }
            return base.ToString() + " Point list: " + pList;
        }
    }
}
