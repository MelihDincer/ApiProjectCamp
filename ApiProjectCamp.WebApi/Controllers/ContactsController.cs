using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        ApiContext _apiContext;

        public ContactsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _apiContext.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.ContactMapLocation = createContactDto.ContactMapLocation;
            contact.ContactAddress = createContactDto.ContactAddress;
            contact.ContactPhone = createContactDto.ContactPhone;
            contact.ContactEmail = createContactDto.ContactEmail;
            contact.ContactOpenHours = createContactDto.ContactOpenHours;
            _apiContext.Contacts.Add(contact);
            _apiContext.SaveChanges();
            return Ok("Yeni contact bilgisi eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _apiContext.Contacts.Find(id);
            _apiContext.Contacts.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Contact bilgisi silindi.");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _apiContext.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.ContactMapLocation = updateContactDto.ContactMapLocation;
            contact.ContactAddress = updateContactDto.ContactAddress;
            contact.ContactPhone = updateContactDto.ContactPhone;
            contact.ContactEmail = updateContactDto.ContactEmail;
            contact.ContactOpenHours = updateContactDto.ContactOpenHours;
            _apiContext.Contacts.Update(contact);
            _apiContext.SaveChanges();
            return Ok("Contact bilgisi güncellendi.");
        }
    }
}
