using Assignment_AddressBook.Shared.Interfaces;
namespace Assignment_AddressBook.Shared.Models;

public class Contact : IContact
{
    public Contact()
    {

    }
    public Contact(string firstName, string lastName, string email, string phone, string address, Guid id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Address = address;
        Id = id;
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Guid Id { get; set; } = Guid.NewGuid();
}
