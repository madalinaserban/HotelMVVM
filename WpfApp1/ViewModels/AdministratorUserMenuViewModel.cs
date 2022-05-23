using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class AdministratorUserMenuViewModel:BaseViewModel
    {
        Bookingdb booking = new Bookingdb();
        private ObservableCollection<UserMenu> user;
        private UserModel userModel= new UserModel();
        public static ObservableCollection<UserMenu> productsAddedToCart = new ObservableCollection<UserMenu>();

        public ObservableCollection<UserMenu> UserCollection
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("UserCollection");
            }
        }

        public AdministratorUserMenuViewModel()
        {
            UserCollection = new ObservableCollection<UserMenu>(userModel.GetUsersMenu());

        }
        private ICommand stergeUserCommand;
        public ICommand StergeUserCommand
        {
            get
            {
                if (stergeUserCommand == null)
                {
                    stergeUserCommand = new RelayCommand(StergeUser);
                }
                return stergeUserCommand;
            }
        }
        private void StergeUser(object param)
        {
            int a=-1;
            var id = booking.GetUserIdByMail(selectedUser.Email);
            foreach (var cam in id)
            {
                a = (int)cam;
            }
            LogicCamera camera1 = new LogicCamera();
            booking.DELETEUSER(a);
            MessageBox.Show("Ai sters un user!");
            AdministratorMenuView Window = new AdministratorMenuView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = Window;
            Window.Show();
        }

        public static UserMenu choosedUser;
        private UserMenu selectedUser;
        public UserMenu SelectedUser
        {
            get
            {
                return selectedUser; ;
            }
            set
            {
                selectedUser= value;
                if (selectedUser != null)
                {
                    CanExecuteDeleteCommand = true;
                    choosedUser = selectedUser;
                }
                OnPropertyChanged("SelectedUser");
            }
        }

        public bool CanExecuteDeleteCommand { get; set; }
        
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
            StartWindow startWindow = new StartWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            startWindow.Show();
        }
        private ICommand roomsCommand;
        public ICommand RoomsCommand
        {
            get
            {
                if (roomsCommand == null)
                {
                    roomsCommand = new RelayCommand(RoomsMethod);
                }
                return roomsCommand;
            }
        }
        private void RoomsMethod(object param)
        {
            AdministratorMenuView startWindow = new AdministratorMenuView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            startWindow.Show();
        }
    }
}

