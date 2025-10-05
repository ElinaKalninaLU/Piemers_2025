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

//-----------------------------
string path = "C:\\Temp\\data.txt"; //pamainiet norādot savu ceļu uz datni, skat. P.S.1  
var dm = new GeometryXMLDataManager(path); // pamainiet lietojot savu Data Manager
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save();
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load();
Console.WriteLine(dm.Print());
Console.ReadLine();






