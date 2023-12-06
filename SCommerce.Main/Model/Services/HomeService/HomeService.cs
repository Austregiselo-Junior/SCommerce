using SCommerce.Main.Model.Data;
using SCommerce.Main.Model.Entities;
using SCommerce.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;

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
