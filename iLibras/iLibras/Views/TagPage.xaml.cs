using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class TagPage : ContentPage
    {
        public TagPage()
        {
            InitializeComponent();
            this.BindingContext = new TagViewModel();
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<TagViewModel>(this.BindingContext,
                  "AddTagCommand", async (sender) =>
                  {
                      await Navigation.PushAsync(new TagItemPage(new Tag()));
                  });

            MessagingCenter.Subscribe<TagViewModel>(this.BindingContext,
                  "ModificarTagCommand", async (sender) =>  
            {
                var bind = (TagViewModel)this.BindingContext;
                await Navigation.PushAsync(new TagItemPage(bind.tag));
            });
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            var lista = App.DatabaseTag.GetItemsAsync();
            listView.ItemsSource = App.DatabaseTag.GetItemsAsync();
            RegistrarMensageria();
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<TagViewModel>(this.BindingContext,
                                                               "AddTagCommand");
            MessagingCenter.Unsubscribe<TagViewModel>(this.BindingContext,
                                                              "ModificarTagCommand");
        }
    }
}
