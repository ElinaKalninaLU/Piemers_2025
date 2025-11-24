using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Geometry;

namespace SQLiteClasses
{
    public class RectangleLite : IRectangle
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Name { get; set; }
        public ColorEnum? MyColor { get; set; } = ColorEnum.Green;

        public override string? ToString()
        {
            return $"Rectangle H:{Height}, W:{Width}";
        }
    }
}
