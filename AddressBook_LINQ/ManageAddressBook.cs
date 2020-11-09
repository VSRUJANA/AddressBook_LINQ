using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace AddressBook_LINQ
{
    class ManageAddressBook
    {
        public DataTable dataTable = new DataTable();

        // Create Data table to store address book details
        public void CreateAddressBook()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("BookName", typeof(string));
            dataTable.Columns.Add("BookType", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));
        }

        // Insert Contacts in Address book data table
        public void InsertContacts()
        {
            dataTable.Rows.Add("Tony", "Stark","Home", "Family", "Stark Tower", "Manhattan", "NewYork", "100001", "8987224534", "ironman@gmail.com");
            dataTable.Rows.Add("Steve", "Rogers", "Home", "Friends", "Times Square", "Brooklyn", "Texas", "1122", "9876778434", "capAmerica@yahoo.com");
            dataTable.Rows.Add("Bruce", "Banner", "Home", "Friends", "Vandalia", "Dayton", "Florida", "45441", "1403425612", "hulkBuster@gmail.com");
            dataTable.Rows.Add("Peter", "Parker", "Home", "Friends", "Queens", "NewYork", "NewYork", "10023", "4013224355", "spiderman@gmail.com");
            dataTable.Rows.Add("Stephen", "Strange", "Office", "Profession", "Bleecker", "Manhattan", "NewYork", "10431", "6300964579", "drStrange@yahoo.com");
            dataTable.Rows.Add("Thor", "Odinson", "Home", "Friends", "RoyalPalace", "Asgard", "Florida", "22544", "7849876734", "thor@rediffmail.com");
            dataTable.Rows.Add("Natasha", "Romanoff", "Office", "Profession", "Broadway", "NewYork", "NewYork", "10028", "4566735277", "blackwidow@gmail.com");
            dataTable.Rows.Add("Pepper", "Potts", "Home", "Family", "Stark Tower", "Manhattan", "NewYork", "100001", "8987224534", "pepper@gmail.com");
            dataTable.Rows.Add("Edwin", "Jarvis", "Home", "Friends" ,"Stark Tower", "Manhattan", "Texas", "100112", "6767986886", "jarvis@gmail.com");
            dataTable.Rows.Add("Howard","Stark", "Home", "Family" , "Richford", "Manhattan", "NewYork", "100001", "9876543256", "stark@yahoo.com");
        }

        // Display Address Book data table
        public void DisplayDataTable()
        {
            Console.Write("\n");
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ToString().PadRight(14));
            }
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine();
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col].ToString().PadRight(14));
                }
            }
        }

        // Editing existing Contact Details using persons's name
        public void EditExistingContact()
        {
            string name = "Bruce";
            var rowToUpdate = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName").Equals(name)).First();
            if (rowToUpdate != null)
            {
                rowToUpdate.SetField("PhoneNumber", "8300987876");
                rowToUpdate.SetField("ZipCode", "534260");
                Console.WriteLine("\nPhoneNumber and ZipCode of {0} updated successfully!", name);
                DisplayDataTable();
            }
            else
            {
                Console.WriteLine("There is no such record in the Address Book!");
            }
        }

        // Delete Contact using persons's name
        public void DeleteContact(string name)
        {
            var rowToDelete = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).First();
            if (rowToDelete != null)
            {
                rowToDelete.Delete();
                Console.WriteLine("\nContact with name '{0}' deleted successfully!", name);
                DisplayDataTable();
            }
        }

        // Retrieve contacts belonging to a City from the Address Book
        public void RetrieveContactsByCity(string city)
        {
            var result = dataTable.AsEnumerable().Where(dr => dr.Field<string>("City") == city);
            Console.Write("\nContacts belonging to '{0}'  city in the Address Book :\n", city);
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ToString().PadRight(14));
            }
            Console.Write("\n");
            foreach (DataRow row in result)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col].ToString().PadRight(14));
                }
                Console.Write("\n");
            }
        }

        // Retrieve contacts belonging to a State from the Address Book
        public void RetrieveContactsByState(string state)
        {
            var result = dataTable.AsEnumerable().Where(dr => dr.Field<string>("State") == state);
            Console.Write("\nContacts belonging to '{0}' state in the Address Book : \n", state);
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ToString().PadRight(14));
            }
            Console.Write("\n");
            foreach (DataRow row in result)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col].ToString().PadRight(14));
                }
                Console.Write("\n");
            }
        }

        // Count contacts by City in the Address Book
        public void CountByCity()
        {
            var query = dataTable.AsEnumerable().GroupBy(a => a.Field<string>("State")).Select(x => new { city = x.Key, count = x.Count() });
            Console.WriteLine("\nCount contacts by city in the Address Book :");
            Console.WriteLine("City\t\tCount");
            foreach (var distinctCity in query)
            {
                Console.WriteLine(distinctCity.city.PadRight(18) + distinctCity.count);
            }
        }

        // Count contacts by State in the Address Book
        public void CountByState()
        {
            var query= dataTable.AsEnumerable().GroupBy(a => a.Field<string>("State")).Select(x => new { state = x.Key, count = x.Count() });
            Console.WriteLine("\nCount contacts by State in the Address Book :");
            Console.WriteLine("State\t\tCount");
            foreach (var distinctState in query)
            {
                Console.WriteLine(distinctState.state.PadRight(18) + distinctState.count);
            }
        }

        // Sort Contacts By Name alphabetically for a given City
        public void SortContactsByNameForAgivenCity(string city)
        {
            Console.WriteLine("\nSorting Contacts By Name alphabetically for a given City :");
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ToString().PadRight(14));
            }
            Console.Write("\n");
            var records = dataTable.AsEnumerable().Where(r => r.Field<string>("city") == city).OrderBy(r => r.Field<string>("FirstName")).ThenBy(r => r.Field<string>("LastName"));
            foreach (DataRow row in records)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col].ToString().PadRight(14));
                }
                Console.Write("\n");
            }
        }

        // Count By AddressBook Type
        public void CountByAddressBookType()
        {
            var records = dataTable.AsEnumerable().GroupBy(a => a.Field<string>("BookType")).Select(x => new { type = x.Key, count = x.Count() });
            Console.WriteLine("\nCount contacts in AddressBook By Book Type :");
            Console.WriteLine("AddressBookType\t Count");
            foreach (var row in records)
            {
                Console.WriteLine(row.type.PadRight(18) + row.count);
            }
        }
    }
}
