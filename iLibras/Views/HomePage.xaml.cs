using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iLibras
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
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
