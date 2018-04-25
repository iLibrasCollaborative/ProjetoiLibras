using System;
using System.ComponentModel;
using System.Windows.Input;
using iLibras.Models;
using Xamarin.Forms;

namespace iLibras.ViewModels
{
    public class CategoriaItemViewModel : INotifyPropertyChanged
    {
        private Categoria _selectedItem;

        public ICommand SalvarCategoriaCommand { get; private set; }
        public ICommand DeletarCategoriaCommand { get; private set; }
        public ICommand AddCategoriaCommand { get; private set; }
        public ICommand ModificarCategoriaCommand { get; private set; }

        public Categoria categoria { get { return _selectedItem; } }

        public Categoria SelectedItem
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

                ModificarCategoriaCommand.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoriaItemViewModel()
        {
            AddCategoriaCommand = new Command(() => AdicionarNovaCategoria());
            ModificarCategoriaCommand = new Command(() => ModificarCategoria());
            DeletarCategoriaCommand = new Command(() => DeletarCategoria());
            SalvarCategoriaCommand = new Command(() => SalvarCategoria());
        }

        void AdicionarNovaCategoria()
        {
            MessagingCenter.Send(this, "AddCategoriaCommand");
        }

        void ModificarCategoria()
        {
            MessagingCenter.Send(this, "ModificarCategoriaCommand");
        }

        void DeletarCategoria()
        {
            MessagingCenter.Send(this, "DeletarCategoriaCommand");
        }

        void SalvarCategoria()
        {
            MessagingCenter.Send(this, "SalvarCategoriaCommand");
        }
    }
}
