using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Product.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjouterProduit : ContentPage
    {
        public bool _UpdateMode { get; set; }
        public int _ProductToUpdate { get; set; }
        public AjouterProduit()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetProductsAsync();
        }

        async void AjouterProduitBtn(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(priceEntry.Text) && !string.IsNullOrWhiteSpace(quantityEntry.Text))
            {
                await App.Database.SaveProductAsync(new Product
                {
                    Name = nameEntry.Text,
                    Price = int.Parse(priceEntry.Text),
                    Quantity = int.Parse(quantityEntry.Text)
                });

                nameEntry.Text = priceEntry.Text = quantityEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetProductsAsync();
            }
        }

        private async void DeleteProduitBtn(object sender, EventArgs e)
        {
            try
            {
                string ID = (sender as Button).CommandParameter.ToString();
                if (!string.IsNullOrWhiteSpace(ID))
                {
                    var product = await App.Database.GetSingleProduct(int.Parse(ID));
                    var result = await DisplayAlert("Confirmation", "vous préferez de supprimer ce produit?: " + product.Name.ToString() + "?", "Yes", "No");
                    if (result)
                        await App.Database.DeleteProductAsync(product);
                    OnAppearing();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}