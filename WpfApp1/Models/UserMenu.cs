using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.LogicModel
{
    class UserMenu
    {
        public UserMenu()
        {

        }
        public UserMenu(string nume, string prenume, string mail)
        {
            Nume = nume;
            Prenume = prenume;
            Email = mail;
        }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }

    }
}
