using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using test_liste.admin.model;

namespace test_liste.admin.service
{
    internal class AdminService
    {
        private List<Admin> _listAdmin;

        public AdminService()
        {
            _listAdmin = new List<Admin>();

            this.Load();
        }

        // Metode

        public void Load()
        {
            Admin a1 = new Admin(1, "George", "george@gmail.com", "parola");

            _listAdmin.Add(a1);
        }

        public void Afisare()
        {
            foreach(Admin a in _listAdmin)
            {
                Console.WriteLine(a.Description() + "\n");
            }
        }

        public Admin FindById(int id)
        {
            foreach(Admin a in _listAdmin)
            {
                if(a.Id == id)
                {
                    return a;
                }
            }

            return null;
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 9999);
            while (this.FindById(id) != null)
            {
                id = rnd.Next(1, 9999);
            }
            return id;
        }

        public void AddAdmin(Admin admin)
        {
            admin.Id = this.NewId();
            _listAdmin.Add(admin);
        }

        public void RemoveById(int id)
        {
            _listAdmin.Remove(this.FindById(id));
        }
    }
}
