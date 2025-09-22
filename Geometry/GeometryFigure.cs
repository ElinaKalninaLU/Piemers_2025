using System.Diagnostics;

namespace Geometry
{
    public abstract class GeometryFigure
    {
        public string Name { get; set; }

        public override string? ToString()
        {
            Debug.WriteLine("Base");
            return base.ToString() + "Name: " + Name + ", Area: " + Area + ", Perimeter " + Perimeter();
        }

        public virtual int Area { get; } = 0;

        public virtual int Perimeter() { return 0; }

        public string izdruka()
        {
            return "Base";
        }

	}
}
