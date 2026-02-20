using PhoneBook.m1chael888.Views;

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
        _contactView.ShowMainMenu();
    }
}
