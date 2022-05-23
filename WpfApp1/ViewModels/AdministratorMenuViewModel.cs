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
    class AdministratorMenuViewModel : BaseViewModel
    {
        private ObservableCollection<RoomsMenu> rooms;
        private LogicCamera logicCamera = new LogicCamera();
        public static ObservableCollection<RoomsMenu> productsAddedToCart = new ObservableCollection<RoomsMenu>();

        public ObservableCollection<RoomsMenu> RoomsCollection
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
                OnPropertyChanged("RoomsCollection");
            }
        }

        public AdministratorMenuViewModel()
        {
            RoomsCollection = new ObservableCollection<RoomsMenu>(logicCamera.GetProductsMenus());

        }

        public static RoomsMenu choosedRoom;
        private RoomsMenu selectedRoom;
        public RoomsMenu SelectedRoom
        {
            get
            {
                return selectedRoom;
            }
            set
            {
                selectedRoom = value;
                if (selectedRoom != null)
                {
                    CanExecuteDetailsCommand = true;
                    choosedRoom = selectedRoom;
                }
                OnPropertyChanged("SelectedProduct");
            }
        }

        public bool CanExecuteDetailsCommand { get; set; }
        private ICommand addRoomsCommand;
        public ICommand AddRoomsCommand
        {
            get
            {
                if (addRoomsCommand == null)
                {
                    addRoomsCommand = new RelayCommand(AddRoomsMethod);
                }
                return addRoomsCommand;
            }
        }

        private ICommand detailsCommand;
        public ICommand DetailiiCameraCommand
        {
            get
            {
                if (detailsCommand == null)
                {
                    detailsCommand = new RelayCommand(DetailsMethod, param => CanExecuteDetailsCommand);
                }
                return detailsCommand;
            }
        }

        private void DetailsMethod(object param)
        {
            InformatiiCameraView productDetailsView = new InformatiiCameraView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = productDetailsView;
            productDetailsView.Show();
        }
        private void AddRoomsMethod(object param)
        {
            AdaugaNouTipDeCamera nouTipDeCamera = new AdaugaNouTipDeCamera();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = nouTipDeCamera;
            nouTipDeCamera.Show();
        }
        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(SearchMethod);
                }
                return searchCommand;
            }
        }
        private void SearchMethod(object param)
        {
            SearchView searchView = new SearchView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = searchView;
            searchView.Show();
        }
        private ICommand clientiCommand;
        public ICommand ClientiCommand
        {
            get
            {
                if (clientiCommand == null)
                {
                    clientiCommand = new RelayCommand(ClientiMethod);
                }
                return clientiCommand;
            }
        }
        private void ClientiMethod(object param)
        {
            AdministratorUserView startWindow = new AdministratorUserView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            startWindow.Show();
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
            StartWindow startWindow = new StartWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            startWindow.Show();
        }
    }
}
