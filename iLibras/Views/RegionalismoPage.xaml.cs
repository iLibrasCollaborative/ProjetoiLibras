using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class RegionalismoPage : ContentPage
    {
        public RegionalismoPage()
        {
            InitializeComponent();
            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();
            pckEstado.SelectedItem = App.DatabaseEstado.GetItem(App.DatabaseSessao.GetItem().CodigoRegionalidade).Extenso;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var sessao = new Sessao
            {
                CodigoUsuario = (App.User == null) ? -1 : App.User.Codigo,
                CodigoRegionalidade = App.DatabaseEstado.GetItem(pckEstado.SelectedItem.ToString()).Codigo
            };

            var retorno = App.DatabaseSessao.SaveItem(sessao);

            if(retorno != 0)
                DisplayAlert("", "Regionalismo salvo com sucesso!", "Ok");
        }
    }
}
