using ContactManager.Core;

public class DTOContact(Contact contact)
{
    public string Name = contact.Name;
    public string PhoneNumber = contact.PhoneNumber;
    public string Email = contact.Email;
    public Guid Id = contact.Id;
}