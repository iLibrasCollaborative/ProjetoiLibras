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
        public ICommand NovaContaCommand { get; private set; }
        public ICommand RecuperarSenhaCommand { get; private set; }
        public ICommand EnviarSenhaComamnd { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new Command(() => Login());
            NovaContaCommand = new Command(() => CriarConta());
            RecuperarSenhaCommand = new Command(() => EsqueciSenha());

        }

        private void CriarConta()
        {
            MessagingCenter.Send(this, "NovaContaCommand");
        }

        private void Login()
        {
            MessagingCenter.Send(this, "LoginCommand");
        }

        private void EsqueciSenha(){
            MessagingCenter.Send(this, "RecuperarSenhaCommand");
        }

        private void EnviarSenha(){
            MessagingCenter.Send(this, "EnviarSenhaCommand");
        }
    }
}
