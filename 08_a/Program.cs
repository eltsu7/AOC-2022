
const string path = "C:/Users/eeli.hernesniemi/Koodit/AOC-2022/08_a/input.txt";

var lines = System.IO.File.ReadAllLines(path).ToList();
var vertical_lines = new List<string>();

var line_count = lines.Count;
var line_length = lines[0].Length;
var trees = new List<(int, int)>();

foreach (var line in lines)
{
    for (int j = 0; j < line_length; j++)
    {
        try
        {
            vertical_lines[j] += line[j].ToString();
        }
        catch (System.ArgumentOutOfRangeException)
        {
            vertical_lines.Add(line[j].ToString());
        }
    }
}

void Calculate(bool flip_coords, List<string> lines, List<(int, int)> trees)
{
    int current_height;
    for (int x = 0; x < lines.Count; x++){
        var line = lines[x];
        current_height = -1;
        for (int y = 0; y < line.Length; y++)
        {
            if (current_height < (int)line[y])
            {
                AddTree(flip_coords, x, y, trees);
                current_height = (int)line[y];
            }
        }
        current_height = -1;
        for (int y = line.Length - 1; y >= 0 ; y--)
        {
            if (current_height < (int)line[y])
            {
                AddTree(flip_coords, x, y, trees);
                current_height = (int)line[y];
            }
        }
    }
}

void AddTree(bool flip_coords, int x, int y, List<(int, int)> trees)
{
    if (!flip_coords) {if (!trees.Contains((x, y))) {trees.Add((x, y));}}
    else {if (!trees.Contains((y, x))) {trees.Add((y, x));}}
}

Calculate(false, lines, trees);
Calculate(true, vertical_lines, trees);

Console.WriteLine(trees.Count);
