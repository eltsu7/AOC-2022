using System;

namespace AOC_02
{
    class Program
    {
        static int Shape_points(char shape)
        {
            if (shape == 'X')
            {
                return 1;
            }
            else if (shape == 'Y')
            {
                return 2;
            }
            else if (shape == 'Z')
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        static int Match_points(char opponent, char me)
        {
            // A B C
            // X Y Z

            if ((opponent == 'A' && me == 'Y')
                || (opponent == 'B' && me == 'Z')
                || (opponent == 'C' && me == 'X'))
            {
                return 6;
            }
            else if ((opponent == 'A' && me == 'X')
                || (opponent == 'B' && me == 'Y')
                || (opponent == 'C' && me == 'Z'))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var path = "C:/Users/eeli.hernesniemi/source/repos/AOC-02/AOC-02/input.txt";

            int score = 0;
            char opponent;
            char me;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                opponent = line[0];
                me = line[2];

                score = score + Match_points(opponent, me) + Shape_points(me);
            }

            Console.WriteLine(score);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
