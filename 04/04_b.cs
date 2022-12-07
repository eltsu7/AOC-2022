using System;
using System.Text.RegularExpressions;

namespace aoc_04
{
    class Program
    {
        static void Main()
        {
            const string path = "C:/Users/eelih/source/repos/aoc_04/aoc_04/input.txt";
            int count = 0;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                var numbers = Array.ConvertAll(Regex.Split(line, "-|,"), int.Parse);
                if (!((numbers[1] < numbers[2]) || (numbers[0] > numbers[3])))
                {
                    count += 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}
