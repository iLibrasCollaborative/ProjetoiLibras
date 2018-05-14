using System;
using System.Collections.Generic;
using iLibras.Models;
using Xamarin.Forms;

namespace iLibras
{
    public partial class StepTwoPage : ContentPage
    {
        Sinal _sinal;

        public StepTwoPage(Sinal sinal)
        {
            InitializeComponent();
            _sinal = sinal;

            pckTag.ItemsSource = App.DatabaseTag.GetItemsAtDescricao();
        }

        public bool CamposObrigatorios(){
            if (string.IsNullOrWhiteSpace(edtContexto.Text))
                return false;

            if (string.IsNullOrWhiteSpace(etyDescricao.Text))
                return false;

            return true;
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            if(!CamposObrigatorios())
            {
                DisplayAlert("Campos obrigatórios", "Por favor, preencha os campos obrigatórios", "OK");
                return;
            }

            var contexto = new Contexto
            {
                Descricao = etyDescricao.Text,
                ContextoTexto = edtContexto.Text,
                CodigoTag = pckTag.SelectedItem != null ? 
                                  App.DatabaseTag.GetItemAsync(pckTag.SelectedItem.ToString()).Codigo : 0 
            };

            Navigation.PushAsync(new SteepThreePage(_sinal, contexto));
        }
    }
}
