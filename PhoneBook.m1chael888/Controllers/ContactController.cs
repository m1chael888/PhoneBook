using PhoneBook.m1chael888.Models;
using PhoneBook.m1chael888.Services;
using PhoneBook.m1chael888.Views;
using static PhoneBook.m1chael888.Enums.ContactViewEnums;

namespace PhoneBook.m1chael888.Controllers;

public class ContactController
{
    private readonly IContactView _contactView;
    private readonly IContactService _contactService;
    public ContactController(IContactView contactView, IContactService contactService)
    {
        _contactView = contactView;
        _contactService = contactService;
    }

    public void HandleMainMenu()
    {
        Console.Clear();
        var choice = _contactView.ShowMainMenu();

        switch (choice)
        {
            case MainMenuOption.CreateContact:
                HandleCreateContact();
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

    public void HandleCreateContact()
    {
        var name = _contactView.GetInput("Enter your contact's name::");

        var email = _contactView.GetInput("Enter your contact's email (Optional)::");

        var phoneNumber = _contactView.GetInput("Enter your contact's phone number (Optional)::");

        var contact = new Contact()
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };
        _contactService.CallCreate(contact);
        _contactView.ReturnWithMsg("Contact saved successfully");
    }
}
