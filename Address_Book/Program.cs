using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book
{

    class Program
    {

        static void Main(string[] args)
        {
            MultipleAddressBook collectionAddressBook = new MultipleAddressBook();
            AddressBook newAddressBook = new AddressBook();
            bool option1 = true;
            while (option1)
            {
                StartAddressBook:
                Console.WriteLine("Enter your choice: 1. Add adress book, 2.Open address book," +
                    "3. View persons by City, 4. View Person by State, 5.Exit");
                int option = int.Parse(Console.ReadLine());
                string addressBookName;
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter name of address book");
                        addressBookName = Console.ReadLine();
                        bool duplicateFirstNameCheck = collectionAddressBook.CheckDuplicateFirstName(addressBookName);
                        if (duplicateFirstNameCheck == false)
                        {
                            Console.WriteLine("Address Book with this fist name already exists");
                            goto StartAddressBook;
                        }
                        collectionAddressBook.AddAddressBook(addressBookName);
                        newAddressBook = collectionAddressBook.GetAddressBook(addressBookName);
                        break;

                    case 2:
                        Console.WriteLine("Enter first name of address book to be opened");
                        addressBookName = Console.ReadLine();
                        newAddressBook = collectionAddressBook.GetAddressBook(addressBookName);
                        if (newAddressBook == null)
                        {
                            Console.WriteLine("No such Address Book");
                            goto StartAddressBook;
                        }
                        break;
                    case 3:
                        cityEntry:
                        Console.WriteLine("Enter city name whose person details you want");
                        string cityRequired = Console.ReadLine();
                        Dictionary<string, Contact> cityDictionary = collectionAddressBook.CityDictionary();
                        int cityCount = 0;
                        foreach (var dict in cityDictionary)
                        {
                            if (cityDictionary.ContainsKey(cityRequired))
                            {
                                Console.WriteLine("First Name:" + dict.Value.firstName + "Last Name:" + dict.Value.lastName +
                                    "Address:" + dict.Value.address + "City:" + dict.Value.city
                                   + "State:" + dict.Value.state + "pincode:" + dict.Value.phone + "phone: " + dict.Value.phone + "email address:" + dict.Value.email + "\n");
                            }
                            else
                            {
                                Console.WriteLine("City doesn't exist");
                                goto cityEntry;
                            }
                            cityCount++;
                        }
                        Console.WriteLine("Total cities : " + cityCount);
                        break;
                    case 4:
                        stateEntry:
                        Console.WriteLine("Enter state name whose person details you want");
                        string stateRequired = Console.ReadLine();
                        Dictionary<string, Contact> stateDictionary = collectionAddressBook.StateDictionary();
                        int stateCount = 0;
                        foreach (var dict in stateDictionary)
                        {
                            if (stateDictionary.ContainsKey(stateRequired))
                            {
                                Console.WriteLine("First Name:" + dict.Value.firstName + "Last Name:" + dict.Value.lastName +
                                    "Address:" + dict.Value.address + "City:" + dict.Value.city
                                   + "State:" + dict.Value.state + "pincode:" + dict.Value.phone + "phone: " + dict.Value.phone + "email address:" + dict.Value.email + "\n");
                            }
                            else
                            {
                                Console.WriteLine("State doesn't exist");
                                goto stateEntry;
                            }
                            stateCount++;
                        }
                        Console.WriteLine("Total states : " + stateCount);
                        break;
                    case 5:
                        option1 = false;
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        goto StartAddressBook;
                }
                while (option1 == true)
                {
                    Console.WriteLine("Welcome to Address Book!");
                    int a = 1;
                    while (a == 1)
                    {
                        if (newAddressBook == null)
                        {
                            break;
                        }

                        List<Contact> list = new List<Contact>();
                        Console.WriteLine("Enter your choice: 0.Add the data, 1.View the data, 2.Edit the contact, 3.Remove contact, " +
                            "4. Go to multiple address book option, 5. Display Person Name Alphabetically,6. Display City Name Alphabetically, " +
                            "7. Display State Name Alphabetically,8. Display Zip Code serially,9.Exit");
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 0:
                                newAddressBook.Input();
                                break;
                            case 1:
                                newAddressBook.display();
                                break;
                            case 2:
                                Console.WriteLine("Enter the first name of contacts to be edited");
                                string first = Console.ReadLine();
                                int check = newAddressBook.Edit(first);
                                if (check == 0)
                                {
                                    Console.WriteLine("Name not found");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Enter the fist name of contact to be removed");
                                first = Console.ReadLine();
                                newAddressBook.Remove(first);
                                break;
                            case 4:
                                goto StartAddressBook;
                            case 5:
                                newAddressBook.DiplayAlphabeticallyByPersonName();
                                goto StartAddressBook;
                            case 6:
                                newAddressBook.DiplayAlphabeticallyByCityName();
                                goto StartAddressBook;
                            case 7:
                                newAddressBook.DiplayAlphabeticallyByStateName();
                                goto StartAddressBook;
                            case 8:
                                newAddressBook.DiplayAlphabeticallyByZip();
                                goto StartAddressBook;
                            case 9:
                                a = 0;
                                break;
                            default:
                                Console.WriteLine("Enter correct choice");
                                break;
                        }
                        AddressBook.ImplementCSVDataDandling();
                        AddressBook.CsvToJSON();
                    }
                }
            }

        }



    }
}

