namespace AOC
{
    class Storage
    {
        public List<long> dirs;
        public int size_limit;
        public Storage (int size_limit)
        {
            this.size_limit = size_limit;
            this.dirs = new List<long>();
        }
    }
    class Node
    {
        private List<long> _size;
        public string name;
        private int _size_limit;
        public List<Node> children;
        public Node? parent;
        private Storage _storage;
        
        public Node (string name, int size_limit, Storage storage)
        {
            this.name = name;
            this.children = new List<Node>();
            this._size = new List<long>();
            this._size_limit = size_limit;
            this._storage = storage;
        }

        public List<long> Size
        {
            get
            {
                if (children.Count == 0) 
                {
                    _storage.dirs.Add(_size.First());
                    return _size;
                }
                else 
                {
                    var list = new List<long>();
                    foreach (Node child in children)
                    {
                        list.AddRange(child.Size);
                    }
                    _storage.dirs.Add(list.Sum());
                    return list;
                }
            }
            set { _size = value; }
        }
    }
}
