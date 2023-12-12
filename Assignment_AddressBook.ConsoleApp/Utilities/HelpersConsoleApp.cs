namespace Assignment_AddressBook.ConsoleApp.Utilities;

public class HelpersConsoleApp
{
    public void NoValidInput()
    {
        Console.WriteLine("Please enter a valid input.");
        Console.ReadKey();
    }
    public void ContactDoesNotExist()
    {
        Console.WriteLine("Contact does not exist.");
    }
    public void PressAnyKey()
    {
        Console.WriteLine("Press Any key to return");
        Console.ReadKey();
    }
}
