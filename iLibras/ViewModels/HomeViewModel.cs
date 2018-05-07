using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand NovoTermoCommand { get; private set; }

        public HomeViewModel() 
        { 
            NovoTermoCommand = new Command(() => NovoTermo());
        }

        private void NovoTermo()
        {
            MessagingCenter.Send(this, "NovoTermoCommand");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
