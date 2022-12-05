static void moi()
{
    const string path = "C:/Users/eeli.hernesniemi/source/repos/aoc_05/aoc_05/input.txt";
    string[] lines = System.IO.File.ReadAllLines(path);

    var stacks = new List<string>();
    int num_of_stacks = (lines[0].Length / 4) + 1;
    for (int num = 0; num < num_of_stacks; num++)
    {
        stacks.Add("");
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
                stacks[j] += lines[i][(j * 4) + 1];
            }
        }
    }

    string temp;
    int count;
    int from;
    int to;
    for (int i = max_stack + 2; i < lines.Length; i++)
    {
        string[] line = lines[i].Split(' ');
        count = int.Parse(line[1]);
        from = int.Parse(line[3]) - 1;
        to = int.Parse(line[5]) - 1;

        temp = stacks[from].Substring(stacks[from].Length - count);

        stacks[from] = stacks[from].Remove(stacks[from].Length - count);
        stacks[to] += temp;
    }
}

var watch = new System.Diagnostics.Stopwatch();
watch.Start();
for (int i = 0; i < 100000; i++)
{
    moi();
}
watch.Stop();
Console.WriteLine();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
Console.ReadKey();
