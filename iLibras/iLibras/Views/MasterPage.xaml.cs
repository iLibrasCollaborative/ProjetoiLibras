using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iLibras
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public Label Label { get { return lblLogin; } }

        public MasterPage()
        {
            InitializeComponent();
        }
    }
}
