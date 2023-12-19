using Assignment_AddressBook.ConsoleApp.Utilities;
using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
namespace Assignment_AddressBook.ConsoleApp.Services;

public class ContactServiceConsoleApp
{
    private readonly IContactService _contactService;
    private readonly HelpersConsoleApp _helpers = new HelpersConsoleApp();

    public ContactServiceConsoleApp(IContactService contactService)
    {
        _contactService = contactService;
    }
    /// <summary>
    /// Creates an empty instace of a contact. Lets the user fill in each property then checks if email already exists in the list, if not adds contact to the list.
    /// </summary>
    /// <param name="contact">Contact to be added</param>
    public void AddContact(IContact contact)
    {
        try
        {
            IEnumerable<IContact> _contactList = _contactService.GetAllContactsFromList();
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
            if (_contactList.Any(x => x.Email.ToLower() == contact.Email.ToLower()))
            {
                Console.WriteLine("A contact with this email already exists! Press Any key to return.");
                Console.ReadKey();
            }
            else
            {
                _contactService.AddContactToList(contact);
                Console.WriteLine("Contact added to addressbook!");
                _helpers.PressAnyKey();
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    /// <summary>
    /// Grabs an IEnum of all the contacts then loops out every contact in the list. ContactInfo() displays every property of each contact
    /// </summary>
    public void ShowAllContacts()
    {
        try
        {
            IEnumerable<IContact> contactList = _contactService.GetAllContactsFromList();
            Console.Clear();
            foreach (var contact in contactList)
            {
                ContactInfo(contact);
            }
            Console.ReadKey();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    /// <summary>
    /// Reads existing list, checks if an email already exists(converts to lower case). Uses ContactInfo() to print out the information
    /// </summary>
    public void ShowOneContact()
    {
        try
        {
            Console.Write("Enter the email of the contact you want to view: ");
            string email = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(email))
            {
                IContact contact = _contactService.GetOneContactFromList(email);
                if (contact is not null)
                {
                    ContactInfo(contact);
                }
                else
                {
                    _helpers.ContactDoesNotExist();
                    _helpers.PressAnyKey();
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    /// <summary>
    /// User inputs contact email to which contact they want to update. If contact is found user can change any property of the contact
    /// </summary>
    public void UpdateContact()
    {
        try
        {
            Console.Write("Enter the email of the contact you want to edit: ");
            string email = Console.ReadLine()!.ToLower();
            IContact contact = _contactService.GetOneContactFromList(email.ToLower());
            if (contact == null)
            {
                _helpers.NoValidInput();
                _helpers.PressAnyKey();
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
                            _helpers.PressAnyKey();
                            break;
                    }
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    /// <summary>
    /// User inputs contact email for which contact they want to remove. Sends to ContactService method, returns true if succesful and contact is deleted from list.
    /// </summary>
    public void RemoveContact()
    {
        try
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
                _helpers.PressAnyKey();
            }
            Console.ReadKey();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    /// <summary>
    /// Method to display contact properties
    /// </summary>
    /// <param name="contact">The contact to be displayed</param>
    public void ContactInfo(IContact contact)
    {
        try
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
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
