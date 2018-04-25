using System;
using System.ComponentModel;
using System.Windows.Input;
using iLibras.Models;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class NivelPerfilViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ModificarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }

        private Usuario _selectedItem;

        public Usuario usuario { get { return _selectedItem; } }

        public Usuario SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                ModificarPerfilCommand.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        public NivelPerfilViewModel()
        {
            ModificarPerfilCommand = new Command(() => ModificarPerfil());
            SalvarPerfilCommand = new Command(() => SalvarPerfil());
        }

        void ModificarPerfil()
        {
            MessagingCenter.Send(this, "ModificarPerfilCommand");
        }

        void SalvarPerfil()
        {
            MessagingCenter.Send(this, "SalvarPerfilCommand");
        }
    }
}
