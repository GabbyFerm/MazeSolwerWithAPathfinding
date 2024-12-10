using Spectre.Console;
using MazeSolwerWithAPathfinding.Classes;

class Program
{
    static void Main(string[] args)
    {
        var controller = new MazeController();

        while (true)
        {
            Console.Clear();
            UIManager.DisplayHeader();

            var choice = UIManager.DisplayMenu();

            if (choice == "[lightskyblue3]Exit[/]")
            {
                AnsiConsole.MarkupLine("[lightskyblue3]Exiting...[/]");
                break;
            }

            if (choice == "[lightskyblue3]Create grid[/]")
            {
                var grid = controller.CreateGrid();
                UIManager.DisplayInstructions();
                controller.ProcessGridCommands(grid);
            }
        }
    }
}