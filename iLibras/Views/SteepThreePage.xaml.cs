using System;
using System.Collections.Generic;
using System.IO;
using iLibras.Models;
using Plugin.Media;
using Xamarin.Forms;

namespace iLibras
{
    public partial class SteepThreePage : ContentPage
    {
        Sinal _sinal;
        Contexto _contexto;
        string _base64;

        public SteepThreePage(Sinal sinal, Contexto contexto)
        {
            InitializeComponent();

            _sinal = sinal;
            _contexto = contexto;

            imgIR.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnChooseImagem())
            });
        }

        async void OnChooseImagem()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null) return;

            _base64 = Convert.ToBase64String(File.ReadAllBytes(file.Path));

            imgIR.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            if(_base64 == null)
            {
                DisplayAlert("Selecione uma imagem", "Por favor, selecione uma imagem para Imagem Representativa", "OK");
                return;
            }

            var imagemRepresentativa = new ImagemRepresentativa
            {
                Imagem = _base64
            };

            Navigation.PushAsync(new StepFourPage(_sinal, _contexto, imagemRepresentativa));
        }
    }
}
