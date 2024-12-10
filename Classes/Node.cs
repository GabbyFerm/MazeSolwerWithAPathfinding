namespace MazeSolwerWithAPathfinding.Classes
{
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        public bool IsWall { get; set; }
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public bool IsPath { get; set; }
        public Node? Parent { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}