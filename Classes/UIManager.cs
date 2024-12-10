using Figgle;
using MazeSolwerWithAPathfinding.Classes;
using Spectre.Console;

public static class UIManager
{

    public static void DisplayHeader()
    {
        var header = FiggleFonts.Standard.Render("Maze Solver");
        AnsiConsole.MarkupLine("[deepskyblue3]" + header + "[/]");
        AnsiConsole.MarkupLine("[deepskyblue3 italic]######### with A* Pathfinding! #########\n[/]");
    }

    public static void DisplayInstructions()
    {
        AnsiConsole.MarkupLine("\n[lightskyblue3]Use these commands to customize the maze:[/]");
        AnsiConsole.MarkupLine("[lightskyblue3]- Add wall: wall x y (ex: wall 3 4)[/]");
        AnsiConsole.MarkupLine("[lightskyblue3]- Set start: start x y (ex: start 0 0)[/]");
        AnsiConsole.MarkupLine("[lightskyblue3]- Set end: end x y (ex: end 9 9)[/]");
        AnsiConsole.MarkupLine("[lightskyblue3]- Solve: solve[/]");
        AnsiConsole.MarkupLine("[lightskyblue3]- Exit: exit[/]");
    }

    public static string DisplayMenu()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[italic grey53]Choose an option:[/]")
                .PageSize(3)
                .HighlightStyle(new Style(foreground: Color.DeepSkyBlue3))
                .AddChoices(
                    "[lightskyblue3]Create grid[/]",
                    "[lightskyblue3]Exit[/]"
                ));
    }
}