using Assignment_AddressBook.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_AddressBook.ConsoleApp.Utilities
{
    public class HelpersConsoleApp
    {
        public void NoValidInput()
        {
            Console.WriteLine("Please enter a valid input. Press any key to return");
            Console.ReadKey();
        }
        public void ContactDoesNotExist()
        {
            Console.WriteLine("Contact does not exist. Press any key to return");
        }
    }
}
