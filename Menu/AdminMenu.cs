using WORK.Implementation;
using WORK.Interface;
using WORK.models;
namespace WORK.Menu
{
    public class AdminMenu
    {
        IAdminManager adminManager = new AdminManager();
        ICustomerManager customerManager = new CustomerManager();
        CustomerMenu customerMenu = new CustomerMenu();
        ICardManager cardManager = new CardManager();
        CardManager card = new CardManager();
        public void AdminMenu2()
        {
            Console.WriteLine("Enter 1 to Register: ");
            Console.WriteLine("Enter 2 to Login: ");
            Console.WriteLine("Enter 0 for main menu or 3 to log out: ");
            int choice = int.Parse(Console.ReadLine());
            for (; ; )
            {
                if (choice == 1)
                {
                    RegisterAdminMenu();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                    AdminMenu2();
                }
                else if (choice == 2)
                {
                    LoginMenu();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                }
                else if (choice == 3)
                {
                    break;
                }
                else if (choice == 0)
                {
                    break;
                }
            }
        }
        public void RegisterAdminMenu()
        {
            Console.Write("Enter your first name: ");
            string fName = Console.ReadLine();

            Console.Write("Enter your last name: ");
            string lName = Console.ReadLine();

            Console.Write("Enter your email address: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("Enter your post: ");
            string post = Console.ReadLine();

            adminManager.CreateAdmin(fName, lName, email, pin, post);
        }
        public void LoginMenu()
        {
            Console.Write("Enter your email address: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            Admin admin = adminManager.Login(email, pin);
            if (admin != null)
            {
                Console.WriteLine("Login Successful");
                Console.WriteLine("Do you want to work on admin or you want to work on card or  you want to work on customer");
                Console.WriteLine("Enter 1 to work on admin");
                Console.WriteLine("Enter 2 to work on card");
                Console.WriteLine("Enter 3 to work on customer");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    AdminSubMenu();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                }
                else if (opt == 2)
                {
                    AdminSubMenu2();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                }
                else if (opt == 3)
                {
                    Console.WriteLine("Enter 1 to delete customer");
                    Console.WriteLine("Enter 2 to update customer");
                    Console.WriteLine("Enter 3 to view all customers");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        customerManager.DeleteCustomer();
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                    }
                    else if (choice == 2)
                    {
                        customerManager.UpdateCustomer();
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                    }
                    else if (choice == 3)
                    {
                        customerManager.GetAllCustomer();
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("customer not found");
                }
            }
            else
            {
                Console.WriteLine("Wrong email or password");
            }
        }
        public void AdminSubMenu()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                Console.WriteLine("Enter 1 to update admin");
                Console.WriteLine("Enter 2 to delete admin");
                Console.WriteLine("Enter 3 to view all admin");
                Console.WriteLine("Enter 0 to go back to main menu");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    adminManager.UpdateAdmin();
                }
                else if (choice == 2)
                {
                    adminManager.DeleteAdmin();
                    Console.WriteLine("----------------------------------------------");

                }
                else if (choice == 3)
                {
                    adminManager.GetAllAdmin();
                    Console.WriteLine("----------------------------------------------");
                }
                else if (choice == 0)
                {
                    Console.WriteLine(" ");
                    isPrev = true;
                    AdminMenu2();
                }
            }

        }
        public void AdminSubMenu2()
        {
            Console.WriteLine("Enter 1 to Create card");
            Console.WriteLine("Enter 2 to Get Card");
            Console.WriteLine("Enter 3 to Delete card");
            Console.WriteLine("Enter 4 to view all cards");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the price: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the card pin: ");
                long cardPin = long.Parse(Console.ReadLine());
                card.CreateCard(price, cardPin);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            }
            else if (choice == 2)
            {
                System.Console.WriteLine("Enter your price:");
                int price = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter your card pin: ");
                long cardPin = long.Parse(Console.ReadLine());
                card.GetCard(price, cardPin);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            }
            else if (choice == 3)
            {
                System.Console.WriteLine("Enter your price:");
                int price = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter your card pin: ");
                long cardPin = long.Parse(Console.ReadLine());
                card.DeleteCard(cardPin, price);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            }
            else if (choice == 4)
            {
                cardManager.GetAllCard();
                AdminMenu2();
            }
            else
            {
                System.Console.WriteLine("Invalid Input!!!! ");
            }
        }
    }
}