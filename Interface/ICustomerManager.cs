using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WORK.models;

namespace WORK.Interface
{
    public interface ICustomerManager
    {
        public void CreateCustomer(string firstName,string lastName,string email,int pin,string phoneNumber,string address);
        public void UpdateCustomer();
        public Customer GetCustomer(string email);
        public Customer Login(string email,string phoneNumber,int pin);  
        public Customer CheckWallet(string email);
        public Customer AddMoneyToWallet(string email,double amount);
        public void GetAllCustomer();
        public void DeleteCustomer();
        public void ReadFromFile();
        public void RewriteFile();
       
    }
}