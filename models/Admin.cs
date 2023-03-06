using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WORK.models
{
    public class Admin : User
    {
        public int AdminId { get; set; }
        public string Post { get; set; }


        public Admin(string firstName, string lastName, string email, int pin, int adminId, string post) : base(firstName, lastName, email, pin)
        {
            AdminId = adminId;
            Post = post;
        }
        public override string ToString()
        {
            return $"Admin       {FirstName}        {LastName}       Post: {Post}";
        }
        public string ConvertToFileFormat()
        {
            return $"{FirstName}***{LastName}***{Email}***{PIN}***{AdminId}***{Post}";
        }
        public string Test(string fName, string lName)
        {
            return fName;
        }
        public static Admin ConvertToAdmin(string adminInfo)
        {
            string[] info = adminInfo.Split("***");
            return new Admin(info[0], info[1], info[2], int.Parse(info[3]), int.Parse(info[4]), info[5]);
        }
       
    }
}   