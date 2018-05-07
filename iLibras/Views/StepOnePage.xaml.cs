using System;
using System.Collections.Generic;
using System.IO;
using iLibras.Models;
using Plugin.Media;
using Xamarin.Forms;

namespace iLibras
{
    public partial class StepOnePage : ContentPage
    {
        string _base64;
        Sinal _sinal;

        public StepOnePage()
        {
            InitializeComponent();

            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();
            imgSinal.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnChooseImagem())
            });
        }

        public StepOnePage(Sinal sinal){
            InitializeComponent();
            _sinal = sinal;

            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();
            byte[] data = System.Convert.FromBase64String(sinal.Gif);

            using (MemoryStream ms = new MemoryStream(data))
            {
                imgSinal.Source = ImageSource.FromStream(() => { return ms; });
            }

            imgSinal.GestureRecognizers.Add(new TapGestureRecognizer
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

            imgSinal.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_base64) && _sinal == null){
                DisplayAlert("Imagem não selecionada", "Favor selecionar uma imagem para o sinal", "OK");
                return;  
            }

            var sinal = new Sinal
            {
                Codigo = _sinal == null ? 0 : _sinal.Codigo,
                CodigoEstado = 1,
                CodigoUsuario = 1,
                Gif = _base64 == null ? _sinal.Gif : _base64
            };

            Navigation.PushAsync(new StepTwoPage(sinal));
        }
    }
}
