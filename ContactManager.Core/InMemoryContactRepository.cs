using System.Security.Cryptography.X509Certificates;

namespace ContactManager.Core;

public class InMemoryContactRepository
{
    private int idCounter = 1;
    private List<Contact> contactList = [];
    public void Add(Contact contact)
    {
        contactList.Add(contact);
        contact.Id = idCounter;
        idCounter += 1;
    }
    public IReadOnlyList<Contact> GetAll()
    {
        return contactList;
    }
    public void DeleteContact(int Id)
    {
        var contact = GetContactById(Id);
        contactList.Remove(contact);
    }

    public Contact GetContactById(int Id)
    {
        foreach (var contact in contactList)
        {
            if (contact.Id == Id)
            {
                return contact;
            }
        }
        throw new Exception("Geen geldig Id");
    }
    public List<Contact> SearchContactByName(string name)
    {
        List<Contact> contactFoundNames = [];
        foreach (var contact in contactList)
        {
            if (name == contact.Name)
            {
                contactFoundNames.Add(contact);
            }
        }
        return contactFoundNames;
    }
}