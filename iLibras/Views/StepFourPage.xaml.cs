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
        EscritaSinais _escritaSinais;

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

        Contexto RegistrarContexto(Contexto contexto)
        {
            var id = App.DatabaseContexto.SaveItem(contexto);
            contexto.Codigo = id;

            return contexto;
        }

        Sinal RegistrarSinal(Sinal sinal)
        {
            var id = App.DatabaseSinal.SaveItem(sinal);
            sinal.Codigo = id;

            return sinal;
        }

        EscritaSinais RegistrarEscritaSinal(EscritaSinais escritaSinais)
        {
            var id = App.DatabaseEscritaSinais.SaveItem(escritaSinais);
            escritaSinais.Codigo = id;

            return escritaSinais;
        }

        ImagemRepresentativa RegistrarImagemRepresentativa(ImagemRepresentativa imagemRepresentativa)
        {
            var id = App.DatabaseImagemRepresentativa.SaveItem(imagemRepresentativa);
            imagemRepresentativa.Codigo = id;

            return imagemRepresentativa;
        }


        void Finish_Clicked(object sender, System.EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(_base64))
            {
                DisplayAlert("", "Por favor, selecione uma imagem", "OK");
                return;
            }


            _sinal = RegistrarSinal(_sinal);
            _contexto.CodigoSinal = _sinal.Codigo;
            _imgRepresentativa.CodigoSinal = _sinal.Codigo;
            _escritaSinais = new EscritaSinais { Imagem = _base64, CodigoSinal = _sinal.Codigo };

            _contexto = RegistrarContexto(_contexto);
            _escritaSinais = RegistrarEscritaSinal(_escritaSinais);
            _imgRepresentativa = RegistrarImagemRepresentativa(_imgRepresentativa);

            //Registrar todos os objetos
            DisplayAlert("", "Registro concluído com sucesso", "OK");
            Navigation.PopToRootAsync();
        }
    }
}
