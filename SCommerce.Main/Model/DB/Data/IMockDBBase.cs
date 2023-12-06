using SCommerce.Main.Model.Entities;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Data
{
    internal interface IMockDBBaseService
    {
        List<Product> GetProductsfromDB();
        List<Product> PostProductsfromDB();
        void PutProductsfromDB();
        void DeleteProductsfromDB();
    }
}