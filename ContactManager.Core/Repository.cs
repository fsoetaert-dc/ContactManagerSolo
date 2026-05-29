using ContactManager.Core;

public class MemoryRepository
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
}