using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace ContactManager.Core;

public class Contact
{
    public string Name { get; private set; } = "";
    public Guid Id;
    public string PhoneNumber { get; private set; } = "";
    public string Email { get; private set; } = "";

    public Contact(string name, string phoneNumber, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Naam mag niet leeg zijn");
        }
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        Id = Guid.NewGuid();

    }
}
