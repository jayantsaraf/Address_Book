using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    class AddressBook
    {
        List<Contact> list = new List<Contact>();
        public void Input()
        {
            string[] details;
            
            //// Taking input from user
            Console.WriteLine("Enter following details separated by ,");
            Console.WriteLine("First Name, Last Name, Address, City, State, pincode, phone, email address");
            details = Console.ReadLine().Split(",");
            Contact c1 = new Contact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);
            list.Add(c1);
        }
        public void display()
        {
            foreach(Contact i in list)
            {
                Console.WriteLine("First Name:" + i.fName + "Last Name:" + i.lName + "Address:" + i.address + "City:" + i.city
                                   + "State:" + i.state + "pincode:" + i.phone + "phone: " + i.phone + "email address:" + i.email);
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
        public List<Contact> GetAddressBook()
        {
            return list;
        }
    }
}
