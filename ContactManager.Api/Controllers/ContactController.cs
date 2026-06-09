using System.Xml.Serialization;
using ContactManager.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ContactManager.Api.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactController : ControllerBase
{
    private readonly ContactService service;

    public ContactController(ContactService service)
    {
        this.service = service;
    }

    [HttpGet] //contactenlijst terugkrijgen
    public IEnumerable<ContactResponse> GetAllContacts()
    {
        return service.GetAll()
            .Select(contact => new ContactResponse
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email
            });
    }

    [HttpPost] //add contact
    public ContactResponse PostContact(AddContactRequest request)
    {
        return service.AddContact(request.Name, request.PhoneNumber, request.Email);
    }

    [HttpDelete("{id:Guid}")] //delete contact
    public void DeleteContact(Guid id)
    {
        service.RemoveContact(id);
    }

    [HttpGet("search")] //search by id
    public IEnumerable<ContactResponse> SearchByName(string name)
    {
        return service.SearchContactByName(name).Select(contact => new ContactResponse
        {
            Id = contact.Id,
            Name = contact.Name,
            PhoneNumber = contact.PhoneNumber,
            Email = contact.Email
        });
    }

}