using PhoneBook.m1chael888.Models;
using PhoneBook.m1chael888.Repositories;

namespace PhoneBook.m1chael888.Services
{
    public interface IContactService
    {
        void CallCreate(Contact contact);
    }
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void CallCreate(Contact contact)
        {
            _contactRepository.Create(contact);
        }
    }
}
