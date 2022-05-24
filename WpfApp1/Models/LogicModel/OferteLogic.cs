using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models.LogicModel
{
    class OferteLogic
    {
        private Bookingdb bookingdb = new Bookingdb();
        public bool AddOferte(string data1, string data2,string nume,int reducere)
        {
            var query = (from oferte in bookingdb.OFERTEs select oferte)?.ToList();
            foreach (var ofertelist in query)
            {
                if (ofertelist.NUME_OFERTA.Contains(nume))
                {
                    return false;
                }
            }
            bookingdb.OFERTEs.Add(new OFERTE()
            {
                DATA_FINAL = data2,
                DATA_INCEPERE=data1,
                NUME_OFERTA=nume,
                REDUCERE=reducere
            }) ;
            bookingdb.SaveChanges();


            return true;
        }
    }
}
