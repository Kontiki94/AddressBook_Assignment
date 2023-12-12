namespace Assignment_AddressBook.Shared.Interfaces;

public interface IFileManager
{
    /// <summary>
    /// Method to save into .json-file
    /// </summary>
    /// <param name="filepath">Specified filepath on where to save</param>
    /// <param name="content">Content to be saved</param>
    /// <returns>bool value: true if sucessful</returns>
    bool SaveToFile(string filepath, string content);
    /// <summary>
    /// Grabs all contect from a file
    /// </summary>
    /// <param name="filepath">Specified filepath on where to read file</param>
    /// <returns>text/objects from file</returns>
    string GetContentFromFile(string filepath);

}
