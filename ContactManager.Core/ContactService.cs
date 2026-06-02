using ContactManager.Core;

public class ContactService
{
    private InMemoryContactRepository _repo;
    public ContactService(InMemoryContactRepository repo)
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

    private Contact SearchContactById(Guid id)
    {
        var c = _repo.GetAllContacts().Where(c => c.Id == id);
        if (c.Count() < 1)
        {
            throw new Exception("Geen zoekresultaten");
        }
        return c.Single();
    }
    private List<Contact> SearchContactByName(string name)
    {
        var c = _repo.GetAllContacts().Where(c => c.Name.ToLower().StartsWith(name.ToLower())).ToList();
        if (c.Count() < 1)
        {
            throw new Exception("Geen zoekresultaten");
        }
        return c;
    }
    private void Adjust(Guid id, string name, string phoneNumber, string email)
    {
        var c = SearchContactById(id);
        c.Adjust(name, phoneNumber, email);
    }
    private void RemoveContact(Guid id)
    {
        var c = SearchContactById(id);
        _repo.RemoveContact(c);
    }
}