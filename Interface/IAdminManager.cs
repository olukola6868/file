using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WORK.models;

namespace WORK.Interface
{
    public interface IAdminManager
    {
        public void CreateAdmin(string firstName,string lastName,string email,int pin,string post);
        public Admin GetAdmin(string email);
        public void UpdateAdmin();
        public void GetAllAdmin();
        public void DeleteAdmin();
        public Admin Login(string email,int pin);
        public void ReadFromFile();
        public void ReWriteFile(); 

    }
}