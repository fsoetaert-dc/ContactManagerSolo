using ContactManager.Core;

public class ContactService
{
    private MemoryRepository _repo;
    public ContactService(MemoryRepository repo)
    {
        _repo = repo;
    }

    private void AddContact(string name, string phoneNumber, string email)
    {
        var c = new Contact(name, phoneNumber, email);
        _repo.AddContact(c);
    }

    private IReadOnlyList<Contact> GetAll()
    {
        return _repo.GetAllContacts();
    }
}