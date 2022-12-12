
string text = System.IO.File.ReadAllText("input.txt");
List<string> lines = text.Split("\r\n").ToList();
var lineLength = lines[0].Length + 2;
var lineCount = lines.Count;
var startIndex = text.IndexOf('S');
var endIndex = text.IndexOf('E');

List<List<char>> charMap = lines.ConvertAll(s => s.ToCharArray().ToList());
List<List<int>> stepsMap;
List<List<bool>> visitedMap;

(int, int) startCoords = (startIndex % lineLength, (int) startIndex / lineLength);
(int, int) endCoords = (endIndex % lineLength, (int) endIndex / lineLength);

void Loop(int x, int y)
{
    char currentHeight = charMap[x][y];
    Console.WriteLine(currentHeight);
    foreach (var neighbor in new List<(int, int)>(){(x+1, y),(x, y-1),(x-1, y),(x, y+1)})
    {
        if ((0 <= neighbor.Item1 && neighbor.Item1 < lineLength) && (0 <= neighbor.Item1 && neighbor.Item1 < lineLength))
        {
            char n = charMap[neighbor.Item1][neighbor.Item2];
            Console.WriteLine($"Neighbor {x},{y} = {n}");
        }
    }
}


Loop(5, 1);


// abaacccccccccccccaaaaaaaccccccccccccccccccccccccccccccccccaaaaaa