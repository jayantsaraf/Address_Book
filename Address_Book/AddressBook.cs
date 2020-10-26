using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Address_Book
{
    class AddressBook
    {
        public HashSet<Contact> list = new HashSet<Contact>();
        public void Input()
        {
            string[] details = new string[9];
            
            //// Taking input from user
            Console.WriteLine("Enter following details separated by ,");
            Console.WriteLine("First Name, Last Name, Address, City, State, pincode, phone, email address");
            details = Console.ReadLine().Split(",");
            var c1 = new Contact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]); 
            list.Add(c1);
            ////Writing the Contact details in Contact text file
            string path = @"C:\Users\jayant\source\repos\Address_Book\Address_Book\Contact.txt";
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(c1.fName + " " + c1.lName + " " + c1.address + " " + c1.city + " " + c1.state + " " + c1.zipcode +
                        " " + c1.phone + " " +c1.email);
                    streamWriter.Close();
                }
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
        public void display()
        {
            
            foreach(Contact i in list)
            {
                Console.WriteLine("First Name:" + i.fName + " Last Name:" + i.lName + " Address:" + i.address + " City:" + i.city + " "
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
            foreach(Contact i in list)
            {
                if (i.fName == firstName)
                {
                    Console.WriteLine("Enter new details as below separated by ,");
                    Console.WriteLine("Last Name, Address, City, State, pincode, phone, email address");
                    string[] details = Console.ReadLine().Split(",");
                    i.lName = details[0];
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
            foreach(Contact i in list)
            {
                if(i.fName==firstName)
                {
                    list.Remove(i);
                }
            }
        }
        public HashSet<Contact> GetAddressBook()
        {
            return list;
        }
        public void DiplayAlphabeticallyByPersonName()
        {
            List<Contact> sortedList = list.OrderBy(x => x.fName).ToList();
            Console.WriteLine("Dispaying the Person name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.fName);
        }
        public void DiplayAlphabeticallyByCityName()
        {
            List<Contact> sortedList = list.OrderBy(x => x.city).ToList();
            Console.WriteLine("Dispaying the City name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.city);
        }
        public void DiplayAlphabeticallyByStateName()
        {
            List<Contact> sortedList = list.OrderBy(x => x.state).ToList();
            Console.WriteLine("Dispaying the State name alphabetically");
            foreach (var name in sortedList)
                Console.WriteLine(name.state);
        }
        public void DiplayAlphabeticallyByZip()
        {
            List<Contact> sortedList = list.OrderBy(x => x.zipcode).ToList();
            Console.WriteLine("Dispaying the Zip Code Serially");
            foreach (var name in sortedList)
                Console.WriteLine(name.zipcode);
        }
    }
}
