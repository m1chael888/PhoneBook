using PhoneBook.m1chael888.Models;
using PhoneBook.m1chael888.Data;

namespace PhoneBook.m1chael888.Repositories
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        List<Contact> Read();
    }
    internal class ContactRepository : IContactRepository
    {
        public void Create(Contact contact)
        {
            using PhoneBookContext context = new PhoneBookContext();

            context.Add(contact);
            context.SaveChanges();
        }

        public List<Contact> Read()
        {
            using PhoneBookContext context = new PhoneBookContext();

            var contacts = context.Contacts.ToList();
            return contacts;
        }
    }
}
