using System;
using Xamarin.Forms;

namespace iLibras
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1577d2");

            masterPage.ListView.ItemSelected += OnItemSelected;

            masterPage.Label.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnLabelClicked())
            });

        }

        void OnLabelClicked()
        {
            Detail = new NavigationPage(new LoginPage());
            masterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                ((NavigationPage)Detail).BarBackgroundColor = Color.FromHex("#1577d2");
                masterPage.ListView.SelectedItem = null;
                Detail.Title = item.Title;
                IsPresented = false;
            }
        }
    }
}
