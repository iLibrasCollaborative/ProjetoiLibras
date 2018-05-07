using System;
using System.Collections.Generic;
using System.IO;
using iLibras.Models;
using Plugin.Media;
using Xamarin.Forms;

namespace iLibras
{
    public partial class StepFourPage : ContentPage
    {
        string _base64;
        Sinal _sinal;
        Contexto _contexto;
        ImagemRepresentativa _imgRepresentativa;

        public StepFourPage(Sinal sinal, Contexto contexto, ImagemRepresentativa imgRepresentativa)
        {
            InitializeComponent();

            _sinal = sinal;
            _contexto = contexto;
            _imgRepresentativa = imgRepresentativa;

            imgEscritaSinais.GestureRecognizers.Add(new TapGestureRecognizer
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

            imgEscritaSinais.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        void Finish_Clicked(object sender, System.EventArgs e)
        {
            //Registrar todos os objetos
            DisplayAlert("", "Registro concluído com sucesso", "OK");
            Navigation.PopToRootAsync();
        }
    }
}
