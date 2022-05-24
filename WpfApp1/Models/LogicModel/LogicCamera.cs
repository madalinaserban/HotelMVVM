using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.View;
using WpfApp1.ViewModels;

namespace WpfApp1.Models.LogicModel
{
    class LogicCamera
    {
        private Bookingdb bookingdb = new Bookingdb();
        public List<RoomsMenu> GetProductsMenus()
        {
            var productQuery = (from camera in bookingdb.Cameras
                                where camera.DELETED != true
                                select new RoomsMenu
                                {
                                    Tip_Camera = (int)camera.NR_DORMITOARE,
                                    Price = (float)camera.PRET,
                                    Etaj = (int)camera.ETAJ,
                                    Balcon = (bool)camera.BALCON,
                                    Bucatarie = (bool)camera.BUCATARIE,
                                    Frigider = (bool)camera.FRIGIDER,
                                    Nr_Camera = (int)camera.NR_CAMERA
                                }).ToList();

            return productQuery;
        }

        public bool AddRoom(int nr_dormitoare, int nr_camera, int etaj, float pret, bool bucatarie, bool frigider, bool balcon)
        {
            var query = (from camera in bookingdb.Cameras select camera)?.ToList();
            foreach (var roomList in query)
            {
                if (roomList.NR_CAMERA.Value.Equals(nr_camera))
                {
                    return false;
                }
            }
            bookingdb.Cameras.Add(new Camera()
            {
                NR_DORMITOARE = nr_dormitoare,
                NR_CAMERA = nr_camera,
                ETAJ = etaj,
                PRET = pret,
                BALCON = balcon,
                FRIGIDER = frigider,
                BUCATARIE = bucatarie,
                DELETED = false
            });
            bookingdb.SaveChanges();


            return true;
        }
     

        public bool AddServiciiSuplimentare(int id_camera, string servicii)
        {
            bookingdb.Serviciis.Add(new Servicii()
            {
                CAMERA_ID = id_camera,
                ServiciiString = servicii
            });
            bookingdb.SaveChanges();


            return true;
        }

        //public void DeleteFeature(int id)
        //{
        //    using (SqlConnection con = ((SqlConnection)bookingdb.Database.Connection))
        //    {
        //        SqlCommand cmd = new SqlCommand("DELETEROOM", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter idFeature = new SqlParameter("@id", id);
        //        cmd.Parameters.Add(idFeature);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        bookingdb.SaveChanges();
        //    }


        //}


    }
}

