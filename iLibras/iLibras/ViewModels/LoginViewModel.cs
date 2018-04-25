using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using iLibras.Models;

namespace iLibras.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; private set; }
        public ICommand CriarContaCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new Command(() => Login());
            CriarContaCommand = new Command(() => CriarConta());
        }

        private void CriarConta()
        {
            MessagingCenter.Send(this, "CriarConta");
        }

        private void Login()
        {
            MessagingCenter.Send(this, "LoginSucess");
        }
    }
}
