using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WORK.models
{
    public class User
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email{get;set;}
        public int PIN{get;set;}

        public User(string firstName,string lastName,string email,int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PIN = pin;
        }
    }
}