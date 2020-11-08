using System;

namespace AddressBook_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book using LINQ!");
            ManageAddressBook manager = new ManageAddressBook();
            manager.CreateAddressBook();
            manager.InsertContacts();
            // manager.EditExistingContact();
            // manager.DeleteContact("Edwin");
            // manager.RetrieveContactsByCity("Manhattan");
            // manager.RetrieveContactsByState("Florida");
            // manager.CountByCity();
            // manager.CountByState();
            // manager.SortContactsByNameForAgivenCity("Manhattan");
            // manager.DisplayDataTable();
            manager.CountByAddressBookType();
        }
    }
}