// See https://aka.ms/new-console-template for more information
using DBFirst;
using Geometry;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

using (var gc = new GeometryContext())
{
    var r = new Rectangle() { Height = 3, Width = 2 };
    gc.Rectangles.Add(r);
    gc.SaveChanges();
    Console.WriteLine(gc.Rectangles.Count().ToString());
}

//using (var sc = new StudentiContext())
//{
//    var s = sc.Students.First() as Student;
//    Console.WriteLine(s.FullName);
//}
//try { 
//var cnAcess = new Microsoft.Data.SqlClient.SqlConnection();
//cnAcess.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;";
//cnAcess.Open();
//var cmd = new Microsoft.Data.SqlClient.SqlCommand();
//cmd.Connection = cnAcess;
//cmd.CommandType = CommandType.Text;
//cmd.CommandText = "select max(Student_ID)+1 from Student";
//int i = (int)cmd.ExecuteScalar();
//cnAcess.Close();
//Console.WriteLine("i:" + i);
//}
//catch (Exception ex)
//{ 
//    Console.WriteLine(ex.ToString());
//}

