using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class NivelPerfilItemPage : ContentPage
    {

        private Usuario _usuario;
		public NivelPerfilItemPage(Usuario usuario)
		{
            InitializeComponent();
            _usuario = usuario;
            this.BindingContext = new NivelPerfilViewModel();

            CarregarComponentes();

            etyNome.Text = usuario.Nome;
            etyEmail.Text = usuario.Email;
            pckData.Date = usuario.DataNascimento;
            pckEstado.SelectedItem = App.DatabaseEstado.GetItem(usuario.Estado).Extenso;
            pckPerfil.SelectedItem = App.DatabasePerfil.GetItem(usuario.Perfil).Descricao;
		}

        private void CarregarComponentes(){
            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();
            pckPerfil.ItemsSource = App.DatabasePerfil.GetItemsString();
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<NivelPerfilViewModel>(this.BindingContext,
                                                            "SalvarPerfilCommand", (sender) =>
            {
                var codigoPerfil = App.DatabasePerfil.GetItem(pckPerfil.SelectedItem.ToString()).Codigo;
                _usuario.Perfil = codigoPerfil;

                App.DatabaseUsuario.SaveItem(_usuario);

                Navigation.RemovePage(this);
            });
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<NivelPerfilViewModel>(this.BindingContext,
                                                              "SalvarPerfilCommand");
        }
	}
}
