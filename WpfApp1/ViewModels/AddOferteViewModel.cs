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
    class AddOferteViewModel: BaseViewModel
        {
            Bookingdb booking = new Bookingdb();
            public static OFERTE oferta_curenta = new OFERTE();
            private string data1;
            public string Data1Property
            {
                get
                {
                    return data1;
                }
                set
                {
                    data1 = value;
                    OnPropertyChanged("Data1Property");
                }
            }
            private string data2;
            public string Data2Property
            {
                get
                {
                    return data2;
                }
                set
                {
                    data2 = value;
                    OnPropertyChanged("Data2Property");
                }
            }
            private int reducere;
            public int ReducereProperty
            {
                get
                {
                    return reducere;
                }
                set
                {
                    reducere = value;
                    OnPropertyChanged("ReducereProperty");
                }
            }
            private string nume;
            public string NumeProperty
            {
                get
                {
                    return nume;
                }
                set
                {
                    nume = value;
                    OnPropertyChanged("NumeProperty");
                }
            }

            private ICommand addOfertaCommand;
            public ICommand AddOfertaCommand
            {
                get
                {
                    if (addOfertaCommand == null)
                    {
                        addOfertaCommand = new RelayCommand(AddOfertaMethod);
                    }
                    return addOfertaCommand;
                }
            }
            private void AddOfertaMethod(object param)
            {
                {
                    booking.OFERTEs.Add(new OFERTE()
                    {
                        DATA_INCEPERE = data1,
                        DATA_FINAL=data2,
                        REDUCERE=reducere,
                        NUME_OFERTA=nume
                    }) ;
                    booking.SaveChanges();
                    MessageBox.Show("Ai adaugat o oferta!");
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
                AdministratorMenuView Window = new AdministratorMenuView();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = Window;
                Window.Show();
            }

        }
    }

