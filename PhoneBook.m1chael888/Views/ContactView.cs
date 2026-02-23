using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.IdentityModel.Tokens;
using Spectre.Console;
using static PhoneBook.m1chael888.Enums.ContactViewEnums;
using static PhoneBook.m1chael888.Enums.EnumExtensions;

namespace PhoneBook.m1chael888.Views;

public interface IContactView
{
    MainMenuOption ShowMainMenu();
    string GetInput(string msg, string? error = null);
    void ReturnWithMsg(string msg);
}
public class ContactView : IContactView
{
    public MainMenuOption ShowMainMenu()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOption>()
                .Title("[LightCoral]Choose an option::[/]")
                .AddChoices(Enum.GetValues<MainMenuOption>())
                .UseConverter(x => $"[grey]{GetDescription(x)}[/]")
                .HighlightStyle("white")
                .WrapAround()
            );
        return choice;
    }

    public string GetInput(string msg, string? error = null)
    {
        Console.Clear();
        if (!error.IsNullOrEmpty()) AnsiConsole.MarkupLine($"[red]{error}[/]");
        var prompt = new TextPrompt<string>($"[LightCoral]{msg}[/]")
            .AllowEmpty();
        var input = AnsiConsole.Prompt(prompt);
        return input;
    }

    public void ReturnWithMsg(string msg)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[LightCoral]{msg}[/]");
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Point)
            .SpinnerStyle("white")
            .Start("Press any key to proceed", x =>
            {
                Console.ReadKey();
            });
    }
}
