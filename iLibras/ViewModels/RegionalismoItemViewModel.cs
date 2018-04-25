using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class RegionalismoItemViewModel : INotifyPropertyChanged
    {
        public ICommand SalvarRegionalismoCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public RegionalismoItemViewModel() 
        {
            SalvarRegionalismoCommand = new Command(() => Salvar());
        }

        private void Salvar()
        {
            MessagingCenter.Send(this, "SalvarRegionalismoCommand");
        }
    }
}
