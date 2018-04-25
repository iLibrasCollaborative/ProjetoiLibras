using System;
using System.Collections.Generic;
using iLibras.Models;

using Xamarin.Forms;

namespace iLibras
{
    public partial class UsuarioItemPage : ContentPage
    {
        public UsuarioItemPage()
        {
            InitializeComponent();
        }

        async System.Threading.Tasks.Task onSalvarClickedAsync(object sender, System.EventArgs e)
        {
            var usuario = (Usuario)BindingContext;
            await App.DatabaseUsuario.SaveItemAsync(usuario);
            await Navigation.PopAsync();
        }

        async System.Threading.Tasks.Task onCancelarClickedAsync(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
