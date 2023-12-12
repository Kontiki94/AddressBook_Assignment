using Assignment_AddressBook.Shared.Interfaces;
using Assignment_AddressBook.Shared.Models;
using Assignment_AddressBook.Shared.Services;
using Moq;
namespace AddressBook.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddToList_Should_AddOneContact_ToAddressBook_ThenReturnTrue()
    {
        //Arrange
        var mockFileManager = new Mock<IFileManager>();
        IContact contact = new Contact { FirstName = "Hassan", LastName = "Al Heidari", Email = "test@domain.com", Phone = "0701234567", Address = "testvägen 1" };
        mockFileManager.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IContactService contactService = new ContactService(mockFileManager.Object);

        //Act
        bool result = contactService.AddContactToList(contact);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddToList_ShouldThrowError_ContactAlreadyExist_ThenReturnFalse()
    {
        //Arrange
        var mockFileManager = new Mock<IFileManager>();
        IContactService contactService = new ContactService(mockFileManager.Object);
        mockFileManager.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IContact contact = new Contact { Email = "test@domain.com" };

        //Act
        contactService.AddContactToList(contact);
        bool result = contactService.AddContactToList(contact);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddToList_ShouldNot_AddOneContact_ToAddressBook_ThenReturnFalse()
    {
        //Arrange
        var mockFileManager = new Mock<IFileManager>();
        IContact contact = new Contact { FirstName = "Hassan", LastName = "Al Heidari", Email = "test@domain.com", Phone = "0701234567", Address = "testvägen 1" };
        mockFileManager.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception ("tested exception"));
        IContactService contactService = new ContactService(mockFileManager.Object);

        //Act
        bool result = contactService.AddContactToList(contact);

        //Assert
        Assert.False(result);
    }
    [Fact]
    public void RemoveFromList_ShouldRemoveOneContactFromList_ThenReturnTrue()
    {

        //Arrange
        var mockFileManager = new Mock<IFileManager>();
        IContact contact = new Contact { FirstName = "Hassan", LastName = "Al Heidari", Email = "test@domain.com", Phone = "0701234567", Address = "testvägen 1" };
        mockFileManager.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IContactService contactService = new ContactService(mockFileManager.Object);

        //Act
        bool resultAdded = contactService.AddContactToList(contact);
        bool resultRemoved = contactService.RemoveContactFromList(contact.Email);

        //Assert
        Assert.True(resultAdded);
        Assert.True(resultRemoved);
    }
}
