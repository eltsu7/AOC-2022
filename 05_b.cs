using System;
using System.Collections.Generic;

namespace aoc_05
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            const string path = "C:/Users/eeli.hernesniemi/source/repos/aoc_05/aoc_05/input.txt";
            string[] lines = System.IO.File.ReadAllLines(path);

            var stacks = new List<Stack<char>>();
            int num_of_stacks = (lines[0].Length / 4) + 1;
            for (int num = 0; num < num_of_stacks; num++)
            {
                stacks.Add(new Stack<char>());
            }

            int max_stack = 0;
            while (lines[max_stack][1] != '1')
            {
                max_stack++;
            }

            for (int i = max_stack - 1; i >= 0; i--)
            {
                for (int j = 0; j < num_of_stacks; j++)
                {
                    if (lines[i][(j * 4) + 1] != ' ')
                    {
                        stacks[j].Push(lines[i][(j * 4) + 1]);
                    }
                }
            }

            var temp_list = new List<char>();
            for (int i = max_stack + 2; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                for (int j = 0; j < int.Parse(line[1]); j++)
                {
                    temp_list.Add(stacks[int.Parse(line[3]) - 1].Pop());
                }
                temp_list.Reverse();
                foreach (var num in temp_list)
                {
                    stacks[int.Parse(line[5]) - 1].Push(num);
                }
                temp_list.Clear();
            }

            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek());
            }
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
