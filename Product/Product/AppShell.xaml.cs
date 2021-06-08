using Product.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Product
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AjouterProduit), typeof(AjouterProduit));
            
        }


    }
}
