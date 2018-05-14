using System;
using System.Collections.Generic;
using System.IO;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<HomeViewModel>(this.BindingContext,
                                                     "NovoTermoCommand", async (sender) =>
            {
                await Navigation.PushAsync(new StepOnePage());
            });
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<HomeViewModel>(this.BindingContext,
                                                   "NovoTermoCommand");
        }

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            var search = (SearchBar)sender;
            var textSearch = search.Text;

            var contexto = App.DatabaseContexto.GetItem(textSearch);

            if(contexto != null){ 
                var sinal = App.DatabaseSinal.GetItem(contexto.CodigoSinal);
                var escritaSinal = App.DatabaseEscritaSinais.GetItemsSinal(contexto.CodigoSinal)[0];
                var imgRepresentativa = App.DatabaseImagemRepresentativa.GetItemsSinal(contexto.CodigoSinal)[0];

                imgGif.Source = ImageSource.FromStream(() =>
                {
                    var img = Convert.FromBase64String(sinal.Gif);
                    var ms = new MemoryStream(img);
                    return ms;
                });
                imgGif.IsVisible = true;

                imgEscritaSinais.Source = ImageSource.FromStream(() =>
                {
                    var img = Convert.FromBase64String(escritaSinal.Imagem);
                    var ms = new MemoryStream(img);
                    return ms;
                });
                imgEscritaSinais.IsVisible = true;
                imgImagemRepresentativa.Source = ImageSource.FromStream(() =>
                {
                    var img = Convert.FromBase64String(imgRepresentativa.Imagem);
                    var ms = new MemoryStream(img);
                    return ms;
                });
                imgImagemRepresentativa.IsVisible = true;

                slContexto.IsVisible = true;
                lblContexto.Text = contexto.ContextoTexto;
                lblDescricao.Text = contexto.Descricao;
                //lblTag.Text = App.DatabaseTag.GetItemAsync(contexto.CodigoTag).Descricao;

                return;
            }


            DisplayAlert("", "Nenhum registro encontrado com \"" + textSearch + "\"", "OK");
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            
        }

        public HomePage(int index){
            InitializeComponent();

            switch(index){
                case 1:
                    this.SelectedItem = gifPage;
                    return;
                case 2:
                    this.SelectedItem = contextPage;
                    return;
                case 3:
                    this.SelectedItem = imgPage;
                    return;
                case 4:
                    this.SelectedItem = sinalPage;
                    return;
            }
        }
    }
}
