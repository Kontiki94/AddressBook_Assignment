namespace Assignment_AddressBook.Shared.Interfaces;

public interface IFileManager
{
    bool SaveToFile(string filepath, string content);
    string GetContentFromFile(string filepath);

}
