using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();
            this.BindingContext = new CategoriaItemViewModel();
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            listView.ItemsSource = App.DatabaseCategoria.GetItems();
            RegistrarMensageria();
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                               "AddCategoriaCommand");
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                              "ModificarCategoriaCommand");
        }

        void RegistrarMensageria(){
            MessagingCenter.Subscribe<CategoriaItemViewModel>(this.BindingContext, 
                                                              "AddCategoriaCommand", async (sender) =>
            {
                await Navigation.PushAsync(new CategoriaItemPage(new Categoria()));
            });

            MessagingCenter.Subscribe<CategoriaItemViewModel>(this.BindingContext, 
                                                              "ModificarCategoriaCommand", async (sender) =>
            {
                var bind = (CategoriaItemViewModel)this.BindingContext;
                await Navigation.PushAsync(new CategoriaItemPage(bind.categoria));
            });
        }
    }
}
