using ContactManager.Core;
using Microsoft.VisualBasic;

namespace ContactManager.Tests;

public class FakeConsole : IConsole
{
    public List<string> Output = new();
    public Queue<string> Input = new();

    public void WriteLine(string message) => Output.Add(message);
    public void Write(string message) => Output.Add(message);
    public string ReadLine() => Input.Dequeue();
}
public class UnitTest1
{

    [Fact]
    public void CheckMakeContact()
    {
        var name = "Fre";
        var contact1 = new Contact(name);
        Assert.Equal("Fre", contact1.Name);
    }

    [Fact]
    public void CheckAdd()
    {
        var name = "Fre";
        var contact1 = new Contact(name);
        var repo = new InMemoryContactRepository();
        repo.Add(contact1);
        Assert.Equal("Fre", repo.contactList[0].Name); //contactList is private
    }


    public class MenuTests
    {
        private ContactService service = new(new InMemoryContactRepository());
        private FakeConsole console = new();

        private Menu menu;

        public MenuTests()
        {
            menu = new Menu(console, service);
        }

        [Fact]
        public void Menu_Q_Exits()
        {
            console.Input.Enqueue("q");
            Assert.Equal(0, menu.Run());
            Assert.Contains("q. Exit", console.Output);
        }
    }
}