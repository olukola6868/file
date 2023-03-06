

using System;
using System.Collections.Generic;
using System.IO;
using WORK.Interface;
using WORK.models;

namespace WORK.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> Customers = new List<Customer>();
        public string filePath = "./Files/Customer.txt";
        public void CreateCustomer(string firstName, string lastName, string email, int pin, string phoneNumber, string address)
        {
                Random rand = new Random();
                int regNo = rand.Next(10, 99);
                Customer customer = new Customer(firstName, lastName, email, pin, address, regNo, phoneNumber);
                Customers.Add(customer);

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(customer.ConvertToFileFormat());
            }
            Console.WriteLine($"customer creation is successful and your Customer registration number is (HAR/NO {regNo})");
        }
        public Customer AddMoneyToWallet(string email, double amount)
        {
            Customer adm = GetCustomer(email);
            if (adm != null)
            {
                adm.Wallet += amount;
                Console.WriteLine($"Your balance is {adm.Wallet}");
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
            return null;
        }

        public Customer CheckWallet(string email)
        {
            Customer mda = GetCustomer(email);

            foreach (var item in Customers)
            {
                if (item.Email == email)
                {
                    Console.WriteLine($"Your wallet balance is {mda.Wallet}");
                }
            }
            return null;
        }
        public Customer GetCustomer(string email)

        {
            foreach (var item in Customers)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Customer Login(string email, string phoneNumber, int pin)
        {
            foreach (var item in Customers)
            {
                if (item.Email == email && item.PIN == pin && item.PhoneNumber == phoneNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("Enter the email of the customer you want to delete:");
            string email = Console.ReadLine().Trim();
            Customer customerToUpdate = GetCustomer(email);
            if (customerToUpdate != null)
            {
                Console.WriteLine("Enter the first name of the admin you want to update");
                string firstName = Console.ReadLine().Trim();
                customerToUpdate.FirstName = firstName;

                Console.WriteLine("Enter the last name of the admin you want to update");
                string lastName = Console.ReadLine().Trim();
                customerToUpdate.LastName = lastName;

                Console.WriteLine("Enter the phone number you want to update");
                string phoneNumber = Console.ReadLine().Trim();
                customerToUpdate.PhoneNumber = phoneNumber;
                RewriteFile();
                Console.WriteLine("Admin Updated successful");
            }
        }

        public void GetAllCustomer()
        {
            foreach (var item in Customers)
            {
                Console.WriteLine(item);
            }
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("Enter the email of the customer to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in Customers)
            {
                if (item.Email == email)
                {
                    Customers.Remove(item);
                    RewriteFile();
                    break;
                }
            }
            Console.WriteLine("Deleted successfully");
        }

        public void ReadFromFile()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() > -1)
                {
                    string customerInfo = reader.ReadLine();
                    Customers.Add(Customer.ConvertToCustomer(customerInfo));
                }
            }
        }

        public void RewriteFile()
        {
            File.WriteAllText(filePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                foreach (var item in Customers)
                {
                    writer.WriteLine(item.ConvertToFileFormat());
                }
            }
        }
    }
}