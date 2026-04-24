using System.Runtime.CompilerServices;

namespace ContactManager.Core;

public class ContactService(InMemoryContactRepository repo)
{
    private InMemoryContactRepository repository = repo;

    public void AddContact(string name, string email, string number)
    {
        var contact = new Contact(name, email, number);
        repository.Add(contact);
    }

    public string ContactAsString(Contact contact)
    {
        return $"Naam: {contact.Name} Email: {contact.Email} Telefoonnummer; {contact.Number}";
    }

    public List<string> ContactListAsStrings()
    {
        List<string> ContactListStrings = [];
        foreach (var contact in repository.GetAll())
        {
            ContactListStrings.Add(ContactAsString(contact));

        }
        return ContactListStrings;
    }

    public Contact CheckIfContactInList(int Id)
    {
        var lijst = repository.GetAll();
        foreach (var contact in lijst)
        {
            if (contact.Id == Id) { return contact; }
        }
        throw new Exception("Id niet in de lijst");
    }

    public void UpdateContact(Contact contact, string name, string email, string number)
    {
        contact.UpdateContact(name, email, number);
    }
    public void DeleteContact(int id)
    {
        repository.DeleteContact(id);
    }

    public List<string> FoundContactListAsStrings(string name)
    {
        List<string> ContactListStrings = [];
        foreach (var contact in repository.SearchContactByName(name))
        {
            ContactListStrings.Add(ContactAsString(contact));
        }
        return ContactListStrings;
    }
}
