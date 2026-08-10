using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public class Employee
    {
        private string name;
        private string id;
        private string password;

        public string Name
        {
            get { return name; }
        }
        public string Id
        {
            get { return id; }
     
        }
        public string Password
        {
            get { return password; }
        }

        public Employee() 
        {
            name = null;
            id = null;
            password = null;
        }
        public Employee(string Name, string ID)
        {
            name = Name;
            id = ID;
            password = "12345678";
        }

        public Boolean logIn(string password)
        {
            if (password == this.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
