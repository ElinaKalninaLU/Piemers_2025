using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteClasses
{
    public interface IRectangle
    {
        public int ID { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Name { get; set; }
        public ColorEnum? MyColor { get; set; }
    }
}
