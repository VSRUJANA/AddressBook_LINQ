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
        }
    }
}
