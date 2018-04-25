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

    }
}
