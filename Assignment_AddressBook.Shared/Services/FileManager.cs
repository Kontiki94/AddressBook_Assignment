using Assignment_AddressBook.Shared.Interfaces;
using System.Diagnostics;

namespace Assignment_AddressBook.Shared.Services;

public class FileManager : IFileManager
{
    /// <summary>
    /// Method to grab all the content within a file
    /// </summary>
    /// <param name="filepath">Filepath where file is saved</param>
    /// <returns>All the text within file</returns>
    public string GetContentFromFile(string filepath)
    {
        try
        {
            if(File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
        }
        catch(Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    /// <summary>
    /// Streamwriter to save content to a file in a specified filepath
    /// </summary>
    /// <param name="filepath">Filepath where file is saved</param>
    /// <param name="content">Content that is going to be saved</param>
    /// <returns>bool value: true if save was succesful</returns>
    public bool SaveToFile(string filepath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filepath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
