using ContactManager.Core;

return
    new Menu(
        new SystemConsole(),
        new ContactService(new InMemoryContactRepository()))
    .Run();