using System;
using System.Collections.Generic;
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
