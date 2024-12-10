using MazeSolwerWithAPathfinding.Classes;
using Spectre.Console;

public class MazeController
{
    public MazeGrid CreateGrid()
    {
        const int maxGridSize = 50; 
        AnsiConsole.MarkupLine($"[lightskyblue3]Enter grid size (1-{maxGridSize}): [/]");

        int gridSize;
        while (!int.TryParse(Console.ReadLine(), out gridSize) || gridSize <= 0 || gridSize > maxGridSize)
        {
            AnsiConsole.MarkupLine($"[red]Invalid input. Please enter a positive integer between 1 and {maxGridSize}.[/]");
            AnsiConsole.MarkupLine($"[lightskyblue3]Enter grid size (1-{maxGridSize}): [/]");
        }

        return new MazeGrid(gridSize);
    }

    public void ProcessGridCommands(MazeGrid grid)
    {
        while (true)
        {
            AnsiConsole.MarkupLine("[lightskyblue3]\nEnter command: [/]");
            string command = Console.ReadLine()?.Trim().ToLower()!;

            if (command == "exit") break;
            if (command == "solve")
            {
                SolveMaze(grid);
                break;
            }

            HandleGridCommand(grid, command);
        }
    }

    private void HandleGridCommand(MazeGrid grid, string command)
    {
        var parts = command.Split(' ');
        if (parts.Length < 3)
        {
            AnsiConsole.MarkupLine("[red]Invalid command. Expected format: 'action x y' (ex: 'wall 3 4').[/]");
            return;
        }

        string action = parts[0];
        if (!int.TryParse(parts[1], out int x) || !int.TryParse(parts[2], out int y))
        {
            AnsiConsole.MarkupLine("[red]Invalid coordinates. Please enter numbers for x and y.[/]");
            return;
        }

        switch (action)
        {
            case "wall":
                grid.AddWall(x, y);
                break;

            case "start":
                grid.SetStart(x, y);
                break;

            case "end":
                grid.SetEnd(x, y);
                break;

            default:
                AnsiConsole.MarkupLine("[red]Unknown command. Try again.[/]");
                break;
        }
    }

    private void SolveMaze(MazeGrid grid)
    {
        if (grid.Start == null || grid.End == null)
        {
            AnsiConsole.MarkupLine("[red]You must set both a start and an end point before solving.[/]");
            return;
        }

        var pathfinder = new Pathfinding(grid);
        bool pathFound = pathfinder.Solve();
        grid.DisplayGrid();
        AnsiConsole.MarkupLine(pathFound
            ? "[lightskyblue3]Path found! See the grid above.[/]"
            : "[red]No path could be found.[/]");

        AnsiConsole.MarkupLine("[grey]Press any key to return to the menu...[/]");
        Console.ReadKey(true);
    }
}