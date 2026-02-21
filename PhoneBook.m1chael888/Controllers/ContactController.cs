using PhoneBook.m1chael888.Views;
using static PhoneBook.m1chael888.Enums.ContactViewEnums;

namespace PhoneBook.m1chael888.Controllers;

public class ContactController
{
    private readonly IContactView _contactView;
    public ContactController(IContactView contactView)
    {
        _contactView = contactView;
    }

    public void HandleMainMenu()
    {
        var choice = _contactView.ShowMainMenu();

        switch (choice)
        {
            case MainMenuOption.CreateContact:
                break;
            case MainMenuOption.ReadContacts:
                break;
            case MainMenuOption.UpdateContact:
                break;
            case MainMenuOption.DeleteContact:
                break;
            case MainMenuOption.Exit:
                Environment.Exit(0);
                break;
        }
    }
}
