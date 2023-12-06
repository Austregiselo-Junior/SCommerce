using SCommerce.Main.Model.Data;
using SCommerce.Main.ViewModels;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Services.ProductServer
{
    public class ProductServer 
    {
        private static ProductServer _instance;

        private ProductServer()
        {
        }

        public static ProductServer GetInstance() => _instance ?? (_instance = new ProductServer());
    

        public string GetTitleProductforProductDetailsPage()
        {
            return ServiceConnection.GetInstance().GetTitleProduct();
        }

        public string GetDescriptionProductforProductDetailsPage()
        {
           return ServiceConnection.GetInstance().GetDescriptionProduct();
        }

        public float GetPriceProductforProductDetailsPage()
        {
            return ServiceConnection.GetInstance().GetPriceProduct();
        }

        public int GetRatingProductforProductDetailsPage()
        {
            return ServiceConnection.GetInstance().GetRatingProduct();
        }

        public List<string> GetImagesFromProduct()
        {
            return ServiceConnection.GetInstance().GetImageProduct();
        }
    }
}
