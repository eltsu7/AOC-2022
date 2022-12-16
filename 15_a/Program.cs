class Coordinate
{
    public int x {get; set;}
    public int y {get; set;}
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinate coord)
        {
            return this.x ==  coord.x && this.y == coord.y;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return (x ^ y).GetHashCode();
    }
    public override string ToString()
    {
        return $"({x},{y})";
    }
}

class Program
{
    HashSet<(Coordinate, int)> sensorData = new HashSet<(Coordinate, int)>();
    static void Main() => new Program().Run();
    (int, int) boundariesX = (Int32.MaxValue, Int32.MinValue);
    (int, int) boundariesY = (Int32.MaxValue, Int32.MinValue);
    int row = 11;
    void Run()
    {
        ReadInput("test.txt");
        checkRow();
    }

    void checkRow()
    {
        Coordinate location;
        int counter = 0;
        for (int i = boundariesX.Item1; i < boundariesX.Item2 + 1; i++)
        {
            location = new Coordinate(i, row);
            bool found = false;
            foreach (var sensor in sensorData)
            {
                found = gridDistance(location, sensor.Item1) < sensor.Item2;
                if (found) { counter++; break; }
            }
            Console.Write(found ? "#" : ":");
        }
        Console.WriteLine();
        Console.WriteLine(counter);
    }

    int gridDistance(Coordinate from, Coordinate to)
    {
        return (Math.Abs(from.x - to.x) + Math.Abs(from.y - to.y));
    }

    void ReadInput(string path)
    {
        foreach (var line in System.IO.File.ReadLines(path))
        {
            var sensor = new Coordinate(int.Parse(line.Split("x=")[1].Split(',')[0]), int.Parse(line.Split("y=")[1].Split(':')[0]));
            var beacon = new Coordinate(int.Parse(line.Split("x=")[2].Split(',')[0]), int.Parse(line.Split("y=")[2].Split('\n')[0]));
            var distance = gridDistance(sensor, beacon);
            sensorData.Add((sensor, distance));
            
            if (sensor.x - distance < boundariesX.Item1) { boundariesX.Item1 = sensor.x - distance; }
            if (sensor.y - distance < boundariesY.Item1) { boundariesY.Item1 = sensor.y - distance; }
            if (sensor.x + distance > boundariesX.Item2) { boundariesX.Item2 = sensor.x + distance; }
            if (sensor.y + distance > boundariesY.Item2) { boundariesY.Item2 = sensor.y + distance; }
        }
        boundariesX = (boundariesX.Item1 - 1, boundariesX.Item2 + 1);
        boundariesY = (boundariesY.Item1 - 1, boundariesY.Item2 + 1);

        // Console.WriteLine($"{sensorData.Count()}");
        // Console.WriteLine($"{boundariesX.Item1} - {boundariesX.Item2}");
        // Console.WriteLine($"{boundariesY.Item1} - {boundariesY.Item2}");
    }
}