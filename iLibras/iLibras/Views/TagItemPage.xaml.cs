using System;
using System.Collections.Generic;
using iLibras.Models;
using iLibras.ViewModels;
using Xamarin.Forms;

namespace iLibras
{
    public partial class TagItemPage : ContentPage
    {
        public Tag Item { get; set; }

        public TagItemPage(Tag tag)
        {
            InitializeComponent();

            this.BindingContext = new TagViewModel();
            pckCategoria.ItemsSource = App.DatabaseCategoria.GetItemsDescricao();

            if (tag.Codigo != 0)
            {
                btnDeletar.IsVisible = true;
                etyCodigo.IsVisible = true;
                etyCodigo.Text = tag.Codigo.ToString();
                etyDescricao.Text = tag.Descricao;

                for (var i = 0; i < pckCategoria.Items.Count; i++)
                   if(tag.DescricaoCategoria.ToLower().Equals(pckCategoria.Items[i].ToString().ToLower()))
                       pckCategoria.SelectedIndex = i;
                
                pckCategoria.SelectedItem = tag.DescricaoCategoria;
            }
        }

        private Tag MontarObjeto()
        {
            var tag = new Tag();
            var cod = 0;

            int.TryParse(etyCodigo.Text, out cod);
            tag.Codigo = cod;
            tag.Descricao = etyDescricao.Text;

            tag.DescricaoCategoria = pckCategoria.SelectedItem.ToString();

            return tag;
        }

        void Handle_Disappearing(object sender, System.EventArgs e)
        {
            MessagingCenter.Unsubscribe<TagViewModel>(this.BindingContext,
                                                                "SalvarTagCommand");
            MessagingCenter.Unsubscribe<TagViewModel>(this.BindingContext,
                                                    "DeletarTagCommand");
        }

        void Handle_Appearing(object sender, System.EventArgs e)
        {
            RegistrarMensageria();
        }

        private void RegistrarMensageria()
        {
            MessagingCenter.Subscribe<TagViewModel>(this.BindingContext,
                                    "SalvarTagCommand", (sender) =>
                                    {
                                        App.DatabaseTag.SaveItemAsync(MontarObjeto());
                                        Navigation.RemovePage(this);
                                    });

            MessagingCenter.Subscribe<TagViewModel>(this.BindingContext,
                                    "DeletarTagCommand", (sender) =>
                                    {
                                        App.DatabaseTag.DeleteItemAsync(MontarObjeto());
                                        Navigation.RemovePage(this);
                                    });
        }
    }
}
