using Assignment_AddressBook.Shared.Interfaces;

namespace Assignment_AddressBook.ConsoleApp.Services;

internal class MenuService
{
    private readonly ContactServiceConsoleApp _contactService;
    private readonly IContact _contact;


    public MenuService(ContactServiceConsoleApp contactService, IContact contact)
    {
        _contactService = contactService;
        _contact = contact;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 View all contacts");
            Console.WriteLine("3 View one contact");
            Console.WriteLine("4 Update a contact");
            Console.WriteLine("5 Remove a contact");
            Console.WriteLine("0 Exit application");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _contactService.AddContact(_contact);
                    Console.Clear();
                    break;
                case "2":
                    _contactService.ShowAllContacts();
                    Console.Clear();
                    break;
                case "3":
                    _contactService.ShowOneContact();
                    Console.Clear();
                    break;
                case "4":
                    _contactService.UpdateContact();
                    Console.Clear();
                    break;
                case "5":
                    _contactService.RemoveContact();
                    Console.Clear();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong input. Please enter a valid input");
                    break;
            }
        }
    }
}
