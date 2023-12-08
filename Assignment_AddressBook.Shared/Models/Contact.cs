﻿using Assignment_AddressBook.Shared.Interfaces;
namespace Assignment_AddressBook.Shared.Models;

public class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Guid Id { get; set; } = Guid.NewGuid();
}
