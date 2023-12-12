using Assignment_AddressBook.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Assignment_AddressBook.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileManager _fileManager;

    public ContactService(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }

    private List<IContact> _contactList = [];
    private readonly string _filepath = @"C:\Users\hassa\source\repos\ClassLibrary\Contacts.json";

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email))
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
    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {
            var content = _fileManager.GetContentFromFile(_filepath);
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contactList;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public IContact GetOneContactFromList(string email)
    {
        var contact = _contactList.FirstOrDefault(x => x.Email == email)!;
        return contact;
    }
    public void UpdateContactFromList()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            _fileManager.SaveToFile(_filepath, json);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }
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
