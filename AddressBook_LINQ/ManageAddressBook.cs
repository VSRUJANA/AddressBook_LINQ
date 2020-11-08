using System;
using System.Collections.Generic;
using System.Data;

namespace AddressBook_LINQ
{
    class ManageAddressBook
    {
        // Create Data table to store address book details
        public DataTable dataTable = new DataTable();
        public void CreateAddressBook()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));
        }
    }
}
