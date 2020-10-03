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
            Console.WriteLine("Welcome to Address Book!");
            Contact c1 = new Contact("rakesh", "sharma", "chinar park", "kolkata", "west bengal", "700157", "8017126325", "xyz@gmail.com");
            int a = 1;
            while (a == 1)
            {
                List<Contact> list = new List<Contact>();
                Console.WriteLine("Enter your choice: 0.Add the data, 1.View the data");
                int choice = int.Parse(Console.ReadLine());
                AddressBook customer = new AddressBook();
                switch (choice)
                {
                    case 0:
                        customer.Input();
                        break;
                    case 1:
                        customer.display();
                        break;
                    case 2:
                        Console.WriteLine("Enter the first name of contacts to be edited");
                        string first = Console.ReadLine();
                        int check = customer.Edit(first);
                        if (check == 0)
                        {
                            Console.WriteLine("Name not found");
                        }
                        break;

                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            }

        }



    }

}
