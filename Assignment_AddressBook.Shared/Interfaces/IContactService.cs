namespace Assignment_AddressBook.Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(IContact contact);
    IContact GetOneContactFromList(string email);
    IEnumerable<IContact> GetAllContactsFromList();
    void UpdateContactFromList();
    bool RemoveContactFromList(string email);
}
