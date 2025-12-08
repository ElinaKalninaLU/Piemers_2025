// See https://aka.ms/new-console-template for more information
using Lekcija14;
using System.Diagnostics;

Console.WriteLine("Process!");
//var procInfo = new ProcessStartInfo();
//procInfo.FileName = "Notepad.exe";
//procInfo.Arguments = "C:\\Temp\\ConnS.txt";
//procInfo.WorkingDirectory = "C:\\Temp\\";
//procInfo.WindowStyle = ProcessWindowStyle.Maximized;
//procInfo.ErrorDialog = true;
//var proc = new Process();
//proc.StartInfo = procInfo;
//proc.Start();

Console.WriteLine("Threads!");
var l = new L14Class();
var ts = new ThreadStart(l.executeSimpleThread);
var newThread = new Thread(ts);
newThread.Start();

var ts2 = new ParameterizedThreadStart(l.executeThreadwithParam);
var newThread2 = new Thread(ts2);
newThread2.Start("Lekcija 14");

int workerTh, ComplitionPortTh;
ThreadPool.GetMaxThreads(out workerTh, out ComplitionPortTh);
Console.WriteLine($"Threads max {workerTh}, {ComplitionPortTh}");


Console.WriteLine("ParallelFor!");

Parallel.For(0, 16, (i) =>
{
    Console.WriteLine(i);
});

