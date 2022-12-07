using System;
using System.Collections.Generic;
using System.Linq;


namespace AOC_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            int current_value = 0;
            List<int> value_list = new List<int>();
            int top_n = 3;
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\eeli.hernesniemi\source\repos\AOC-01\AOC-01\data.txt"))
            {
                try
                {
                    int number = Int32.Parse(line);
                    current_value = current_value + number;
                }
                catch (FormatException)
                {
                    value_list.Add(current_value);
                    current_value = 0;
                }
            }
            value_list = value_list.OrderByDescending(i => i).ToList();

            int total = 0;
            for (int i = 0; i < top_n; i++)
            {
                total = total + value_list[i];
            }
            Console.WriteLine($"Total: {total}");
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
