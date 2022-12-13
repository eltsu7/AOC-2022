using System.Text.Json;

var lines = System.IO.File.ReadAllLines("input.txt").ToList();

JsonElement asd = JsonSerializer.Deserialize<JsonElement>(lines[0]);

var packets = new List<JsonElement>();


bool CheckPackets(JsonElement left, JsonElement right)
{
    Console.WriteLine(a < b);
    return true;
}

for (int i = 0; i < lines.Count; i++)
{
    if (lines[i] == "")
    {
        continue;
    }
    packets.Add(JsonSerializer.Deserialize<JsonElement>(lines[i]));

    if (packets.Count == 2)
    {
        CheckPackets(packets[0], packets[1]);
    }
}