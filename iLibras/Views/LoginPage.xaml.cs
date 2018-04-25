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

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            etySenha.IsPassword = !etySenha.IsPassword;
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<LoginViewModel>(this.BindingContext,
                                                                "LoginCommand");
            MessagingCenter.Unsubscribe<LoginViewModel>(this.BindingContext,
                                                                "NovaContaCommand");
            MessagingCenter.Unsubscribe<LoginViewModel>(this.BindingContext,
                                                        "RecuperarSenhaCommand");
        }

        void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<LoginViewModel>(this.BindingContext,
                                                    "LoginCommand", (sender) =>
                                                    {
                                                        if(Logar())
                                                            Navigation.PushModalAsync(new MainPage());
                                                    });

            MessagingCenter.Subscribe<LoginViewModel>(this.BindingContext,
                                                    "NovaContaCommand", async (sender) =>
                                                    {
                                                        await Navigation.PushAsync(new UsuarioItemPage());
                                                    });

            MessagingCenter.Subscribe<LoginViewModel>(this.BindingContext,
                                                      "RecuperarSenhaCommand", async (sender) =>
                                                    {
                                                        await Navigation.PushAsync(new ForgetPassPage());
                                                    });
        }

        private bool Logar()
        {
            if (string.IsNullOrWhiteSpace(etyLogin.Text) || string.IsNullOrWhiteSpace(etySenha.Text))
                return false;

            var usuario = App.DatabaseUsuario.GetLogin(etyLogin.Text, etySenha.Text);

            if(usuario == null || usuario.Codigo <= 0){
                DisplayAlert("Falha no login", "Email e/ou senha incorretos", "OK");
                return false;
            } else {
                if (swtLembrar.IsToggled){
                    var sessao = App.DatabaseSessao.GetItem();

                    App.DatabaseSessao.SaveItem(new Sessao
                    {
                        CodigoUsuario = usuario.Codigo,
                        CodigoRegionalidade = sessao.CodigoRegionalidade
                    });

                    App.User = usuario;
                } else {
                    var sessao = App.DatabaseSessao.GetItem();

                    App.DatabaseSessao.SaveItem(new Sessao
                    {
                        CodigoUsuario = 999999,
                        CodigoRegionalidade = sessao.CodigoRegionalidade
                    });

                    App.User = usuario;
                }

                return true;
            }
        }
    }
}
