partial class Program
{
    private int cycle;
    private List<int> interestingCycles;
    private int x;
    private int total;
    private string frame;

    public Program(List<int> interestingCycles)
    {
        this.interestingCycles = interestingCycles;
        cycle = 0;
        total = 0;
        x = 1;
        frame = "";
    }

    void incrementCycle()
    {
        int cc = cycle % 40;
        cycle++;
        frame += x > cc + 1 || x < cc - 1 ? '.' : '#';
        if (cycle % 40 == 0) { frame += '\n'; }
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
        Console.WriteLine(frame);
    }
}