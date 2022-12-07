namespace AOC
{
    class Node
    {
        private List<int> _size;
        private string _name;
        private int _size_limit;
        public List<Node> children = new List<Node>();
        public Node? parent;
        public Node (string name, int size_limit)
        {
            _name = name;
            _size = new List<int>();
            _size_limit = size_limit;
        }
        public void add_child(Node child)
        {
            children.Add(child);
        }

        public void set_parent(Node new_parent)
        {
            parent = new_parent;
        }

        public string Name
        {
            get { return _name; }
        }

        public List<int> Size
        {
            get
            {
                if (children.Count == 0) 
                {
                    return _size;
                }
                else 
                {
                    var list = new List<int>();
                    foreach (Node child in children)
                    {
                        list.AddRange(child.Size);
                    }
                    return list;
                }
            }
            set
            {
                _size = value;
            }
        }
    }
}
