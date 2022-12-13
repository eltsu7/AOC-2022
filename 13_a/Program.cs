using System.Text.Json;

var lines = System.IO.File.ReadAllLines("input.txt").ToList();

JsonElement asd = JsonSerializer.Deserialize<JsonElement>(lines[0]);

var packets = new List<JsonElement>();


bool? IsInOrder(JsonElement left, JsonElement right)
{
    if (left.ValueKind == JsonValueKind.Array && right.ValueKind == JsonValueKind.Array)
    {
        for (int i = 0; i < Math.Min(left.GetArrayLength(), right.GetArrayLength()); i++)
        {
            
        }
        return left.GetArrayLength() < right.GetArrayLength();
    }
    else if (left.ValueKind == JsonValueKind.Number && right.ValueKind == JsonValueKind.Number)
    {
        return left.GetInt16() == right.GetInt16() ? null : (left.GetInt16() < right.GetInt16());
    }
    else
    {
        var asd = new JsonElement();
    }

    return null;
}

/*
If both values are integers, the lower integer should come first. 
If the left integer is lower than the right integer, the inputs are in the right order. 
If the left integer is higher than the right integer, the inputs are not in the right order. 
Otherwise, the inputs are the same integer; continue checking the next part of the input.


If both values are lists, compare the first value of each list, then the second value, and so on. 
If the left list runs out of items first, the inputs are in the right order. 
If the right list runs out of items first, the inputs are not in the right order. 
If the lists are the same length and no comparison makes a decision about the order, continue checking the next part of the input.


If exactly one value is an integer, convert the integer to a list which contains that integer as its only value, then retry the comparison. 
For example, if comparing [0,0,0] and 2, convert the right value to [2] (a list containing 2); the result is then found by instead comparing [0,0,0] and [2].
*/

for (int i = 0; i < lines.Count; i++)
{
    if (lines[i] == "")
    {
        continue;
    }
    packets.Add(JsonSerializer.Deserialize<JsonElement>(lines[i]));

    if (packets.Count == 2)
    {
        IsInOrder(packets[0], packets[1]);
    }
}