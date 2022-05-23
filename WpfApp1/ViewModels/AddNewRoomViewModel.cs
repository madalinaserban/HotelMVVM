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
    class AddNewRoomViewModel : BaseViewModel
    {
        Bookingdb booking = new Bookingdb();
        public static Camera currentRoom = new Camera();
        private string serviciiSuplimentare = "";
        public string ServiciiSuplimentare
        {
            get
            {
                return serviciiSuplimentare;
            }
            set
            {
                serviciiSuplimentare = value;
                OnPropertyChanged("ServiciiSuplimentare");
            }
        }
        private int etaj;
        public int EtajProperty
        {
            get
            {
                return etaj;
            }
            set
            {
                etaj = value;
                OnPropertyChanged("EtajProperty");
            }
        }
        private int nr_Camera;
        public int Nr_CameraProperty
        {
            get
            {
                return nr_Camera;
            }
            set
            {
                nr_Camera = value;
                OnPropertyChanged("Nr_CameraProperty");
            }
        }
        private int nr_Dormitoare;
        public int Nr_DormitoareProperty
        {
            get
            {
                return nr_Dormitoare;
            }
            set
            {
                nr_Dormitoare = value;
                OnPropertyChanged("Nr_DormitoareProperty");
            }
        }
        private bool bucatarie = false;
        public bool BucatarieChecked
        {
            get
            {
                return bucatarie;
            }
            set
            {
                bucatarie = value;
                OnPropertyChanged("BucatarieChecked");
            }
        }
        private bool frigider = false;
        public bool FrigiderChecked
        {
            get
            {
                return frigider;
            }
            set
            {
                frigider = value;
                OnPropertyChanged("FrigiderChecked");
            }
        }
        private bool balcon = false;
        public bool BalconChecked
        {
            get
            {
                return balcon;
            }
            set
            {
                balcon = value;
                OnPropertyChanged("BalconChecked");
            }
        }
        private float pret;
        public float PretProperty
        {
            get
            {
                return pret;
            }
            set
            {
                pret = (float)value;
                OnPropertyChanged("PretProperty");
            }
        }


        private ICommand addRoomCommand;
        public ICommand AddRoomCommand
        {
            get
            {
                if (addRoomCommand == null)
                {
                    addRoomCommand = new RelayCommand(AddRoomMethod);
                }
                return addRoomCommand;
            }
        }
        private void AddRoomMethod(object param)
        {
            bool adaugat = true;
            LogicCamera camera1 = new LogicCamera();
            if (!camera1.AddRoom(Nr_DormitoareProperty, Nr_CameraProperty, EtajProperty, PretProperty, BucatarieChecked, FrigiderChecked, BalconChecked))
            {
                MessageBox.Show("Numarul camerei trebuie sa fie unic, poti modifica camera");
                adaugat = false;
            }
            if (adaugat == true)
            {
                var query = (from camera in booking.Cameras
                             where camera.NR_CAMERA.Value.Equals(Nr_CameraProperty)
                             select camera).First();
                currentRoom = query;
                camera1.AddServiciiSuplimentare(currentRoom.CAMERA_ID, ServiciiSuplimentare);
                MessageBox.Show("Ai adaugat o camera!");
            }
        }
        private ICommand updateRoomCommand;
        public ICommand UpdateRoomCommand
        {
            get
            {
                if (updateRoomCommand == null)
                {
                    updateRoomCommand = new RelayCommand(UpdateRoomMethod);
                }
                return updateRoomCommand;
            }
        }
        private void UpdateRoomMethod(object param)
        {
            bool gasit = false;
            var query = (from camera in booking.Cameras select camera)?.ToList();
            foreach (var roomList in query)
            {
                if (roomList.NR_CAMERA.Value.Equals(nr_Camera))
                {
                    gasit = true;
                }
            }
            if (gasit == true)
            {
                int a = 0;
                var id = booking.GETID_CAMERA(nr_Camera);
                foreach (var cam in id)
                {
                    a = (int)cam;
                }
                booking.UPDATEROOM(a, balcon, etaj, nr_Dormitoare, pret, bucatarie, frigider);
                var query1 = (from camera in booking.Cameras
                             where camera.NR_CAMERA.Value.Equals(Nr_CameraProperty)
                             select camera).First();
                currentRoom = query1;
                booking.UPDATESERVICII(currentRoom.CAMERA_ID, ServiciiSuplimentare);
                MessageBox.Show("Ai modificat camera!");
            }
             else
            {
                MessageBox.Show("Nu exista nicio camera cu acest numar");

            }



                booking.SaveChanges();

            
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
            AdministratorMenuView Window = new AdministratorMenuView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = Window;
            Window.Show();
        }

    }

}
