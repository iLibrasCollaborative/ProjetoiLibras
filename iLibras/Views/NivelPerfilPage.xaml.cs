using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class NivelPerfilPage : ContentPage
    {
        List<Usuario> Usuarios;

        public NivelPerfilPage()
        {
            InitializeComponent();
            this.BindingContext = new NivelPerfilViewModel();
            CarregarPerfis();
        }

        private void CarregarPerfis()
        {
            Usuarios = App.DatabaseUsuario.GetItemsForPerfil();
            listView.ItemsSource = Usuarios;
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();
            CarregarPerfis();
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<NivelPerfilViewModel>(this.BindingContext,
                    "ModificarPerfilCommand", async (sender) =>
                    {
                        var bind = (NivelPerfilViewModel)this.BindingContext;
                        await Navigation.PushAsync(new NivelPerfilItemPage(bind.usuario));
                    });
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<NivelPerfilViewModel>(this.BindingContext,
                                                              "ModificarPerfilCommand");
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sbPerfil.Text))
                listView.ItemsSource = Usuarios;
        }
    }
}
