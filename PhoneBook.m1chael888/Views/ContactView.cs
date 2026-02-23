using Microsoft.IdentityModel.Tokens;
using PhoneBook.m1chael888.Models;
using Spectre.Console;
using static PhoneBook.m1chael888.Enums.ContactViewEnums;
using static PhoneBook.m1chael888.Enums.EnumExtensions;

namespace PhoneBook.m1chael888.Views;

public interface IContactView
{
    MainMenuOption ShowMainMenu();
    string GetInput(string msg, string? error = null);
    void ReturnWithMsg(string msg);
    void DisplayContactList(List<Contact> contacts);
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

    public void DisplayContactList(List<Contact> contacts)
    {
        AnsiConsole.MarkupLine("[LightCoral]Your contacts::[/]\n");
        AnsiConsole.MarkupLine($"[LightCoral]{"Name".PadRight(20)}\t{"Email".PadRight(20)}\t{"Phone Number"}[/]");
        foreach (var c in contacts)
        {
            AnsiConsole.MarkupLine($"{CheckLength(c.Name).PadRight(20)}\t{CheckLength(c.Email).PadRight(20)}\t{c.PhoneNumber}");
        }
        Console.WriteLine();
        ReturnWithMsg();
    }

    public void ReturnWithMsg(string? msg = null)
    {
        if (!msg.IsNullOrEmpty()) AnsiConsole.MarkupLine($"[LightCoral]{msg}[/]");
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Point)
            .SpinnerStyle("white")
            .Start("Press any key to proceed", x =>
            {
                Console.ReadKey();
            });
    }

    string CheckLength(string myString)
    {
        if (myString.Length > 20) myString = myString.Substring(0, 18) + "...";
        return myString;
    }
}
