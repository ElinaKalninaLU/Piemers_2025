using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Geometry
{
   // Anotācijas, lai varētu izmnatot JSON serializāciju kolekcijai ar apakštipiem
    [JsonDerivedType(typeof(Square), typeDiscriminator: "Square")]
    [JsonDerivedType(typeof(Rectangle), typeDiscriminator: "Rectangle")]
    [JsonDerivedType(typeof(Polygon), typeDiscriminator: "Polygon")]
    public abstract class GeometryFigure
    {
        public string Name { get; set; }

        public ColorEnum MyColor { get; set; } = ColorEnum.Green;

        public override string? ToString()
        {
            Debug.WriteLine("Base");
            return base.ToString() + "Name: " + Name + ", Area: " + Area + ", Perimeter " + Perimeter() + ", MyColor " + MyColor.ToString();
        }
        [JsonIgnore]
        public virtual int Area { get; } = 0;

        public virtual int Perimeter() { return 0; }

        public string izdruka()
        {
            return "Base";
        }

	}
}
