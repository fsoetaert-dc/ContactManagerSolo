using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ContactManager.Core;

public class Contact

{

    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; } = "";
    public string Number { get; private set; } = "";

    public Contact(string name, string email, string number)

    {
        UpdateContact(name, email, number);
    }

    public void UpdateContact(string name, string email, string number)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Geen geldige naam");
        }
        Name = name;
        Email = email;
        Number = number;
    }
}
