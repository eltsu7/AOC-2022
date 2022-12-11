using System.Linq;

class Monki
{
    private char operation;
    private bool useOldValue;
    private int operationValue;
    private int testValue;
    private int divider;
    private (int, int) monkiFrends;
    public int inspections;
    public List<int> items;
    public Monki(string[] input, int divider)
    {
        this.divider = divider;
        inspections = 0;
        items = Array.ConvertAll(input[1].Substring(18).Split(", "), s => int.Parse(s)).ToList();
        operation = input[2][23];
        useOldValue = input[2].Substring(25) == "old";
        testValue = int.Parse(input[3].Substring(21));
        if (!useOldValue) { operationValue = int.Parse(input[2].Substring(25)); }
        monkiFrends = (int.Parse(input[4].Substring(29)), int.Parse(input[5].Substring(30)));
    }
    public (int, int) MakeMonkiBusiness()
    {
        inspections++;
        long old = (long)items[0]; items.RemoveAt(0);
        long worry=(useOldValue?operation=='+'?old+old:old*old:operation=='+'?old+operationValue:old*operationValue)%divider;
        return ((int)worry, worry % testValue == 0 ? monkiFrends.Item1 : monkiFrends.Item2);
    }
}

class Main
{
    private List<Monki> monkis;
    public Main(string path)
    {
        monkis = new List<Monki>();
        int divider = 1;
        var monkiLines = System.IO.File.ReadAllLines(path).ToList();
        for (int i = 0; i < (monkiLines.Count + 1) / 7; i++)
        {
            divider = divider * int.Parse(monkiLines[(i * 7) + 3].Substring(21));
        }
        while (monkiLines.Count() > 1)
        {
            monkis.Add(new Monki(monkiLines.GetRange(0, 6).ToArray(), divider));
            if (monkiLines.Count > 6) {monkiLines.RemoveRange(0, 7);} else {monkiLines.RemoveRange(0, 6);}
        }
        for (int i = 0; i < 10000; i++)
        {
            foreach (var monki in monkis)
            {
                while (monki.items.Count > 0)
                {
                    (int, int) passItem = monki.MakeMonkiBusiness();
                    monkis[passItem.Item2].items.Add(passItem.Item1);
                }
            }
        }
        foreach (var monki  in monkis) { Console.WriteLine(monki.inspections); }
        monkis = monkis.OrderByDescending(m => m.inspections).ToList();
        Console.WriteLine($"Monki bisnes: {(ulong)monkis[0].inspections * (ulong)monkis[1].inspections}");
    }
}