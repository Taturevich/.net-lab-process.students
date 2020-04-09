using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace WpfShowCase
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _userPhone;

        public MainWindowViewModel()
        {
            Console.WriteLine("POPAL");
        }

        public string UserPhone
        {
            get { return _userPhone; }
            set
            { 
                Set(ref _userPhone, value);
                RaisePropertyChanged(nameof(CanClick));
            }
        }

        public bool IsUserPhoneAvailable => false;

        public bool CanClick => UserPhone != "FAIL";

        public ICommand ClickCommand => new RelayCommand(() => MessageBox.Show("Saved"), () => CanClick);
    }
}
