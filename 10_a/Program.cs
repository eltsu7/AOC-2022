partial class Program
{
    private int cycle;
    private List<int> interestingCycles;
    private int x;
    private int total;

    public Program(List<int> interestingCycles)
    {
        this.interestingCycles = interestingCycles;
        cycle = 0;
        total = 0;
        x = 1;
    }

    void incrementCycle()
    {
        cycle++;
        if (interestingCycles.Contains(cycle))
        {
            total += cycle * x;
            Console.WriteLine($"Cycle {cycle} value: {x}, total: {total}");
        }
    }

    void run(string path)
    {
        foreach (string line in System.IO.File.ReadLines(path))
        {
            if (line == "noop")
            {
                incrementCycle();
                continue;
            }
            incrementCycle();
            incrementCycle();
            x += int.Parse(line.Substring(5));
        }
    }
}