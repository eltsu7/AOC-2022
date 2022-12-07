namespace AOC
{
    class Node
    {
        private List<int> _size;
        private int _size_limit;
        public string name;
        public List<Node> children;
        public Node? parent;
        
        public Node (string name, int size_limit)
        {
            this.name = name;
            this.children = new List<Node>();
            this._size = new List<int>();
            this._size_limit = size_limit;
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
                    if (list.Sum() < _size_limit)
                    {
                        Console.WriteLine(list.Sum());
                    }
                    return list;
                }
            }
            set { _size = value; }
        }
    }
}
