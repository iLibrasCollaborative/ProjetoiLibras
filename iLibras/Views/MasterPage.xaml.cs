using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iLibras
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public ListView ListViewCoordenador { get { return listViewCoordenador; } }
        public ListView ListViewComunicador { get { return listViewComunicador; } }
        public ListView ListViewCooperador { get { return listViewCooperador; } }
        public Label Label { get { return lblLogin; } }
        public Label UsuarioLabel { get { return lblUsuario; } }

        public MasterPage()
        {
            InitializeComponent();
        }
    }
}
