using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_AddressBook.Shared.Interfaces
{
    internal interface IFileManager
    {
        bool SaveToFile(string filepath, string content);
        string GetContentFromFile(string filepath);

    }
}
