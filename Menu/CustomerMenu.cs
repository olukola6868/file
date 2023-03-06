using WORK.Implementation;
using WORK.Interface;
using WORK.models;

namespace WORK.Menu
{
    public class CustomerMenu
    {
        ICustomerManager customerManger = new CustomerManager();
        public void CustomerMenu2()
        {
            Console.WriteLine("Enter 1 to register");
            Console.WriteLine("Enter 2 to Login");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                RegisterCustomerMenu();
                Console.WriteLine("----------------------------------------------");

            }
            else if (choice == 2)
            {
                LoginCustomerMenu();
                Console.WriteLine("----------------------------------------------");

            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        public void RegisterCustomerMenu()
        {
            Console.Write("Enter your first name: ");
            string fName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lName = Console.ReadLine();
            Console.Write("Enter your email address: ");
            string email = Console.ReadLine();
            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your address: ");
            string address = Console.ReadLine();
            customerManger.CreateCustomer(fName, lName, email, pin, phoneNumber, address);
            CustomerMenu2();
        }
        public void LoginCustomerMenu()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Customer ad = customerManger.Login(email, phoneNumber, pin);
            if (ad != null)
            {
                Console.WriteLine("Login Successful");
                CustomerSubMenu();
            }
            else
            {
                Console.WriteLine("Wrong pin or email");
                CustomerMenu2();
            }
        }
        public void CustomerSubMenu()
        {
            bool isExit = false;
            while (!isExit)
            {
                ICardManager cardManager = new CardManager();
                Console.WriteLine("Enter 1 to buy card");
                Console.WriteLine("Enter 2 to check wallet");
                Console.WriteLine("Enter 0 to log out");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter 1 for #1000 card");
                    Console.WriteLine("Enter 2 for #500 card");
                    Console.WriteLine("Enter 3 for #200 card");
                    Console.WriteLine("Enter 4 for #100 card");
                    Console.WriteLine("Enter 0 for main menu");
                    int opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                    {
                        cardManager.CreateOneThousandHundredNairaCard(1000);
                        CustomerSubMenu();
                    }
                    else if (opt == 2)
                    {
                        cardManager.CreateFiveHundredNairaCard(500);
                        CustomerSubMenu();
                    }
                    else if (opt == 3)
                    {
                        cardManager.CreateTwoHundredNairaCard(200);
                        CustomerSubMenu();
                    }
                    else if (opt == 4)
                    {
                        cardManager.CreateHundredNairaCard(100);
                        CustomerSubMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else if (choice == 2)
                {
                    CustomerWalletMenu();
                }
                else if (choice == 0)
                {
                    Console.WriteLine("Logging out Application...");
                    isExit = true;
                }
            }
        }
        public void CustomerWalletMenu()
        {
            Console.WriteLine("Enter 1 to add money to wallet");
            Console.WriteLine("Enter 2 to check wallet balance");
            Console.WriteLine("Enter 3 to log out");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your amount: ");
                double amount = double.Parse(Console.ReadLine());
                customerManger.AddMoneyToWallet(email, amount);
                CustomerWalletMenu();
            }
            else if (choice == 2)
            {
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                Console.Write("You have successfully checked your wallet: ");
                customerManger.CheckWallet(email);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}