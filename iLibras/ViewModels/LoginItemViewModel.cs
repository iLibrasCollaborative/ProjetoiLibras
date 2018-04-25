using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class LoginItemViewModel : INotifyPropertyChanged
    {
        public ICommand SalvarLoginCommand { get; private set; }

        public LoginItemViewModel()
        {
            SalvarLoginCommand = new Command(() => SalvarLogin());
        }

        private void SalvarLogin()
        {
            MessagingCenter.Send(this, "SalvarLoginCommand");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
