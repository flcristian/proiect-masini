using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_liste.admin.model
{
    internal class Admin
    {
        private int _id;
        private string _name;
        private string _email;
        private string _password;

        // Constructori

        public Admin(int id, string name, string email, string password)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
        }

        // Accesorii

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        // Metode

        public string Description()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Email : " + _email + "\n";

            return desc;
        }
    }
}
