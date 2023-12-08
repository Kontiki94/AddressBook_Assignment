using Assignment_AddressBook.ConsoleApp.Utilities;
using Assignment_AddressBook.Shared.Interfaces;
using Microsoft.VisualBasic.FileIO;
namespace Assignment_AddressBook.ConsoleApp.Services;

public class ContactServiceConsoleApp
{
    private readonly IContactService _contactService;
    private readonly HelpersConsoleApp _helpers = new HelpersConsoleApp();


    public ContactServiceConsoleApp(IContactService contactService)
    {
        _contactService = contactService;
    }

    public void AddContact(IContact contact)
    {
        Console.Write("Enter the first name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Enter the last name: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Enter the email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Enter the phone number: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write("Enter the address: ");
        contact.Address = Console.ReadLine()!;
        _contactService.AddContactToList(contact);
    }

    public void ShowAllContacts()
    {
        IEnumerable<IContact> contactList = _contactService.GetAllContactsFromList();

        foreach (var contact in contactList)
        {
            ContactInfo(contact);
        }
        Console.ReadKey();
    }
    public void ShowOneContact()
    {
        Console.Write("Enter the email of the contact you want to view: ");
        string email = Console.ReadLine()!;
        IContact contact = _contactService.GetOneContactFromList(email);

        if (contact != null)
        {
            ContactInfo(contact);
        }
        else
        {
            _helpers.ContactDoesNotExist();
        }
        Console.ReadKey();
    }

    public void UpdateContact()
    {
        Console.Write("Enter the email of the contact you want to edit: ");
        string email = Console.ReadLine()!;
        IContact contact = _contactService.GetOneContactFromList(email);
        if (contact == null)
        {
            _helpers.NoValidInput();
        }
        else
        {
            Console.Clear();
            ContactInfo(contact);
            bool isUpdating = true;

            while (isUpdating)
            {
                Console.Clear();
                Console.Write("What would you like to update? ");
                Console.WriteLine("\n\t1 Name\n\t2 Email\n\t3 Phone number\n\t4 Address\n\t0 Exit and save");
                var option = Console.ReadLine()!;
                switch (option)
                {
                    case "1":
                        Console.Write("Enter the new first name: ");
                        contact.FirstName = Console.ReadLine()!;
                        Console.Write("Enter the new last name: ");
                        contact.LastName = Console.ReadLine()!;
                        break;
                    case "2":
                        Console.Write("Enter the new email: ");
                        contact.Email = Console.ReadLine()!;
                        break;
                    case "3":
                        Console.Write("Enter the new phone number: ");
                        contact.Phone = Console.ReadLine()!;
                        break;
                    case "4":
                        Console.Write("Enter the new address: ");
                        contact.Address = Console.ReadLine()!;
                        break;
                    case "0":
                        ContactInfo(contact);
                        Console.WriteLine("Do you want to save the changes? y/n");
                        var save = Console.ReadLine() ?? "";
                        if (save.Equals("y", StringComparison.OrdinalIgnoreCase))
                        {
                            _contactService.UpdateContactFromList();
                        }
                        isUpdating = false;
                        break;
                    default:
                        _helpers.NoValidInput();
                        break;
                }
            }
        }
    }

    public void RemoveContact()
    {
        Console.Write("Type the email of the contact you want to remove: ");
        string email = Console.ReadLine()!;
        bool isDeleted = _contactService.RemoveContactFromList(email);

        if (isDeleted)
        {
            Console.WriteLine("Contact was removed succesfully. Press any key to return");
        }
        else
        {
            _helpers.ContactDoesNotExist();
        }
        Console.ReadKey();
    }

    public void ContactInfo(IContact contact)
    {
        Console.WriteLine($"---------------------------\n\t" +
            $"ID: {contact.Id}\n\t" +
            $"First name: {contact.FirstName}\n\t" +
            $"Last name: {contact.LastName}\n\t" +
            $"Email: {contact.Email}\n\t" +
            $"Phone number: {contact.Phone}\n\t" +
            $"Address: {contact.Address}" +
            $"\n--------------------------");
    }
}
