using Spectre.Console;
using static PhoneBook.m1chael888.Enums.ContactViewEnums;
using static PhoneBook.m1chael888.Enums.EnumExtensions;

namespace PhoneBook.m1chael888.Views;

public interface IContactView
{
    MainMenuOption ShowMainMenu();
}
public class ContactView : IContactView
{
    public MainMenuOption ShowMainMenu()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOption>()
                .Title("Choose an option")
                .AddChoices(Enum.GetValues<MainMenuOption>())
                .UseConverter(x => GetDescription(x))
                .WrapAround()
            );
        return choice;
    }
}
