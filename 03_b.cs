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
            var group = new List<string>();

            foreach (string line in System.IO.File.ReadLines(path))
            {
                group.Add(line);
                if (group.Count == 3) 
                { 
                    char badge = group[0].Intersect(group[1]).Intersect(group[2]).First(); 
                    points = badge < 97 ? points + badge - 38 : points = points + badge - 96;
                    group.Clear();
                }
            }

            Console.WriteLine(points);
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
