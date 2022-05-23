using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Models.LogicModel;
using WpfApp1.Services;
using WpfApp1.View;

namespace WpfApp1.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {

        Bookingdb booking = new Bookingdb();
        private string firstName;
        public string FirstNameProperty
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstNameProperty");
            }
        }
        private string lastname;
        public string LastNameProperty
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged("LastNameProperty");
            }
        }
        private string address;
        public string AddressProperty
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("AddressProperty");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string email;
        public string EmailProperty
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("EmailProperty");
            }
        }

        private ICommand signUpCommand;
        public ICommand SignUpCommand
        {
            get
            {
                if (signUpCommand == null)
                {
                    signUpCommand = new RelayCommand(SignUpMethod);
                }
                return signUpCommand;
            }
        }
        private void SignUpMethod(object param)
        {
            string password = (param as PasswordBox).Password;
            UserModel user = new UserModel();
            if (!user.SignUp(FirstNameProperty, LastNameProperty, PhoneNumber, EmailProperty, AddressProperty, password))
            {
                MessageBox.Show("This email is taken!");
                EmailProperty = "";
            }
            else
            {
                var query = (from users in booking.Users
                             where users.Email.Equals(EmailProperty)
                             select users).First();
                SignInViewModels.activeUser = query;
                WithAccount withAccountView = new WithAccount();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = withAccountView;
                withAccountView.Show();
            }
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

