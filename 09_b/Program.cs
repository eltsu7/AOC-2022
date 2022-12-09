using System.Linq;

void Main()
{
    const string path = "C:/Users/eeli.hernesniemi/Koodit/AOC-2022/09_b/input.txt";
    var allLines = System.IO.File.ReadAllLines(path).ToList();
    var visitedByTail = new List<(int, int)>();
    var moveDict = new Dictionary<char, (int, int)>() {{'U', (0, 1)}, {'D', (0, -1)}, {'R', (1, 0)}, {'L', (-1, 0)}};
    var knots = new List<(int, int)>() {(0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0)};

    visitedByTail.Add((0,0));

    foreach (string line in allLines)
    {
        int moves = int.Parse(line.Substring(2));
        for (int i = 0; i < moves; i++)
        {
            var move = moveDict[line[0]];
            knots[0] = (knots[0].Item1 + move.Item1, knots[0].Item2 + move.Item2);
            MoveKnots(knots, visitedByTail);
        }
    }
    Console.WriteLine(visitedByTail.Count);
}

void MoveKnots(List<(int, int)> knots, List<(int, int)> visitedByTail)
{
    for (int i = 1; i < knots.Count; i++)
    {
        var headPosition = knots[i-1];
        var tailPosition = knots[i];
        if ((Math.Abs(headPosition.Item1 - tailPosition.Item1) > 1) || (Math.Abs(headPosition.Item2 - tailPosition.Item2) > 1))
            {
                if (headPosition.Item1 - tailPosition.Item1 > 0) { tailPosition.Item1 += 1; }
                else if (headPosition.Item1 - tailPosition.Item1 < 0) { tailPosition.Item1 -= 1; }
                if (headPosition.Item2 - tailPosition.Item2 > 0) { tailPosition.Item2 += 1; }
                else if (headPosition.Item2 - tailPosition.Item2 < 0) { tailPosition.Item2 -= 1; }
                knots[i] = tailPosition;
            }
    }
    if (!visitedByTail.Contains(knots.Last())) { visitedByTail.Add(knots.Last()); }
}

Main();
