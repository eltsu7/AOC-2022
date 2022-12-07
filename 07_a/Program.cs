using AOC;


List<string> line_list = System.IO.File.ReadAllLines("input.txt").ToList();
const int size_limit = 100000;

Node root_node = new Node("/", size_limit);
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
            add_child(current_node, new Node(words[1], size_limit));
        }
    }
    else
    {
        if (current_node.children.Find(c => c.name == words[1]) == null)
        {
            var child = new Node(words[1], size_limit);
            child.Size = new List<int>(){int.Parse(words[0])};
            add_child(current_node, child);
        }
    }
}

var size = root_node.Size.Sum();
