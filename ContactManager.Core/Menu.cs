using ContactManager.Core;

public class Menu
{
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
        console.WriteLine("q. Exit");
        console.Write("Maak uw keuze:");
    }

    private void HandleAddContact()
    {
        console.WriteLine("Naam: ");
        var inputNaam = console.ReadLine();
        foreach (var l in inputNaam)
        {
            if (!char.IsLetter(l))
            {
                throw new Exception("Geen geldige naam");
            }
        }
        console.WriteLine("Telefoonnummer: ");
        var inputPhoneNumber = console.ReadLine();
        console.WriteLine("Email: ");
        var inputEmail = console.ReadLine();
        contactService.AddContact(inputNaam, inputPhoneNumber, inputEmail);
        console.WriteLine($"Contact toegevoegd: {inputNaam}");
    }

    private void HandleShowContactlist()
    {
        var contactList = contactService.GetAll();
        console.WriteLine("------------");
        foreach (var c in contactList)
        {
            console.WriteLine(c.Name);
            console.WriteLine(c.PhoneNumber);
            console.WriteLine(c.Email);
            console.WriteLine("------------");
        }
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "q": return false;
            case "1": HandleAddContact(); break;
            case "2": HandleShowContactlist(); break;
            case "3":; break;
            case "4":; break;
            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }

}