using System.Collections.ObjectModel;

namespace Assignment_AddressBook.Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Method to add contact to list
    /// </summary>
    /// <param name="contact">Contact to be saved</param>
    /// <returns>bool value: True if succesful</returns>
    bool AddContactToList(IContact contact);
    /// <summary>
    /// Grab a contact from list with email
    /// </summary>
    /// <param name="email">Parameter used to find said contact</param>
    /// <returns>contact with said email</returns>
    IContact GetOneContactFromList(string email);
    /// <summary>
    /// Grabs all contacts from list
    /// </summary>
    /// <returns>IENum of type IContact</returns>
    IEnumerable<IContact> GetAllContactsFromList();
    /// <summary>
    /// updates contact within list
    /// </summary>
    /// <returns>bool value: true if sucessful</returns>
    bool UpdateContactFromList();
    /// <summary>
    /// Removes contact from list
    /// </summary>
    /// <param name="email">Parameter used to find said contact</param>
    /// <returns>bool value: true if sucessful</returns>
    bool RemoveContactFromList(string email);
}
