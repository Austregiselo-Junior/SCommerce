using SCommerce.Main.Model.Entities;
using SCommerce.Main.Model.Services.CartService;
using SCommerce.Main.Model.Services.ProductServer;
using SCommerce.Main.MVVM;
using System;
using System.Collections.Generic;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : MVVMBase
    {
        public event EventHandler OnGetBadgeQuantity;

        #region Propertys

        public int Badge { get; private set; }
        public Product ItemSelected { get; set; }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public List<string> Images { get; set; }

        private string selectedImage;

        public string SelectedImage
        {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    OnPropertyChanged("SelectedImage");
                }
            }
        }

        #endregion Propertys

        public ProductDetailsPageViewModel()
        {
            GetProductfromHome();
            this.Images = ProductServer.GetInstance().GetImagesFromProduct();

            var randon = new Random();
            this.SelectedImage = Images[randon.Next(Images.Count)];
        }

        public void AddToCart_Click()
        {
            CartService.GetInstance().AddProductinCart(1, 1);
            SendQuantityCarttoBadge(1);
        }

        private void SendQuantityCarttoBadge(int quantity)
        {
            var mainMenu = MainMenuViewModel.GetInstance();
            mainMenu.OnCreated += mainMenu.OnGetBadgeQuantity;

            mainMenu.Create(quantity);
            mainMenu.OnCreated -= mainMenu.OnGetBadgeQuantity;
        }

        public void GetProductfromHome()
        {
            this.Title = HomePageViewModel.ProductinCache.Name;
            this.Description = HomePageViewModel.ProductinCache.Description;
            this.Price = HomePageViewModel.ProductinCache.Price;
            this.Rating = HomePageViewModel.ProductinCache.Rating;
            this.SelectedImage = HomePageViewModel.ProductinCache.Image;

            // Tá assim, mas não é o correto.
            // O correto é passar via Navigate, só que para isso devemos corrigir o XAML referente a essa página.
            // Devemos ajustar o xaml pra pegar os dados de um ítem selecionado que vai chegar no OnNavigateTo, deve ser semelhante
            // ao xaml do CartPage.
        }
    }
}