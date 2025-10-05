using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Geometry
{
    public class GeometryJSONDataManager2 : IAddFigure, IDataManager
    {
        private FigureCollection2 _fc;
        private string _path = "C:\\Temp\\test.xml";
        public GeometryJSONDataManager2()
        {
            _fc = new FigureCollection2();
        }

        public GeometryJSONDataManager2(string path) : this()
        {
            if (path != "")
                _path = path;
        }

        public void Add(GeometryFigure figure)
        {
            _fc.Add(figure);
        }

        public bool CreateTestData()
        {
            var sq = new Square();
            sq.Edge = 1;
            sq.myColor = ColorEnum.Red;

            Rectangle rec = new();
            rec.Height = 1;
            rec.Width = 2;
            var sq2 = new Square(5);
            Add(sq);
            Add(sq2);
            Add(rec);

            Polygon poly = new Polygon(1, 1, 0, 1, 1, 0, 0, 0);
            Add(poly);

            return true;
        }

        public bool Load()
        {
            try
            {
                if (File.Exists(_path))
                {
                    string jsonString = File.ReadAllText(_path);
                    FigureCollection2? f = JsonSerializer.Deserialize<FigureCollection2>(jsonString);
                     
                   if (f is not null) { _fc = f; }

                return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string Print()
        {
            return _fc.Print();
        }

        public bool Reset()
        {
            _fc = new FigureCollection2();
            return true;
        }

        public bool Save()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(_fc);
                File.WriteAllText(_path, jsonString);
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
