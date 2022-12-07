using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            const string path = "C:/Users/eelih/Documents/Koodit/aoc_03/aoc_03/input.txt";
            int points = 0;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                int halfway = line.Length / 2;
                List<char> comp_a = line.ToList().GetRange(0, halfway);
                List<char> comp_b = line.ToList().GetRange(halfway, halfway);
                int item = comp_a.Intersect(comp_b).First();
                points = item < 97 ? points + item - 38 : points = points + item - 96;
            }

            Console.WriteLine(points);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
