using ContactManager.Core;

public class InMemoryContactRepository
{
    private List<Contact> contactList = [];
    public IReadOnlyList<Contact> GetAllContacts()
    {
        return contactList;
    }

    public void AddContact(Contact contact)
    {
        contactList.Add(contact);
    }
    public void RemoveContact(Contact contact)
    {
        contactList.Remove(contact);
    }
}