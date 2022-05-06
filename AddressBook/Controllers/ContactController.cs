using AddressBook.Services;
using AddressBookWebAiWithEntityFrameWork.Model;
using AddressBookWebAiWithEntityFrameWork.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookWebAiWithEntityFrameWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;

        public ContactController(IContactServices contactRepository)
        {
            _contactServices = contactRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactServices.GetContacts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetParticularContact(int id)
        {
            return await _contactServices.GetParticularContact(id);
        }
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact([FromBody] Contact contact)
        {
            var newContact = await _contactServices.CreateContact(contact);
            return CreatedAtAction(nameof(GetContacts), new { id = newContact.Id }, newContact);
        }

        [HttpPut]
        public async Task<ActionResult> PutContact(int id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            await _contactServices.UpdateParticularContact(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var contactToDelete = await _contactServices.GetParticularContact(id);
            if (contactToDelete == null)
            {
                return NotFound();
            }
            await _contactServices.DeleteParticularContact(contactToDelete.Id);
            return NoContent();
        }

    }
}
