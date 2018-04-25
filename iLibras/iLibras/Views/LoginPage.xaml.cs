using System;
using System.Collections.Generic;
using iLibras.ViewModels;
using iLibras;

using Xamarin.Forms;
using iLibras.Models;

namespace iLibras
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            //listView.ItemsSource = App.DatabaseCategoria.GetItemsAsync();
            RegistrarMensageria();
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                               "AddCategoriaCommand");
            MessagingCenter.Unsubscribe<CategoriaItemViewModel>(this.BindingContext,
                                                              "ModificarCategoriaCommand");
        }

        void RegistrarMensageria()
        {
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

        async System.Threading.Tasks.Task onLoginClickedAsync(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(etyLogin.Text) || string.IsNullOrWhiteSpace(etySenha.Text))
                return;

            var usuario = await App.DatabaseUsuario.GetItemAsync(etyLogin.Text, etySenha.Text);

            if(usuario == null || usuario.Codigo <= 0)
                await DisplayAlert("Falha no login", "Email e/ou senha incorretos", "OK");
            else {
                
            }
        }

        async System.Threading.Tasks.Task onCadastrarClikedAsync(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioItemPage
            {
                BindingContext = new Usuario()
            });
        }
    }
}
