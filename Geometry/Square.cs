using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Geometry
{
    public class Square : GeometryFigure
    {
		private int _edge;

		public int Edge
		{
			get { return _edge; }
			set {
				if (value > 0)
				{
					_edge = value;
				}
				else { 
					Debug.WriteLine("Malai jābūt >0"); 
				}
			
			}
		}
        [JsonIgnore]
        public override int Area => Edge*Edge;

        public override int Perimeter()
        {
            return 4*Edge;
        }

        public override string? ToString()
        {
            Debug.WriteLine("Square");
            return "Edge: " + Edge + ", "+ base.ToString() ;
        }

		public Square(int e) { Edge = e; MyColor = ColorEnum.Blue; }

		public Square() { MyColor = ColorEnum.Red; }

        public string izdruka()
        {
            return "Square";
        }
    }
}
