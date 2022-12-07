void aoc() {
    const string path = "C:/Users/eelih/Documents/Koodit/AOC/aoc_06/input.txt";
    var list = new List<int>();
    int marker_size = 4;
    int index = marker_size;
    using (StreamReader sr = new StreamReader(path)) {
        for (int i = 0; i < marker_size; i++)
        {
            list.Add(sr.Read());
        }
        while (true) {
            if (list.Distinct().Count() == marker_size) {
                break;
            }
            list.Add(sr.Read());
            list.RemoveAt(0);
            index++;
        }
        Console.WriteLine($"Index: {index}");
    }
}

var watch = new System.Diagnostics.Stopwatch();
watch.Start();
for (int i = 0; i < 1; i++)
{
    aoc();
}
watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
Console.ReadKey();
