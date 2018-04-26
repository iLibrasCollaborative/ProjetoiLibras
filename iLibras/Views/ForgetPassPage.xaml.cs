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
        }
    }
}
