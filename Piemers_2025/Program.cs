using Geometry;

// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

var sq = new Square(); 
sq.Edge = 1;

Console.WriteLine(sq);

Rectangle rec = new();
rec.Height = 1;
rec.Width = 2;
Console.WriteLine(rec);

int i = int.Parse(Console.ReadLine());
var sq2 = new Square(i);
Console.WriteLine(sq2);
Console.WriteLine(sq2.izdruka());
GeometryFigure gf = sq2;
Console.WriteLine(gf.izdruka());
Console.WriteLine(gf);

var fc = new FigureCollection();
fc.Add(sq);
fc.Add(sq2);
fc.Add(rec);
Console.WriteLine(fc.Print());





