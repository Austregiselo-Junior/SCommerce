using SCommerce.Main.Model.Entities;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Services.HomeService
{
    internal class HomeService
    {
        private static HomeService _instance;

        public static HomeService GetInstance() => _instance ?? (_instance = new HomeService());

        public List<Product> GetProductsforHomePage()
        {
            return ServiceConnection.GetInstance().GetListProducts();
        }
    }
}