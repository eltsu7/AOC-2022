string text = System.IO.File.ReadAllText("input.txt");
List<string> lines = text.Split("\r\n").ToList();
var lineLength = lines[0].Length + 2;
var lineCount = lines.Count;
var startIndex = text.IndexOf('S');
var endIndex = text.IndexOf('E');

(int, int) startCoords = ((int) startIndex / lineLength, startIndex % lineLength);
(int, int) endCoords = ((int) endIndex / lineLength, endIndex % lineLength);

List<List<char>> charMap = lines.ConvertAll(s => s.ToCharArray().ToList());
var visitedCoordinates = new List<(int, int)>();

bool isInBounds((int, int) coords) { return (0 <= coords.Item1 && coords.Item1 < lineCount) && (0 <= coords.Item2 && coords.Item2 < lineLength - 2); }
bool isNotVisited ((int, int) coords) { return !visitedCoordinates.Contains(coords); }
bool canTravel(char a, char b) { return a - b < 2; }

List<(int, int)> GetNeighbors((int, int) coords)
{
    var x = coords.Item1;
    var y = coords.Item2;
    var currentHeigh = coords == startCoords ? 'a': charMap[coords.Item1][coords.Item2];
    if (coords == endCoords) { currentHeigh = 'z'; }
    var validNeighbors = new List<(int, int)>();
    foreach (var neighborCoords in new List<(int, int)>(){(x+1, y),(x, y-1),(x-1, y),(x, y+1)})
    {
        if (isInBounds(neighborCoords) && isNotVisited(neighborCoords))
        {
            char neighborHeight = neighborCoords == endCoords ? 'z' : charMap[neighborCoords.Item1][neighborCoords.Item2];
            if (canTravel(currentHeigh, neighborHeight))
            {
                validNeighbors.Add(neighborCoords);
            }
        }
    }
    return validNeighbors;
}

void PrintVisitedCoords(List<(int, int)> visitedCoordinates)
{
    for (int i = 0; i < lineCount; i++)
    {
        for (int j = 0; j < lineLength - 2; j++)
        {
            Console.Write(visitedCoordinates.Contains((i,j)) ? "#" : charMap[i][j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

var currentStep = new List<(int, int)>() {endCoords};
var nextStep = new List<(int, int)>();
for (int i = 0; i < 400; i++)
{
    visitedCoordinates.AddRange(currentStep);
    visitedCoordinates = visitedCoordinates.Distinct().ToList();
    foreach (var coord in currentStep)
    {
        if (charMap[coord.Item1][coord.Item2] == 'a')
        {
            Console.WriteLine($"Shortest path found at step {i} !");
            return;
        }
        nextStep.AddRange(GetNeighbors(coord));
    }
    nextStep = nextStep.Distinct().ToList();
    currentStep = new List<(int, int)>(nextStep);
    nextStep.Clear();
}

PrintVisitedCoords(visitedCoordinates);
