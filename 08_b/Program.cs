using System;

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

const string path = "C:/Users/eeli.hernesniemi/Koodit/AOC-2022/08_a/input.txt";
var lines = System.IO.File.ReadAllLines(path).ToList();
var verticalLines = new List<string>();

var lineCount = lines.Count;
var lineLength = lines[0].Length;
var trees = new Dictionary<(int, int), int>();

foreach (var line in lines)
{
    for (int j = 0; j < lineLength; j++)
    {
        try
        {
            verticalLines[j] += line[j].ToString();
        }
        catch (System.ArgumentOutOfRangeException)
        {
            verticalLines.Add(line[j].ToString());
        }
    }
}

for (int y = 1; y < lineLength-1; y++)
{
    var hLine = lines[y];
    for (int x = 0; x < hLine.Length-1; x++)
    {
        var vLine = verticalLines[x];
        trees.Add((x,y), CalculateScenicScore(hLine, vLine, x, y));
    }
}

Console.WriteLine(trees.Values.Max());

int CalculateScenicScore(string hLine, string vLine, int x, int y)
{

    int right = CalculateVisibility(hLine.Substring(x));
    int left = CalculateVisibility(new string(hLine.Substring(0, x + 1).ToCharArray().Reverse().ToArray()));
    int down = CalculateVisibility(vLine.Substring(y));
    int up = CalculateVisibility(new string(vLine.Substring(0, y + 1).ToCharArray().Reverse().ToArray()));

    return right * left * down * up;
}

int CalculateVisibility(string line)
{
    int score = 0;
    for (int i = 1; i < line.Length; i++)
    {
        score++;
        if (line[0] <= line[i]){
            break;
        }
    }
    return score;
}

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
Console.ReadKey();