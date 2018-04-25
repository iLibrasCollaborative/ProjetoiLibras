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
                btnDeletar.IsVisible = true;
                etyCodigo.IsVisible = true;
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
                App.DatabaseCategoria.SaveItemAsync(MontarObjeto());
                Navigation.RemovePage(this);
            });

            MessagingCenter.Subscribe<CategoriaItemViewModel>(this.BindingContext,
                                                "DeletarCategoriaCommand", (sender) =>
            {
                App.DatabaseCategoria.DeleteItemAsync(MontarObjeto());
                Navigation.RemovePage(this);
            });
        }

        //void onSalvarClickedAsync(object sender, System.EventArgs e)
        //{
        //    App.DatabaseCategoria.SaveItemAsync(MontarObjeto());
        //    //await Navigation.PopAsync();
        //}


        //void onDeletarClickedAsync(object sender, System.EventArgs e)
        //{
        //    var categoria = (Categoria)BindingContext;
        //    App.DatabaseCategoria.DeleteItemAsync(categoria);
        //    //await Navigation.PopAsync();
        //}


        //void onCancelarClickedAsync(object sender, System.EventArgs e)
        //{
        //    //await Navigation.PopAsync();
        //}
    }
}
