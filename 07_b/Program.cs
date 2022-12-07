using AOC;


List<string> line_list = System.IO.File.ReadAllLines("input.txt").ToList();
const int size_limit = 100000;

Storage storage = new Storage(100000);
Node root_node = new Node("/", size_limit, storage);
Node current_node = root_node;

void add_child(Node parent, Node child)
{
    parent.children.Add(child);
    child.parent = parent;
}

foreach (string line in line_list)
{
    var words = line.Split(' ');
    
    if (line == "$ ls") {continue;}
    if (line == "$ cd /") {current_node = root_node; continue;}
    if (line == "$ cd ..") {current_node = current_node.parent; continue;}
    
    if (words[0] == "$" && words[1] == "cd")
    {
        current_node = current_node.children.Find(c => c.name == words[2]);
    }   
    else if (words[0] == "dir")
    {
        if (current_node.children.Find(c => c.name == words[1]) == null)
        {
            add_child(current_node, new Node(words[1], size_limit, storage));
        }
    }
    else
    {
        if (current_node.children.Find(c => c.name == words[1]) == null)
        {
            var child = new Node(words[1], size_limit, storage);
            child.Size = new List<long>(){long.Parse(words[0])};
            add_child(current_node, child);
        }
    }
}

var root_size = root_node.Size.Sum();
var sizes = storage.dirs;
sizes.Sort();
var free_space = 70000000 - root_size;

foreach (int val in sizes)
{
    if ((free_space + val) >= 30000000)
    {
        Console.WriteLine(val);
        break;
    }
}