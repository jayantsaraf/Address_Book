using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Address_Book
{
    class MultipleAddressBook
    {
        Dictionary<string, AddressBook> collectionAddressBook = new Dictionary<string, AddressBook>();

        public void AddAddressBook(string firstName)
        {
            AddressBook newAddressBook = new AddressBook();
            collectionAddressBook.Add(firstName, newAddressBook);
        }

        public AddressBook GetAddressBook(string firstName)
        {
            if(collectionAddressBook.ContainsKey(firstName))
            {
                return collectionAddressBook[firstName];
            }
            return null;
        }
        public bool CheckDuplicateFirstName(string fName)
        {
            if(collectionAddressBook.ContainsKey(fName))
            {
                return false;
            }
            return true;
        }
        public string[] SearchByCity(string searchKey)
        {
            int countOfList = 0;
            string[] listOfSearchPersonsByCity = new string[] { };
            Dictionary<string, AddressBook>.Enumerator enumerator = collectionAddressBook.GetEnumerator();
            while(enumerator.MoveNext())
            {
                AddressBook searchAddressBook =  enumerator.Current.Value;
                List<Contact> listOfSearch =  searchAddressBook.GetAddressBook();
                foreach(Contact i in listOfSearch)
                {
                    if(i.city==searchKey)
                    {
                        listOfSearchPersonsByCity[countOfList++] = i.fName;
                    }
                }
            }
            return listOfSearchPersonsByCity;
        }
        public string[] SearchByState(string searchKey)
        {
            int countOfList = 0;
            string[] listOfSearchPersonsByState = new string[] { };
            Dictionary<string, AddressBook>.Enumerator enumerator = collectionAddressBook.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AddressBook searchAddressBook = enumerator.Current.Value;
                List<Contact> listOfSearch = searchAddressBook.GetAddressBook();
                foreach (Contact i in listOfSearch)
                {
                    if (i.city == searchKey)
                    {
                        listOfSearchPersonsByState[countOfList++] = i.fName;
                    }
                }
            }
            return listOfSearchPersonsByState;
        }

    }
}
