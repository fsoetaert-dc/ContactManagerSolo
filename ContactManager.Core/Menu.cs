using ContactManager.Core;

public class Menu
{
    private void WriteContact(Contact c)
    {
        console.WriteLine(c.Name);
        console.WriteLine(c.PhoneNumber);
        console.WriteLine(c.Email);
        console.WriteLine(c.Id.ToString());
        console.WriteLine("------------");
    }

    private IConsole console;
    private ContactService contactService;
    public Menu(IConsole console, ContactService contactService)
    {
        this.console = console;
        this.contactService = contactService;
    }
    public int Run()
    {
        var running = true;
        while (running)
        {
            ShowMenu();
            running = HandleChoice(console.ReadLine());
        }
        return 0;
    }

    private void ShowMenu()
    {
        console.WriteLine("1. Contact Toevoegen");
        console.WriteLine("2. Contactenlijst Weergeven");
        console.WriteLine("3. Contact Aanpassen");
        console.WriteLine("4. Contact Verwijderen");
        console.WriteLine("5. Contact Zoeken");
        console.WriteLine("q. Exit");
        console.Write("Maak uw keuze:");
    }

    private void HandleAddContact()
    {
        console.WriteLine("Naam: ");
        var inputName = console.ReadLine();
        var validName = contactService.isNameValid(inputName);
        console.WriteLine("Telefoonnummer: ");
        var inputPhoneNumber = console.ReadLine();
        console.WriteLine("Email: ");
        var inputEmail = console.ReadLine();
        contactService.AddContact(validName, inputPhoneNumber, inputEmail);
        console.WriteLine($"Contact toegevoegd: {validName}");
    }

    private void HandleShowContactlist()
    {
        var contactList = contactService.GetAll();
        console.WriteLine("------------");
        foreach (var c in contactList)
        {
            WriteContact(c);
        }
    }

    private void HandleAdjustContact()
    {
        console.WriteLine("Id van contact: ");
        var inputId = console.ReadLine();
        var Id = contactService.IsIdGuid(inputId);
        var c = contactService.SearchContactById(Id);
        console.WriteLine("Aangepaste naam: ");
        var inputName = console.ReadLine();
        console.WriteLine("Aangepaste telefoonnummer: ");
        var inputPhoneNumber = console.ReadLine();
        console.WriteLine("Aangepaste email: ");
        var inputEmail = console.ReadLine();
        contactService.Adjust(Id, inputName, inputPhoneNumber, inputEmail);

    }

    private void HandleRemoveContact()
    {
        console.WriteLine("Id van contact: ");
        var inputId = console.ReadLine();
        var Id = contactService.IsIdGuid(inputId);
        var c = contactService.SearchContactById(Id);
        console.WriteLine("Contact verwijderen?: Yes/No ");
        var inputYN = console.ReadLine().ToLower();
        if (inputYN == "yes")
        {
            contactService.RemoveContact(Id);
            console.WriteLine("Contact verwijdert");
        }
        else
        {
            console.WriteLine("Contact verwijderen geannuleerd");
        }
    }


    private void HandleSearchContact()
    {
        console.WriteLine("Zoeken op naam of Id: Naam/Id");
        var inputNameorId = console.ReadLine().ToLower();
        if (inputNameorId == "naam")
        {
            console.WriteLine("Geef een (deel van de) naam in:");
            var inputName = console.ReadLine();
            var foundContacts = contactService.SearchContactByName(inputName);
            console.WriteLine("------------");
            if (foundContacts.Count() == 0)
            {
                console.WriteLine($"Geen gevonden resultaten voor {inputName}");
            }
            foreach (var c in foundContacts)
            {
                WriteContact(c);
            }
        }
        else if (inputNameorId == "id")
        {
            console.WriteLine("Geef Id in:");
            var inputId = console.ReadLine();
            var validId = contactService.IsIdGuid(inputId);
            var c = contactService.SearchContactById(validId);
            console.WriteLine("------------");
            WriteContact(c);
        }
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "q": return false;
            case "1": HandleAddContact(); break;
            case "2": HandleShowContactlist(); break;
            case "3": HandleAdjustContact(); break;
            case "4": HandleRemoveContact(); break;
            case "5": HandleSearchContact(); break;
            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }

}