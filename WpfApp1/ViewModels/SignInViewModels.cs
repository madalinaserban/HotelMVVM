using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Services;
using WpfApp1.View;
using WpfApp1.Models;
using WpfApp1.Models.LogicModel;

namespace WpfApp1.ViewModels
{
    class SignInViewModels : BaseViewModel
    {
      Bookingdb bookingdb= new Bookingdb();
        UserModel user = new UserModel();
        public static User activeUser = new User();

        public SignInViewModels()
            { 
            }


        #region BackCommand
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
            #endregion

            #region Properties
            private string email;
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }

            #endregion

            #region SignInCommand
            private ICommand signInCommand;
            public ICommand SignInCommand
            {
                get
                {
                    if (signInCommand == null)
                    {
                        signInCommand = new RelayCommand(SignInMethod);
                    }
                    return signInCommand;
                }
            }

            private void SignInMethod(object param)
            {
            bool administrator = false;
                string password = (param as PasswordBox).Password;
            if (Email == "Administrator" && password=="123")
            {
                MessageBox.Show("V-ati logat ca administrator!");
                administrator = true;
            }
            if (Email == null || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Toate campurile sunt obligatorii!");
            }
            else
            {
                if (administrator == false)
                {
                    if (!user.SignIn(Email, password))
                    {
                        MessageBox.Show("Email sau parola gresite!");
                        Email = "";
                        (param as PasswordBox).Password = "";
                    }
                    else
                    {
                        var query = (from user in bookingdb.Users
                                     where user.Email.Equals(Email)
                                     select user).First();
                        activeUser = query;
                        StartWindowViewModels.stateUser = true;
                        WithAccount withAccountView = new WithAccount();
                        App.Current.MainWindow.Close();
                        App.Current.MainWindow = withAccountView;
                        withAccountView.Show();
                    }
                }
                if(administrator==true)
                {
                    var query = (from user in bookingdb.Users
                                 where user.Email.Equals(Email)
                                 select user).First();
                    activeUser = query;
                    StartWindowViewModels.stateUser = true;
                    AdministratorMenuView administratorMenuView = new AdministratorMenuView();
                    App.Current.MainWindow.Close();
                    App.Current.MainWindow = administratorMenuView;
                    administratorMenuView.Show();
                }
            }
            }
            #endregion
        }
    }


