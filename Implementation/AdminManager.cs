using System;
using System.Collections.Generic;
using System.IO;
using WORK.Interface;
using WORK.models;

namespace WORK.Implementation
{
    public class AdminManager : IAdminManager
    {
        public static List<Admin> Admins = new List<Admin>();
        public string filePath = "./Files/admin.txt";
        public void CreateAdmin(string firstName, string lastName, string email, int pin, string post)
        {
            Random rand = new Random();
            int adminId = rand.Next(10, 99);
            Admin admin = new Admin(firstName, lastName, email, pin, adminId, post);
            Admins.Add(admin);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(admin.ConvertToFileFormat());
            }
            Console.WriteLine($"Congratulation!!! Mr/Mrs.{firstName} {lastName} The admin was created successfully and your admin id is (HAR/ID {adminId})");
        }
        public void DeleteAdmin()
        {
            Console.WriteLine("Enter the email of the admin to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in Admins)
            {
                if (item.Email == email)
                {
                    Admins.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
            Console.WriteLine("Deleted successfully");
        }
        public Admin GetAdmin(string email)
        {
            foreach (var item in Admins)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }
        public void GetAllAdmin()
        {
            foreach (var item in Admins)
            {
                Console.WriteLine(item);
            }
            
        }
        public Admin Login(string email, int pin)
        {
            foreach (var item in Admins)
            {
                if (item.Email == email && item.PIN == pin)
                {
                    return item;
                }
            }
            return null;
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Reading");
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() > -1)
                {
                    string adminInfo = reader.ReadLine();
                    Admins.Add(Admin.ConvertToAdmin(adminInfo));
                }
            }
        }
        public void ReWriteFile()
        {
            File.WriteAllText(filePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                foreach (var admin in Admins)
                {
                    writer.WriteLine(admin.ConvertToFileFormat());
                }
            }
        }
        public void UpdateAdmin()
        {
            Console.WriteLine("Enter the email of the admin you want to update: ");
            string email = Console.ReadLine().Trim();
            Admin adminToUpdate = GetAdmin(email);
            if (adminToUpdate != null)
            {
                Console.WriteLine("Enter the first name of the admin you want to update");
                string firstName = Console.ReadLine().Trim();
                adminToUpdate.FirstName = firstName;

                Console.WriteLine("Enter the last name of the admin you want to update");
                string lastName = Console.ReadLine().Trim();
                adminToUpdate.LastName = lastName;

                Console.WriteLine("Enter the post you want to update");
                string post = Console.ReadLine().Trim();
                adminToUpdate.Post = post; 
                ReWriteFile();
                Console.WriteLine("Admin Updated successful");
            }
            else
            {
                Console.WriteLine("Admin not found");
            }
        }
    }
}