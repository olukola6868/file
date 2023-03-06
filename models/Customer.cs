using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WORK.models
{
    public class Customer : User
    {
        public string Address{get;set;}
        public int RegNo{get;set;}
        public string PhoneNumber{get;set;}
        public double Wallet{get;set;}
        public double Amount{get;set;}

        public Customer(string firstName,string lastName,string email,int pin,string address,int regNo,string phoneNumber) : base(firstName,lastName,email,pin)
        {
            Address = address;
            RegNo = regNo;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $" First name: {FirstName}       Last name: {LastName}         phone number {PhoneNumber}        Addres:{Address} ";
        }
        public string ConvertToFileFormat()
        {
            return $"{FirstName}***{LastName}***{Email}***{PIN}***{Address}***{RegNo}***{PhoneNumber}";
        }
        public string Test(string fName, string lName)
        {
            return fName;
        }
        public static Customer ConvertToCustomer(string customerInfo)
        {
            string[]info = customerInfo.Split("***");
            return new Customer(info[0],info[1],info[2],int.Parse(info[3]),info[4],int.Parse(info[5]),info[6]);
        }
    }
}