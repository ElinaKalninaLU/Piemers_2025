using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Geometry
{
    public class JSONDataManager : IDataManager, IAddFigure
    {
        public FigureCollection fc { get; set; }
        public string path { get; set; } = "C:\\Temp\\data.txt";

        public JSONDataManager() { 
        fc = new FigureCollection();
        }
        public JSONDataManager(string _path) : this() 
        {
            this.path = _path;
        }

        public bool CreateTestData()
        {
            var sq = new Square();
            sq.Edge = 1;
            fc.Add(sq);
            Rectangle rec = new();
            rec.Height = 1;
            rec.Width = 2;
            fc.Add(rec);
            Polygon poly = new Polygon(1, 1, 0, 1, 1, 0, 0, 0);
            fc.Add(poly);
            return true;
        }

        public bool Load()
        {
            try
            {
                if (File.Exists(path))
                {
                    string jsonString = File.ReadAllText(path);
                    FigureCollection? f =
                     JsonSerializer.Deserialize<FigureCollection>(jsonString);

                    if (f is not null) { fc = f; }

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
            return fc.Print();
        }

        public bool Reset()
        {
            fc = new FigureCollection();
            return true;
        }

        public bool Save()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(fc);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void Add(GeometryFigure figure)
        {
            fc.Add(figure);
        }
    }
}
