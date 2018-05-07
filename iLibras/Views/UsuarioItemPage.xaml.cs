using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using iLibras.Models;
using iLibras.ViewModels;
using Plugin.Media;
using Xamarin.Forms;

namespace iLibras
{
    public partial class UsuarioItemPage : ContentPage
    {
        private string _base64;

        public UsuarioItemPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginItemViewModel();
            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();
            pckEstado.SelectedItem = "Santa Catarina";
        }

        public UsuarioItemPage(Usuario user)
        {
            InitializeComponent();
            this.BindingContext = new LoginItemViewModel();
            pckEstado.ItemsSource = App.DatabaseEstado.GetItemsString();

            etySenha.IsVisible = false;
            etyConfirmarSenha.IsVisible = false;
            lblSenha.IsVisible = false;
            lblConfirmarSenha.IsVisible = false;
            pckEstado.SelectedItem = App.DatabaseEstado.GetItem(user.Estado).Extenso;
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();

            imgUsuario.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnChooseImagem())
            });
        }

        async void OnChooseImagem(){
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null) return;

            _base64 = Convert.ToBase64String(File.ReadAllBytes(file.Path));

            imgUsuario.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<LoginItemViewModel>(this.BindingContext,
                                                                "SalvarLoginCommand");
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<LoginItemViewModel>(this.BindingContext,
                                                              "SalvarLoginCommand", (sender) =>
                                    {
                                        if (!CamposObrigatorios())
                                            return;

                                        if (!ValidarEmail())
                                            return;

                                        if (!ValidarSenhas())
                                            return;

                                        if (!ValidarData())
                                            return;

                                        var usuario = MontarObjeto();
                                        App.DatabaseUsuario.SaveItem(usuario);
                                        DisplayAlert("", "Usuário registrado com sucesso", "Ok");
                                        Navigation.RemovePage(this);
                                    });
        }

        bool ValidarEmail(){
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!string.IsNullOrWhiteSpace(etyEmail.Text) && rg.IsMatch(etyEmail.Text))
                return true;
            else
            {
                DisplayAlert("E-mail inválido", "O e-mail informado não é válido", "Ok");
                return false;
            }
        }

        bool ValidarSenhas(){
            if(string.IsNullOrWhiteSpace(etySenha.Text) || string.IsNullOrWhiteSpace(etyConfirmarSenha.Text) ||
               etySenha.Text.Length < 6){
                DisplayAlert("Senha inválida", "A senha deve possuir pelo menos 6 caracteres", "Ok");
                return false;
            }

            if(!etySenha.Text.Equals(etyConfirmarSenha.Text)){
                DisplayAlert("Senhas não coincidem", "As senhas digitadas não coincidem", "Ok");
                return false;
            }

            return true;
        }

        bool ValidarData(){
            if(pckData.Date > DateTime.Now){
                DisplayAlert("Data inválida", "A data não pode ser maior que a atual", "Ok");
                return false;
            }

            return true;
        }

        bool CamposObrigatorios(){
            if (string.IsNullOrWhiteSpace(etyNome.Text)){
                DisplayAlert("Campo obrigatório", "O campo 'Nome' é obrigatório", "Ok");
                return false;
            }

            if(pckEstado.SelectedItem == null) {
                DisplayAlert("Campo obrigatório", "O campo 'Estado' é obrigatório", "Ok");
                return false;
            }

            return true;
        }

        Usuario MontarObjeto(){
            var usuario = new Usuario
            {
                Nome = etyNome.Text,
                Email = etyEmail.Text,
                Estado = App.DatabaseEstado.GetItem(pckEstado.SelectedItem.ToString()).Codigo,
                Perfil = App.DatabasePerfil.GetItem("Comunicador").Codigo,
                Senha = etySenha.Text,
                DataNascimento = pckData.Date,
                Imagem = _base64
            };

            return usuario;
        }
    }
}
