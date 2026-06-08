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
                throw new Exception("geen ");
            }
        }
        console.WriteLine("Telefoonnummer: ");
        var inputPhoneNumber = console.ReadLine();
        console.WriteLine("Email: ");
        var inputEmail = console.ReadLine();


    }

    private bool HandleChoice(string choice)
    {
        switch (choice)
        {
            case "q": return false;
            case "1": HandleAddContact(); break;
            default: console.WriteLine("Ongeldige optie."); break;
        }
        return true;
    }

}