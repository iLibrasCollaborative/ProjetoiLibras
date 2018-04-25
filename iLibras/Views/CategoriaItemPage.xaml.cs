using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class CategoriaItemPage : ContentPage
    {
        public CategoriaItemPage(Categoria categoria)
        {
            InitializeComponent();

            this.BindingContext = new CategoriaItemViewModel();
            RegistrarMensageria();

            if (categoria.Codigo != 0)
            {
                etyCodigo.Text = categoria.Codigo.ToString();
                etyCategoria.Text = categoria.Descricao;
            }
        }

        private Categoria MontarObjeto(){
            var categoria = new Categoria();
            var cod = 0;

            int.TryParse(etyCodigo.Text, out cod);
            categoria.Codigo = cod;
            categoria.Descricao = etyCategoria.Text;

            return categoria;
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                                "SalvarCategoriaCommand");
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                    "DeletarCategoriaCommand");
        }

        void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<CategoriaItemViewModel>(this.BindingContext,
                                                "SalvarCategoriaCommand", (sender) =>
            {
                App.DatabaseCategoria.SaveItem(MontarObjeto());
                Navigation.RemovePage(this);
            });

            MessagingCenter.Subscribe<CategoriaItemViewModel>(this.BindingContext,
                                                "DeletarCategoriaCommand", (sender) =>
            {
                if(DeletarCategoria()){
                    Navigation.RemovePage(this);    
                } else {
                    DisplayAlert("Não foi possível detelar a categoria", "Existe(m) tag(s) relacionada(s) a esta categoria.", "Ok");
                }
            });
        }

        private bool DeletarCategoria(){
            var categoria = MontarObjeto();

            if(App.DatabaseTag.IsUsingCategoria(categoria.Codigo))
                return false;
            
            return App.DatabaseCategoria.DeleteItem(categoria) > -1;
        }
    }
}
