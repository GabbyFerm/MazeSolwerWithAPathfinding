using System.Xml.Linq;

namespace MazeSolwerWithAPathfinding.Classes
{
    public class Pathfinding
    {
        private readonly MazeGrid _grid;

        public Pathfinding(MazeGrid grid)
        {
            _grid = grid;
        }

        public bool Solve()
        {
            var openList = new List<Node>();
            var closedList = new HashSet<Node>();

            Node? startNode = _grid.Start;
            Node? endNode = _grid.End;

            if (startNode == null || endNode == null)
            {
                Console.WriteLine("Start or End node is not set.");
                return false;  // Returnera false om någon av noderna inte är inställd
            }

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                Node currentNode = openList.OrderBy(node => node.FCost).First();

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode == endNode)
                {
                    RetracePath(startNode, endNode);
                    return true;
                }

                foreach (Node neighbor in GetNeighbors(currentNode))
                {
                    if (neighbor.IsWall || closedList.Contains(neighbor))
                        continue;

                    int newGCost = currentNode.GCost + 1;

                    if (newGCost < neighbor.GCost || !openList.Contains(neighbor))
                    {
                        neighbor.GCost = newGCost;
                        neighbor.HCost = endNode != null ? GetHeuristic(neighbor, endNode) : 0; 
                        neighbor.Parent = currentNode;

                        if (!openList.Contains(neighbor))
                            openList.Add(neighbor);
                    }
                }
            }

            return false;
        }
        private void RetracePath(Node startNode, Node endNode)
        {
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                if (currentNode.Parent != null) 
                {
                    currentNode.IsPath = true;
                    currentNode = currentNode.Parent;
                }
                else
                {
                    break; 
                }
            }
        }

        private int GetHeuristic(Node a, Node b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        private IEnumerable<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();

            // Definiera riktningar som en lista av tuples
            var directions = new List<(int, int)>
            {
                (-1, 0), // Upp
                (1, 0),  // Ner
                (0, -1), // Vänster
                (0, 1)   // Höger
            };

            foreach (var (dx, dy) in directions)
            {
                int newX = node.X + dx;
                int newY = node.Y + dy;

                if (_grid.IsValidPosition(newX, newY))
                {
                    var neighborNode = _grid.GetNodes()[newX, newY];
                    if (neighborNode != null)  
                    {
                        neighbors.Add(neighborNode);
                    }
                }
            }

            return neighbors;
        }
    }
}
