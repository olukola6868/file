
using System;
using WORK.Implementation;
using WORK.Interface;

namespace WORK.Menu
{
    public class MainMenu
    {
        IAdminManager adminManager = new AdminManager();
        ICustomerManager customerManager = new CustomerManager();
        ICardManager cardManager = new CardManager();
        static CustomerMenu customerMenu = new CustomerMenu();
        AdminMenu adminMenu = new AdminMenu();

        // public void WelcomePage()
        public void Main()
        {
            adminManager.ReadFromFile();
            customerManager.ReadFromFile();
            cardManager.ReadFromFile();
            Console.WriteLine(@"
            ((((((((((((((((((((((((((((()))))))))))))))))))))))))))
            (((((((((((((((((((((((((((())))))))))))))))))))))))))))
            ((((( WELCOME TO OLUKOLA NETWORK MANAGEMENT SYSTEM )))))
            (((((((((((((((((((((())))))))))))))))))))))))))))))))))
            (((((((((((((((((((((((((())))))))))))))))))))))))))))))");
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("Enter 1 as an Admin: ");
                Console.WriteLine("Enter 2 as a customer: ");
                Console.WriteLine("Enter 0 to Exit application: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {

                    if (choice == 1)
                    {
                        Console.WriteLine("\nENTER SUPER ADMIN PASSWORD ENCODE BY  ADMIN TO  REGISTER ADMIN  ");
                        int check = int.Parse(Console.ReadLine().ToString());
                        {
                            if (check == 8888)
                            {
                                Console.WriteLine("Acess true outcode  input ");
                                AdminMenu am = new AdminMenu();
                                am.AdminMenu2();
                            }
                            else
                            {
                                System.Console.WriteLine(" invalid input ");
                                Main();
                            }
                        }
                    }

                }
                else if (choice == 2)
                {
                    CustomerMenu cm = new CustomerMenu();
                    cm.CustomerMenu2();
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Shutting Down Application...");
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}