using AddressBook.Services;
using AddressBookWebAiWithEntityFrameWork.Model;
using Microsoft.EntityFrameworkCore;

namespace AddressBookWebAiWithEntityFrameWork.Repositories
{
    public class ContactServices : IContactServices
        { 
        private readonly ContactContext _context;

        public ContactServices(ContactContext context)
        {
            _context = context;
        }
        public async Task<Contact> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteParticularContact(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetParticularContact(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task UpdateParticularContact(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
