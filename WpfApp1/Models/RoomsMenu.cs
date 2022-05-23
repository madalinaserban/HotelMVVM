using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class RoomsMenu
    {

        public RoomsMenu()
        {

        }
        public RoomsMenu(int nr_camere, float price, int etaj)
        {
            Tip_Camera = nr_camere;
            Price = price;
            Etaj = etaj;
        }
        public int Tip_Camera { get; set; }
        public int Etaj { get; set; }
        public float Price { get; set; }
        public bool Balcon { get; set; }
        public bool Bucatarie { get; set; }
        public bool Frigider { get; set; }
        public int Nr_Camera { get; set; }

    }
}

