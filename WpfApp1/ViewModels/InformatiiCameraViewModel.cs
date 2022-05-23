using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Models.LogicModel;
using WpfApp1.Services;
using WpfApp1.View;

namespace WpfApp1.ViewModels
{
    class InformatiiCameraViewModel
    {
        Bookingdb booking = new Bookingdb();
        // DisplayProduct selectedProduct = MenuViewModel.choosedProduct;
        public int Numar_Dormitoare
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Tip_Camera;
            }
        }

        //private bool productType = false;
        //public string Category
        //{
        //    get
        //    {
        //        try
        //        {
        //            var productQuery = (from category in restaurant.Categories
        //                                join product in restaurant.Products
        //                                on selectedProduct.Name equals product.Name
        //                                where category.Category_ID.Equals(product.Category_ID)
        //                                select category.Name).First();
        //            productType = true;
        //            return productQuery.ToString();
        //        }
        //        catch
        //        {
        //            var menuQuery = (from category in restaurant.Categories
        //                             join menu in restaurant.Menus
        //                             on selectedProduct.Name equals menu.Name
        //                             where category.Category_ID.Equals(menu.Category_ID)
        //                             select category.Name).First();
        //            return menuQuery.ToString();
        //        }
        //    }
        //}

        public string Pret
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Price.ToString() + " RON";
            }
        }

        public bool Frigider
        {
            get
            {

                return AdministratorMenuViewModel.choosedRoom.Frigider;

            }


        }
        public bool Balcon
        {
            get
            {

                return AdministratorMenuViewModel.choosedRoom.Balcon;

            }
        }
        public bool Bucatarie
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Bucatarie;
            }
        }
        public int Etaj
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Etaj;
            }
        }
        public int Nr_Camera
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Nr_Camera;
            }
        }
        public string ServiciiText
        {
            get
            {
                int a = 0;
                var id = booking.GETID_CAMERA(AdministratorMenuViewModel.choosedRoom.Nr_Camera);
                foreach (var cam in id)
                {
                    a = (int)cam;
                }
                string result = "";
                var query = booking.GetServicii(a);
                foreach (var servicii in query)
                {
                    result = result + servicii.ToString() + " ";
                }
                return result;
            }
        }
        //public string Dotari
        //{
        //    get
        //    {
        //        string result = "";

        //        var query = booking.GetAllergensFromProduct(selectedProduct.Name);
        //        foreach (var allergen in query)
        //        {
        //            result = result + allergen.ToString() + " ";
        //        }
        //    }

        //        else
        //        {
        //        var query = restaurant.GetAllergensFromMenus(selectedProduct.Name);
        //        foreach (var allergen in query)
        //        {
        //            result = result + allergen.ToString() + " ";
        //        }
        //    }

        //        if (result == "")
        //        {
        //            result = "-";
        //        }

        //        return result;
        //}

        private ICommand stergeCameraCommand;
        public ICommand StergeCameraCommand
        {
            get
            {
                if (stergeCameraCommand == null)
                {
                    stergeCameraCommand = new RelayCommand(StergeCameraMethod);
                }
                return stergeCameraCommand;
            }
        }
        private void StergeCameraMethod(object param)
        {
            int a = 0;
            var id = booking.GETID_CAMERA(AdministratorMenuViewModel.choosedRoom.Nr_Camera);
            foreach (var cam in id)
            {
                a = (int)cam;
            }
            LogicCamera camera1 = new LogicCamera();
            // camera1.DeleteFeature(a);
            booking.DELETEROOM(a);
            MessageBox.Show("Ai sters camera!");
            AdministratorMenuView Window = new AdministratorMenuView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = Window;
            Window.Show();


        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new RelayCommand(BackMethod);
                }
                return backCommand;
            }
        }
        private void BackMethod(object param)
        {

            AdministratorMenuView startWindow = new AdministratorMenuView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            startWindow.Show();

        }
    }
}
