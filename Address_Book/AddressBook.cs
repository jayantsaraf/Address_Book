using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace Address_Book
{
    class AddressBook
    {
        public static HashSet<Contact> listOfContacts = new HashSet<Contact>();
        public void Input()
        {
            string[] details = new string[9];
            
            //// Taking input from user
            Console.WriteLine("Enter following details separated by ,");
            Console.WriteLine("First Name, Last Name, Address, City, State, pincode, phone, email address");
            details = Console.ReadLine().Split(",");
            var contactInfo = new Contact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]); 
            listOfContacts.Add(contactInfo);
            ////Writing the Contact details in Contact text file
            string path = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Contact.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(contactInfo.firstName + " " + contactInfo.lastName + " " + contactInfo.address + " " + contactInfo.city + " " + contactInfo.state + " " + contactInfo.zipcode +
                        " " + contactInfo.phone + " " +contactInfo.email);
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        /// <summary>
        /// Reading and Writing files into CSV file
        /// </summary>
        public static void ImplementCSVDataDandling()
        {
            string FilePath = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Utility\ContactInfo.csv";
            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Reading done successfully from ContactInfo.csv file");
                foreach (Contact contact in listOfContacts)
                {
                    Console.WriteLine("\t" + contact.firstName);
                    Console.WriteLine("\t" + contact.lastName);
                    Console.WriteLine("\t" + contact.address);
                    Console.WriteLine("\t" + contact.city);
                    Console.WriteLine("\t" + contact.state);
                    Console.WriteLine("\t" + contact.zipcode);
                    Console.WriteLine("\n");
                }
                using (var writer = new StreamWriter(FilePath))
                using (var csvEport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvEport.WriteRecords(listOfContacts);
                }
            }

        }
        /// <summary>
        /// Reading files from CSV and writing to JSON file
        /// </summary>
        public static void CsvToJSON()
        {

            string importFilePath = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Utility\ContactInfo.csv";
            string exportFilePath = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Utility\ContactInfo.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Console.WriteLine("Reading done successfully from ContactInfo.csv file");
                foreach (Contact contact in listOfContacts)
                {
                    Console.WriteLine("\t" + contact.firstName);
                    Console.WriteLine("\t" + contact.lastName);
                    Console.WriteLine("\t" + contact.address);
                    Console.WriteLine("\t" + contact.city);
                    Console.WriteLine("\t" + contact.state);
                    Console.WriteLine("\t" + contact.zipcode);
                    Console.WriteLine("\n");
                }
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, listOfContacts);
                }
            }

        }
        public void display()
        {
            
            foreach(Contact i in listOfContacts)
            {
                Console.WriteLine("First Name:" + i.firstName + " Last Name:" + i.lastName + " Address:" + i.address + " City:" + i.city + " "
                                   + " State:" + i.state + " pincode:" + i.phone + " phone: " + i.phone + " email address:" + i.email);
            }

            //// Displaying using File Operation
            Console.WriteLine("Displaying using File Operation");
            string path = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Contact.txt";
            if (File.Exists(path))
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        String fileData = "";
                        while ((fileData = sr.ReadLine()) != null)
                            Console.WriteLine((fileData));
                    }
                }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }

        public int Edit(string firstName)
        {
            int c = 1;
            foreach(Contact i in listOfContacts)
            {
                if (i.firstName == firstName)
                {
                    Console.WriteLine("Enter new details as below separated by ,");
                    Console.WriteLine("Last Name, Address, City, State, pincode, phone, email address");
                    string[] details = Console.ReadLine().Split(",");
                    i.lastName = details[0];
                    i.address = details[1];
                    i.city = details[2];
                    i.state = details[3];
                    i.zipcode = details[4];
                    i.phone = details[5];
                    i.email = details[6];
                }
                else
                    c = 0;
            }
            return c;
        }

        public void Remove(string firstName)
        {
            foreach(Contact i in listOfContacts)
            {
                if(i.firstName==firstName)
                {
                    listOfContacts.Remove(i);
                }
            }
        }
        public HashSet<Contact> GetAddressBook()
        {
            return listOfContacts;
        }
        public void DiplayAlphabeticallyByPersonName()
        {
            List<Contact> sortedList = listOfContacts.OrderBy(x => x.firstName).ToList();
            Console.WriteLine("Dispaying the Person name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.firstName);
        }
        public void DiplayAlphabeticallyByCityName()
        {
            List<Contact> sortedList = listOfContacts.OrderBy(x => x.city).ToList();
            Console.WriteLine("Dispaying the City name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.city);
        }
        public void DiplayAlphabeticallyByStateName()
        {
            List<Contact> sortedList = listOfContacts.OrderBy(x => x.state).ToList();
            Console.WriteLine("Dispaying the State name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.state);
        }
        public void DiplayAlphabeticallyByZip()
        {
            List<Contact> sortedList = listOfContacts.OrderBy(x => x.zipcode).ToList();
            Console.WriteLine("Dispaying the Zip Code Serially");
            foreach (var name in sortedList)
                Console.WriteLine(name.zipcode);
        }
    }
}
