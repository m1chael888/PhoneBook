using PhoneBook.m1chael888.Models;
using PhoneBook.m1chael888.Services;
using PhoneBook.m1chael888.Views;
using System.Text.RegularExpressions;
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
                HandleReadContacts();
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
        while (name.Length < 1)
        {
            name = _contactView.GetInput("Enter your contact's name::", "Name can't be empty!");
        }

        var email = _contactView.GetInput("Enter your contact's email (Optional)::");
        if (email.Length > 0)
        {
            while (!ValidEmail(email))
            {
                email = _contactView.GetInput("Enter your contact's email (Optional)::", "Invalid email!");
            }
        }

        var phoneNumber = _contactView.GetInput("Enter your contact's phone number (Optional)::");
        if (phoneNumber.Length > 0)
        {
            while (!ValidPhoneNumber(phoneNumber))
            {
                phoneNumber = _contactView.GetInput("Enter your contact's phone number (Optional)::", "Please use a 10 digit phone number!");
            }
        }

        var contact = new Contact()
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber
        };
        _contactService.CallCreate(contact);
        Console.Clear();
        _contactView.ReturnWithMsg("Contact saved successfully");
    }

    private void HandleReadContacts()
    {
        var contacts = _contactService.CallRead();
        if (contacts.Count == 0)
        {
            _contactView.ReturnWithMsg("Your contact list is empty");
        }
        else
        {
            _contactView.DisplayContactList(contacts);
        }
    }

    private bool ValidEmail(string input)
    {
        Regex validEmail = new Regex("^\\S+@\\S+\\.\\S+$");
        return (validEmail.IsMatch(input) || input.Length < 1);
    }

    private bool ValidPhoneNumber(string input)
    {
        return ((input.Length == 10 && int.TryParse(input, out int x) || input.Length < 1));
    }
}
