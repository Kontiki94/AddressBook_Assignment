using Assignment_AddressBook.Shared.Interfaces;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Assignment_AddressBook.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileManager _fileManager;
    private ObservableCollection<IContact> _contactList = [];
    private readonly string _filepath = @"C:\Users\hassa\source\repos\ClassLibrary\Contacts.json";

    public ContactService(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }


    /// <summary>
    /// Adds contact to list and serializes object. Saves on local list and .json file at the same time
    /// </summary>
    /// <param name="contact">Contact to be added into list and json-file</param>
    /// <returns>Returns true if contact is succesfully added. False if email already exists or fails</returns>
    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email.ToLower() == contact.Email.ToLower()))//Checks if the email of contact to add already exists in the list
            {
                _contactList.Add(contact);
                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileManager.SaveToFile(_filepath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
    /// <summary>
    /// Fetches all text from json file and deserializes objects into a list
    /// </summary>
    /// <returns>Deserialized objects in a list </returns>
    public ObservableCollection<IContact> GetAllContactsFromList()
    {
        try
        {
            var content = _fileManager.GetContentFromFile(_filepath);
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<ObservableCollection<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contactList;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    /// <summary>
    /// fetches a contact 
    /// </summary>
    /// <param name="email">uses email to check if contact exists</param>
    /// <returns>contact with said email</returns>
    public IContact GetOneContactFromList(string email)
    {
        try
        {
            var contact = _contactList.FirstOrDefault(x => x.Email.ToLower() == email.ToLower())!;
            return contact;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    /// <summary>
    /// Saves to .json everytime a contact is updated
    /// </summary>
    /// <returns>True if successful used for checks in other applications</returns>
    public bool UpdateContactFromList()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            _fileManager.SaveToFile(_filepath, json);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
    /// <summary>
    /// Checks for contact with said email. If found removes from list and saves to .json to update the list
    /// </summary>
    /// <param name="email">uses email to check if contact exists</param>
    /// <returns>Bool value: if .json-save was succesful returns true</returns>
    public bool RemoveContactFromList(string email)
    {
        try
        {
            var contact = GetOneContactFromList(email);
            if (contact != null && contact.Email == email)
            {
                _contactList.Remove(contact);
                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileManager.SaveToFile(_filepath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
