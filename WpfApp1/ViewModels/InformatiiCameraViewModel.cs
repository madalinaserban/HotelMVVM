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
        public int Numar_Dormitoare
        {
            get
            {
                return AdministratorMenuViewModel.choosedRoom.Tip_Camera;
            }
        }

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
                    if (servicii != null)
                    { result = result + servicii.ToString() + " "; }
                }
                return result;
            }
        }

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
