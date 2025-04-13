using System.Diagnostics;

namespace DmProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.GenerateRandomGraph(10, 0.3);
            var sw = new Stopwatch();
            sw.Start();
            var alg = new Algorithm();
            var m = alg.GetReachabilityMatrix(graph.GetMatrix());
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}");

            graph.PrintMatrix();

            
            PrintMatrix.PrintM(m);
            
        }
    }
}
