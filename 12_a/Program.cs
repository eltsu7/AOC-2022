
string text = System.IO.File.ReadAllText("input.txt");
List<string> lines = text.Split("\r\n").ToList();
var lineLength = lines[0].Length + 2;
var lineCount = lines.Count;
var startIndex = text.IndexOf('S');
var endIndex = text.IndexOf('E');

List<List<char>> charMap = lines.ConvertAll(s => s.ToCharArray().ToList());
List<List<int>> stepsMap;
List<List<bool>> visitedMap;
var visitedCoordinates = new List<(int, int)>();

(int, int) startCoords = ((int) startIndex / lineLength, startIndex % lineLength);
(int, int) endCoords = ((int) endIndex / lineLength, endIndex % lineLength);

bool inBounds((int, int) coords) { return (0 <= coords.Item1 && coords.Item1 < lineLength - 2) && (0 <= coords.Item2 && coords.Item2 < lineLength - 2); }
bool notVisited ((int, int) coords) { return !visitedCoordinates.Contains(coords); }
bool canTravel((int, int) pointA, (int, int) pointB) { return (Math.Abs(charMap[pointA.Item1][pointA.Item2] - charMap[pointB.Item1][pointB.Item2]) < 2); }

List<(int, int)> getNeighbors((int, int) coords)
{
    var x = coords.Item1;
    var y = coords.Item2;
    var validNeighbors = new List<(int, int)>();
    foreach (var neighbor in new List<(int, int)>(){(x+1, y),(x, y-1),(x-1, y),(x, y+1)})
    {
        if (neighbor == endCoords)
        {
            Console.WriteLine("End found!");
            System.Environment.Exit(0);
        }
        if (inBounds(neighbor) && notVisited(neighbor))
        {
            // Console.WriteLine((int)charMap[x][y]);
            // Console.WriteLine((int)charMap[neighbor.Item1][neighbor.Item2]);
            // Console.WriteLine((int)charMap[x][y] - charMap[neighbor.Item1][neighbor.Item2]);
            if (canTravel(coords, neighbor) || charMap[x][y] == 'S')
            {
                validNeighbors.Add(neighbor);
            }
            // else
            // {
            //     Console.WriteLine($"{x},{y}={charMap[x][y]} .. {neighbor.Item1},{neighbor.Item2}={charMap[neighbor.Item1][neighbor.Item2]}");
            // }
        }
    }
    return validNeighbors;
}

var currentStep = new List<(int, int)>() {startCoords};
var nextStep = new List<(int, int)>();
for (int i = 0; i < 100; i++)
{
    // Console.WriteLine(i);
    // foreach (var item in currentStep.Distinct())
    // {
    //     Console.WriteLine($"{item.Item1},{item.Item2} = {charMap[item.Item1][item.Item2]}");
    // }
    Console.WriteLine(currentStep.Count);
    visitedCoordinates.AddRange(currentStep);
    visitedCoordinates = visitedCoordinates.Distinct().ToList();
    foreach (var coord in currentStep)
    {
        nextStep.AddRange(getNeighbors(coord));
    }
    nextStep = nextStep.Distinct().ToList();
    currentStep = new List<(int, int)>(nextStep);
    nextStep.Clear();
}

// abaacccccccccccccaaaaaaaccccccccccccccccccccccccccccccccccaaaaaa