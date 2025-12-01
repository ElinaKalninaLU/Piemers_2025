using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Geometry
{
    public class GeometryContext:DbContext
    {
        public GeometryContext(DbContextOptions<GeometryContext> options)
            : base(options)
        {
        }

        public GeometryContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      //        string cs = ConfigurationManager.ConnectionStrings["GeometryDB"].ConnectionString;
       //     string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Geometry2025;Integrated Security=True;Connect Timeout=30;Encrypt=True;";
        //    optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Polygon> Polygons { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Square> Squares { get; set; }

    }
}
