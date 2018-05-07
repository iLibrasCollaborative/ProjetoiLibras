using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class ForgetPassPage : ContentPage
    {
        public ForgetPassPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginViewModel();
        }

        void SendEmail_Clicked(object sender, System.EventArgs e)
        {
            var newPassword = PasswordOptions.GenerateRandomPassword();

            var email = new Email 
            {
                Body = "Sua nova senha é " + newPassword + "", 
                To = etyEmail.Text,
                Subject = "Esqueci minha senha"
            };

            var user = App.DatabaseUsuario.GetItem(etyEmail.Text);

            if (user == null)
            {
                DisplayAlert("Alteração de senha", "Não existe registro com esse email.", "OK");
                return;
            }

            user.Senha = newPassword;

            if (Email.SendEmail(email))
            {
                App.DatabaseUsuario.SaveItem(user);
                DisplayAlert("Alteração de senha", "Senha alterada com sucesso!", "OK");
            } else
                DisplayAlert("Alteração de senha", "Não foi possível alterar a senha.", "OK");
                 
        }
    }
}
