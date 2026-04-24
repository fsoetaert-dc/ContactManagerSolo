using Microsoft.VisualBasic;

namespace ContactManager.Core;

public class Menu(IConsole console, ContactService service)
{
    private ContactService service = service;
    private IConsole console = console;
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
        console.WriteLine("1. Maakt een nieuw contact");
        console.WriteLine("2. Toon contactenlijst");
        console.WriteLine("3. Update een contact");
        console.WriteLine("4. Verwijder een contact");
        console.WriteLine("5. Contact opzoeken");
        console.WriteLine("q. Exit");
        console.Write("Maak uw keuze:");
    }

    public void ShowContactList()
    {
        var contactListStrings = service.ContactListAsStrings();
        foreach (var contact in contactListStrings)
        {
            console.WriteLine(contact);
        }
    }

    public void UpdateContact()
    {
        console.WriteLine("Geef Idnummer in");
        var Id = console.ReadLine();
        var IdInt = int.Parse(Id);
        console.WriteLine("Geef naam in");
        var name = console.ReadLine();
        console.WriteLine("Geef email in");
        var email = console.ReadLine();
        console.WriteLine("Geef telefoonnummer in");
        var number = console.ReadLine();
        service.UpdateContact(service.CheckIfContactInList(IdInt), name, email, number);

    }
    private void HandleAddContact()
    {
        console.WriteLine("Naam:");
        var name = console.ReadLine();
        console.WriteLine("Email:");
        var email = console.ReadLine();
        console.WriteLine("Telefoonnummer:");
        var number = console.ReadLine();
        service.AddContact(name, email, number);
    }
    public void DeleteContact()
    {
        console.WriteLine("Geef Idnummer");
        var id = console.ReadLine();
        try
        {
            var idInt = int.Parse(id);
            service.DeleteContact(idInt);
            console.WriteLine($"Contact met Idnummer {idInt} is verwijderd");
        }
        catch (FormatException ex)
        {
            console.WriteLine(ex.Message);
        }


    }

    public void SearchContactByName()
    {
        console.WriteLine("Geef een naam in");
        var name = console.ReadLine();
        var FoundNames = service.FoundContactListAsStrings(name);
        foreach (var contact in FoundNames)
        {
            console.WriteLine(contact);
        }
    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1": HandleAddContact(); break;
            case "2": ShowContactList(); break;
            case "3": UpdateContact(); break;
            case "4": DeleteContact(); break;
            case "5": SearchContactByName(); break;
            case "q": return false;
            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }
}