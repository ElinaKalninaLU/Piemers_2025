using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Polygon:GeometryFigure
    {
        private List<Point> _pointList;

        public List<Point> PointList { get => _pointList; set => _pointList = value; }

        public Polygon() { 
        _pointList = new List<Point>();
        }
        public Polygon(params int[] points) :this()
        {
            if (points.Length > 0 && points.Length % 2 == 0)
            {
                int i = 0;
                int x =0;
                foreach (var p in points)
                {
                    if (i % 2 == 0)
                    {
                        x = p;
                    }
                    else { 
                    PointList.Add(new Point(x, p));
                    }
                    i++;
                }
            }
        }
        public override string? ToString()
        {
            string pList = "";
            foreach (var point in PointList)
            {
                pList += point.ToString() + ", ";
            }
            if (pList != "" && pList.Length>2) { pList = pList.Substring(0, pList.Length - 2); }
            return base.ToString() + " Point list: " + pList;
        }
    }
}
