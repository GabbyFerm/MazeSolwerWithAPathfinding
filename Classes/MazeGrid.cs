namespace MazeSolwerWithAPathfinding.Classes
{
    public class MazeGrid
    {
        private readonly int _size;
        private readonly Node[,] _nodes;
        public Node? Start { get; private set; }
        public Node? End { get; private set; }

        public MazeGrid(int size)
        {
            _size = size;
            _nodes = new Node[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    _nodes[x, y] = new Node(x, y);
                }
            }
        }

        public bool AddWall(int x, int y)
        {
            if (IsValidPosition(x, y) && !_nodes[x, y].IsWall && !_nodes[x, y].IsStart && !_nodes[x, y].IsEnd)
            {
                _nodes[x, y].IsWall = true;
                return true;
            }
            return false;
        }

        public bool SetStart(int x, int y)
        {
            if (IsValidPosition(x, y) && !_nodes[x, y].IsWall && !_nodes[x, y].IsEnd)
            {
                if (Start != null)
                {
                    Start.IsStart = false;
                }

                Start = _nodes[x, y];
                Start.IsStart = true;
                return true;
            }
            return false;
        }

        public bool SetEnd(int x, int y)
        {
            if (IsValidPosition(x, y) && !_nodes[x, y].IsWall && !_nodes[x, y].IsStart)
            {
                if (End != null)
                {
                    End.IsEnd = false;
                }

                End = _nodes[x, y];
                End.IsEnd = true;
                return true;
            }
            return false;
        }

        public void DisplayGrid()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    Node node = _nodes[x, y];
                    if (node.IsStart)
                        Console.Write("S ");
                    else if (node.IsEnd)
                        Console.Write("E ");
                    else if (node.IsWall)
                        Console.Write("# ");
                    else if (node.IsPath)
                        Console.Write("* ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _size && y < _size;
        }

        public Node[,] GetNodes() => _nodes;
    }
}