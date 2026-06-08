using ContactManager.Core;

public class ContactService
{
    private InMemoryContactRepository _repo;
    public ContactService(InMemoryContactRepository repo)
    {
        _repo = repo;
    }

    public void AddContact(string name, string phoneNumber, string email)
    {
        var c = new Contact(name, phoneNumber, email);
        _repo.AddContact(c);
    }

    public IReadOnlyList<Contact> GetAll()
    {
        return _repo.GetAllContacts();
    }

    public Contact SearchContactById(Guid id)
    {
        var c = _repo.GetAllContacts().Where(c => c.Id == id);
        if (c.Count() < 1)
        {
            throw new Exception("Geen zoekresultaten");
        }
        return c.Single();
    }
    public List<Contact> SearchContactByName(string name)
    {
        var c = _repo.GetAllContacts().Where(c => c.Name.ToLower().StartsWith(name.ToLower())).ToList();
        if (c.Count() < 1)
        {
            throw new Exception("Geen zoekresultaten");
        }
        return c;
    }
    public void Adjust(Guid id, string name, string phoneNumber, string email)
    {
        var c = SearchContactById(id);
        c.Adjust(name, phoneNumber, email);
    }
    public void RemoveContact(Guid id)
    {
        var c = SearchContactById(id);
        _repo.RemoveContact(c);
    }

    public Guid IsIdGuid(string id)
    {
        if (Guid.TryParse(id, out Guid g))
        {
            return g;
        }
        throw new Exception("Geen geldige Id");
    }

    public string isNameValid(string name)
    {
        foreach (var l in name)
        {
            if (!char.IsLetter(l))
            {
                throw new Exception("Geen geldige naam");
            }
        }
        return name;
    }
}