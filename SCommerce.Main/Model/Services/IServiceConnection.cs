using SCommerce.Main.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCommerce.Main.Model.Services
{
    internal interface IServiceConnection
    {
        event EventHandler OnCreated;
        List<Product> GetListProducts();
        int GetIdProduct();
        string GetTitleProduct();
        string GetDescriptionProduct();
        float GetPriceProduct();
        int GetRatingProduct();
        List<string> GetImageProduct();
        void OnStartDB();
    }
}
