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

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email.ToLower() == contact.Email.ToLower()))
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
