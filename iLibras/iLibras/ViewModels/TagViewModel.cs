using System;
using iLibras.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class TagViewModel : INotifyPropertyChanged
    {
        private Tag _selectedItem;

        public ICommand SalvarTagCommand { get; private set; }
        public ICommand DeletarTagCommand { get; private set; }
        public ICommand AddTagCommand { get; private set; }
        public ICommand ModificarTagCommand { get; private set; }

        public Tag tag { get { return _selectedItem; } }

        public Tag SelectedItem
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

                ModificarTagCommand.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TagViewModel()
        {
            AddTagCommand = new Command(() => AdicionarNovaTag());
            ModificarTagCommand = new Command(() => ModificarTag());
            DeletarTagCommand = new Command(() => DeletarTag());
            SalvarTagCommand = new Command(() => SalvarTag());
        }

        void AdicionarNovaTag()
        {
            MessagingCenter.Send(this, "AddTagCommand");
        }

        void ModificarTag()
        {
            MessagingCenter.Send(this, "ModificarTagCommand");
        }

        void DeletarTag()
        {
            MessagingCenter.Send(this, "DeletarTagCommand");
        }

        void SalvarTag()
        {
            MessagingCenter.Send(this, "SalvarTagCommand");
        }    
    }
}
