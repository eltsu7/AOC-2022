void Main()
{
    const string path = "C:/Users/eeli.hernesniemi/Koodit/AOC-2022/09_a/input.txt";
    var allLines = System.IO.File.ReadAllLines(path).ToList();
    var visitedByTail = new List<(int, int)>();
    var headPosition = (0,0);
    var tailPosition = (0,0);
    var moveDict = new Dictionary<char, (int, int)>() {{'U', (0, 1)}, {'D', (0, -1)}, {'R', (1, 0)}, {'L', (-1, 0)}};

    visitedByTail.Add(tailPosition);

    foreach (string line in allLines)
    {
        int moves = int.Parse(line.Substring(2));
        for (int i = 0; i < moves; i++)
        {
            var move = moveDict[line[0]];
            headPosition.Item1 += move.Item1; headPosition.Item2 += move.Item2; 
            
            if ((Math.Abs(headPosition.Item1 - tailPosition.Item1) > 1) || (Math.Abs(headPosition.Item2 - tailPosition.Item2) > 1))
            {
                if (headPosition.Item1 - tailPosition.Item1 > 0) { tailPosition.Item1 += 1; }
                else if (headPosition.Item1 - tailPosition.Item1 < 0) { tailPosition.Item1 -= 1; }
                if (headPosition.Item2 - tailPosition.Item2 > 0) { tailPosition.Item2 += 1; }
                else if (headPosition.Item2 - tailPosition.Item2 < 0) { tailPosition.Item2 -= 1; }
            }
            if (!visitedByTail.Contains(tailPosition))
            {
                visitedByTail.Add(tailPosition);
            }
        }
    }
    Console.WriteLine(visitedByTail.Count);
}

Main();
