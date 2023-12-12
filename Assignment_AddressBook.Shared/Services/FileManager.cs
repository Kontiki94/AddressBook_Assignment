using Assignment_AddressBook.Shared.Interfaces;
using System.Diagnostics;

namespace Assignment_AddressBook.Shared.Services;

public class FileManager : IFileManager
{
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
