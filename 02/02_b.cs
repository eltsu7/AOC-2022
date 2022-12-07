using System;
using System.Collections.Generic;

namespace AOC_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var path = "C:/Users/eeli.hernesniemi/source/repos/AOC-02/AOC-02/input.txt";

            int score = 0;
            char opponent;
            char strategy;

            char[] shapes = "ABC".ToCharArray();
            char[] extended_shapes = "CABCA".ToCharArray();
            var offsets = new Dictionary<char, int>()
            {
                { 'X', -1 },
                { 'Y', 0 },
                { 'Z', 1 },
            };

            var match_points = new Dictionary<char, int>()
            {
                { 'X', 0 },
                { 'Y', 3 },
                { 'Z', 6 },
            };

            var shape_points = new Dictionary<char, int>()
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 },
            };

            foreach (string line in System.IO.File.ReadLines(path))
            {
                opponent = line[0];
                strategy = line[2];

                score = score + match_points[strategy] + shape_points[extended_shapes[(Array.IndexOf(shapes, opponent) + 1 + offsets[strategy])]];
            }

            Console.WriteLine(score);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
