using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Address_Book
{
    class MultipleAddressBook
    {
        Dictionary<string, AddressBook> collectionAddressBook = new Dictionary<string, AddressBook>();

        public void AddAddressBook(string addressBookName)
        {
            AddressBook newAddressBook = new AddressBook();
            collectionAddressBook.Add(addressBookName, newAddressBook);
        }

        public AddressBook GetAddressBook(string addressBookName)
        {
            if(collectionAddressBook.ContainsKey(addressBookName))
            {
                return collectionAddressBook[addressBookName];
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
                HashSet<Contact> listOfSearch =  searchAddressBook.GetAddressBook();
                foreach(Contact i in listOfSearch)
                {
                    if(i.city==searchKey)
                    {
                        listOfSearchPersonsByCity[countOfList++] = i.firstName;
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
                HashSet<Contact> listOfSearch = searchAddressBook.GetAddressBook();
                foreach (Contact i in listOfSearch)
                {
                    if (i.city == searchKey)
                    {
                        listOfSearchPersonsByState[countOfList++] = i.firstName;
                    }
                }
            }
            return listOfSearchPersonsByState;
        }
        public Dictionary<string, Contact> CityDictionary()
        {
            Dictionary<string, Contact> cityDictionary = new Dictionary<string, Contact>();
            Dictionary<string, AddressBook>.Enumerator enumerator = collectionAddressBook.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AddressBook searchAddressBook = enumerator.Current.Value;
                HashSet<Contact> listOfAddressBook = searchAddressBook.GetAddressBook();
                HashSet<Contact>.Enumerator enumerator1 = listOfAddressBook.GetEnumerator();
                while(enumerator1.MoveNext())
                {
                    Contact c = enumerator1.Current;
                    cityDictionary.Add(enumerator1.Current.city, c);
                    
                }
            }
            return cityDictionary;
        }
        public Dictionary<string, Contact> StateDictionary()
        {
            Dictionary<string, Contact> stateDictionary = new Dictionary<string, Contact>();
            Dictionary<string, AddressBook>.Enumerator enumerator = collectionAddressBook.GetEnumerator();
            while (enumerator.MoveNext())
            {
                AddressBook searchAddressBook = enumerator.Current.Value;
                HashSet<Contact> listOfAddressBook = searchAddressBook.GetAddressBook();
                HashSet<Contact>.Enumerator enumerator1 = listOfAddressBook.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    Contact c = enumerator1.Current;
                    stateDictionary.Add(enumerator1.Current.state, c);

                }
            }
            return stateDictionary;
        }
        

    }
}
