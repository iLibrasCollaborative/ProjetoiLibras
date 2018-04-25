using System;
using Xamarin.Forms;

namespace iLibras
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            AlterarCabecalhoSessao();

            ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1577d2");

            masterPage.ListView.ItemSelected += OnItemSelected;
            masterPage.ListViewCooperador.ItemSelected += OnItemSelected;
            masterPage.ListViewComunicador.ItemSelected += OnItemSelected;
            masterPage.ListViewCoordenador.ItemSelected += OnItemSelected;

            masterPage.Label.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked())
            });
        }

        void OnLabelClicked()
        {
            Detail = new NavigationPage(new LoginPage());
            ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1577d2");
            masterPage.ListView.SelectedItem = null;
            masterPage.ListViewCooperador.SelectedItem = null;
            masterPage.ListViewComunicador.SelectedItem = null;
            masterPage.ListViewCoordenador.SelectedItem = null;
            IsPresented = false;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                if (!string.IsNullOrWhiteSpace(item.Acao))
                    RealizarAcao(item.Acao);

                AlterarCabecalhoSessao();

                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1577d2");
                masterPage.ListView.SelectedItem = null;
                masterPage.ListViewCooperador.SelectedItem = null;
                masterPage.ListViewComunicador.SelectedItem = null;
                masterPage.ListViewCoordenador.SelectedItem = null;
                Detail.Title = item.Title;
                IsPresented = false;
            }
        }

        private void AlterarCabecalhoSessao()
        {
            var sessao = App.DatabaseSessao.GetItem();
            
            if ((sessao.CodigoUsuario == 999999 || sessao.CodigoUsuario == -1) && App.User == null){
                masterPage.UsuarioLabel.Text = "Você não está logado ainda.";
                masterPage.ListView.IsVisible = false;
                masterPage.ListViewCooperador.IsVisible = false;
                masterPage.ListViewCoordenador.IsVisible = false;
                masterPage.ListViewComunicador.IsVisible = true;
                masterPage.Label.IsVisible = true;
            } else {
                var usuario = App.DatabaseUsuario.GetItem(sessao.CodigoUsuario);

                if (usuario == null)
                    usuario = App.User;

                masterPage.UsuarioLabel.Text = "Bem vindo(a), " + usuario.Nome;
                masterPage.Label.IsVisible = false;

                if(usuario.Perfil == 1){
                    masterPage.ListView.IsVisible = true;
                    masterPage.ListViewCooperador.IsVisible = false;
                    masterPage.ListViewCoordenador.IsVisible = false;
                    masterPage.ListViewComunicador.IsVisible = false;
                } else if (usuario.Perfil == 2){
                    masterPage.ListView.IsVisible = false;
                    masterPage.ListViewCooperador.IsVisible = false;
                    masterPage.ListViewCoordenador.IsVisible = true;
                    masterPage.ListViewComunicador.IsVisible = false;
                } else if (usuario.Perfil == 3) {
                    masterPage.ListView.IsVisible = false;
                    masterPage.ListViewCooperador.IsVisible = true;
                    masterPage.ListViewCoordenador.IsVisible = false;
                    masterPage.ListViewComunicador.IsVisible = false;
                } else {
                    masterPage.ListView.IsVisible = false;
                    masterPage.ListViewCooperador.IsVisible = false;
                    masterPage.ListViewCoordenador.IsVisible = false;
                    masterPage.ListViewComunicador.IsVisible = true;
                }
            }
        }

        void RealizarAcao(string acao){
            switch(acao.ToLower()){
                case "sair":
                    App.User = null;
                    App.DatabaseSessao.SaveItem(new Models.Sessao
                    {
                        CodigoUsuario = -1,
                        CodigoRegionalidade = App.DatabaseSessao.GetItem().CodigoRegionalidade
                    });
                    return;
            }
        }
    }
}
