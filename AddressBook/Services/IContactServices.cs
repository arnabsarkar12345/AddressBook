using AddressBookWebAiWithEntityFrameWork.Model;

namespace AddressBook.Services
{
    public interface IContactServices
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> GetParticularContact(int id);
        Task UpdateParticularContact(Contact contact);
        Task DeleteParticularContact(int id);
    }
}
