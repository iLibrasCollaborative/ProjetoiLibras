using System;
using System.Collections.Generic;
using System.Threading;
using iLibras.Models;
using Xamarin.Forms;

namespace iLibras
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();

            SincronizarDatabases();
            var autoEvent = new AutoResetEvent(false);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 4000), AlterarTela);
        }

        private bool AlterarTela(){
            Navigation.PushModalAsync(new MainPage());
            return false;
        }

        private void SincronizarDatabases()
        {
            CargasIniciais();
        }

        private void CargasIniciais()
        {
            App.DatabaseEstado.GetItems();

            CargaPerfil();

            CargaUsuarioAdmin();

        }

        private void CargaUsuarioAdmin()
        {
            var usuario = App.DatabaseUsuario.GetItem("ilibrascollaborative@gmail.com");

            if (usuario == null)
            {
                App.DatabaseUsuario.SaveItem(new Usuario
                {
                    Email = "ilibrascollaborative@gmail.com",
                    Nome = "iLibras Collaborative",
                    DataNascimento = new DateTime(2016, 7, 19),
                    Estado = App.DatabaseEstado.GetItem("Santa Catarina").Codigo,
                    Perfil = App.DatabasePerfil.GetItem("Admin").Codigo,
                    Senha = "Si261483"
                });
            }
        }

        private void CargaPerfil()
        {
            if (App.DatabasePerfil.GetItems().Count < 1)
            {
                App.DatabasePerfil.SaveItem(new Perfil { Descricao = "Admin" });
                App.DatabasePerfil.SaveItem(new Perfil { Descricao = "Coordenador" });
                App.DatabasePerfil.SaveItem(new Perfil { Descricao = "Cooperador" });
                App.DatabasePerfil.SaveItem(new Perfil { Descricao = "Comunicador" });
            }
        }
    }
}
