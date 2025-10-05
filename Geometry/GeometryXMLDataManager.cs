using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Geometry
{
    public class GeometryXMLDataManager:IAddFigure, IDataManager
    {
        private FigureCollection _fc;
        private string _path = "C:\\Temp\\test.xml";
        public GeometryXMLDataManager() {
        _fc = new FigureCollection();
        }

        public GeometryXMLDataManager(string path):this()
        {
            if (path!="")
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

            Polygon poly = new Polygon(1,1,0,1,1,0,0,0);
            Add(poly);

            return true;
        }

        public bool Load()
        {
            try
            {
                if (File.Exists(_path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FigureCollection));
                    using (TextReader reader = new StreamReader(_path))
                    {
                        var f = (FigureCollection)serializer.Deserialize(reader);
                        if (f is not null) { _fc = f; }
                    }
                    return true;
                }
                else return false;
            }
            catch (Exception ex) {
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
            _fc = new FigureCollection();
            return true;
         }

        public bool Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FigureCollection));
                using (TextWriter writer = new StreamWriter(_path))
                {
                    serializer.Serialize(writer, _fc);
                }
                return true;
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            return false;
            }
        }
    }
}
