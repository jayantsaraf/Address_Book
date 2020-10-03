using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book
{
    public class Contact
    {
        public string fName;
        public string lName;
        public string address;
        public string city;
        public string state;
        public string zipcode;
        public string phone;
        public string email;

        public Contact()
        {
            this.fName = "";
            this.lName = "";
            this.address = "";
            this.city = "";
            this.state = "";
            this.zipcode = "";
            this.phone = "";
            this.email = "";
        }

        public Contact(string firstName, string lastName, string address, string city, string state, string zipcode, string phone, string email)
        {
            this.fName = firstName;
            this.lName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.phone = phone;
            this.email = email;
        }

        public void display()
        {
            Console.WriteLine("First Name:" + this.fName +
                              "Last Name:" + this.lName +
                              "Address:" + this.address +
                              "City:" + this.city +
                              "State:" + this.state +
                              "Zip:" + this.zipcode +
                              "Phone:" + this.phone +
                              "Email:" + this.email);
        }
    }
}
