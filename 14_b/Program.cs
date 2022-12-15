﻿using System.Diagnostics;
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
    const string filename = "input.txt";
    HashSet<Coordinate> wallCoords = new HashSet<Coordinate>();
    HashSet<Coordinate> sandCoords = new HashSet<Coordinate>();
    Coordinate fallingPoint = new Coordinate(500, 0);
    (int, int) drawRangeX = (450, 550);
    (int, int) drawRangeY = (0, 30);
    int floorHeight = 0;

    static void Main() => new Program().Run();
    void Run()
    {
        this.ReadInput();
        this.UpdateBoundaries();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        while (true)
        {
            var sand = FindFallingLocation();
            if (sand != null) { sandCoords.Add(sand); }
            else { break; }

            if (sandCoords.Count() % 10000 == 0 ) 
            { 
                // this.DrawScreen();
                Console.WriteLine($"{sandCoords.Count()}\t{stopWatch.ElapsedMilliseconds}");
                // Console.ReadKey();
            }
        }
        Console.WriteLine(sandCoords.Count() + 1);
    }

    bool NotBlocked(Coordinate coord) { return (!wallCoords.Contains(coord) && !sandCoords.Contains(coord) && coord.y < floorHeight);}

    void UpdateBoundaries()
    {
        var xMax = wallCoords.First().x;
        var xMin = wallCoords.First().x;
        var yMax = wallCoords.First().y;
        var yMin = fallingPoint.y;
        foreach (var item in wallCoords)
        {
            if (xMax < item.x) { xMax = item.x; }
            if (yMax < item.y) { yMax = item.y; }
            if (item.x < xMin) { xMin = item.x; }
        }

        this.drawRangeX = (xMin - 1, xMax + 1);
        this.drawRangeY = (yMin, yMax + 2);
        this.floorHeight = yMax + 2;
    }

    Coordinate? FindFallingLocation()
    {
        var location = new Coordinate(fallingPoint.x, fallingPoint.y);

        while (true)
        {
            // DrawScreen(location);
            // Thread.Sleep(50);

            if (location.y > this.drawRangeY.Item2) { return null; }

            if (NotBlocked(new Coordinate(location.x, location.y + 1)))
            {
                location.y += 1;
                continue;
            }
            if (NotBlocked(new Coordinate(location.x - 1, location.y + 1)))
            {
                location.y += 1;
                location.x -= 1;
                continue;
            }
            if (NotBlocked(new Coordinate(location.x + 1, location.y + 1)))
            {
                location.y += 1;
                location.x += 1;
                continue;
            }

            if (location.y == fallingPoint.y)
            {
                return null;
            }

            return location;
        }
    }

    void DrawScreen(Coordinate? focusedCoordinate = null)
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.CursorVisible = false;
        char borderChar = '°';
        Console.WriteLine(new string(borderChar, (drawRangeX.Item2 - drawRangeX.Item1) + 3));

        for (int y = drawRangeY.Item1; y < drawRangeY.Item2 + 1; y++)
        {
            Console.Write(borderChar);
            for (int x = drawRangeX.Item1; x < drawRangeX.Item2 + 1; x++)
            {
                if (y == floorHeight)
                {
                    Console.Write("-");
                }
                else if (focusedCoordinate != null && focusedCoordinate.Equals(new Coordinate(x,y)))
                {
                    Console.Write(":");
                }
                else if (wallCoords.Contains(new Coordinate(x, y)))
                {
                    Console.Write("#");
                }
                else if (sandCoords.Contains(new Coordinate(x, y)))
                {
                    Console.Write("o");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(borderChar);
        }
        Console.WriteLine(new string(borderChar, (drawRangeX.Item2 - drawRangeX.Item1) + 3));
    }
    
    void ReadInput()
    {
        var lines = System.IO.File.ReadAllLines(filename).ToList().ConvertAll(s => s.Split(" -> "));
        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Count() - 1; j++)
            {
                List<int> start = line[j].Split(',').Select(int.Parse).ToList();
                List<int> end = line[j + 1].Split(',').Select(int.Parse).ToList();
                if (end[0] < start[0]) { (end[0], start[0]) = (start[0], end[0]); }
                if (end[1] < start[1]) { (end[1], start[1]) = (start[1], end[1]); }
                for (int x = start[0]; x < end[0] + 1; x++)
                {
                    for (int y = start[1]; y < end[1] + 1; y++)
                    {
                        if (!this.wallCoords.Contains(new Coordinate(x, y)))
                        {
                            this.wallCoords.Add(new Coordinate(x, y));
                        }
                    }
                }
            }
        }
    }
}