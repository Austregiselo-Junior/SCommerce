using SCommerce.Main.Model.Entities;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Data
{
    internal class MockDBBaseService : IMockDBBaseService
    {
        private static MockDBBaseService _instance;
        private List<Product> _data;

        private MockDBBaseService() => _data = new List<Product>();

        public static MockDBBaseService GetInstanceDB() => _instance is null ? _instance = new MockDBBaseService() : _instance;

        public List<Product> GetProductsfromDB() => PostProductsfromDB();

        public void DeleteProductsfromDB()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> PostProductsfromDB()
        {
            var products = new List<Product>()
            { new Product{ID = 1, Name = "X Combo",Description = "Um combo completo", Price = 15.24F , Rating = 5, Image = "ms-appx:///Assets/Images/X_combo.png",
                ImagesFromProduct = { "ms-appx:///Assets/Images/Xcombo1.Jpeg", "ms-appx:///Assets/Images/Xcombo2.Jpeg", "ms-appx:///Assets/Images/Xcombo3.Jpeg"}},
                new Product{ID = 2, Name = "X Duplo",Description = "Um hamburger duplo com cheda", Price = 25.99F , Rating =3, Image = "ms-appx:///Assets/Images/X_Duplo.png",
                ImagesFromProduct = { "ms-appx:///Assets/Images/H_Duplo.Jpeg", "ms-appx:///Assets/Images/HamburguerDuplo.Jpeg", "ms-appx:///Assets/Images/Hamburguer_duplo.Jpeg"}},
                new Product{ID = 3, Name = "X Frango",Description = "Hamburguer de frango com muito molho...", Price = 10.50F , Rating = 4, Image = "ms-appx:///Assets/Images/H_Frango4.jpeg",
                ImagesFromProduct = { "ms-appx:///Assets/Images/H_Frango2.Jpeg", "ms-appx:///Assets/Images/H_frango1.png", "ms-appx:///Assets/Images/H_Frango3.png"}},
            new Product{ID = 4, Name = "X Combo",Description = "Um combo completo", Price = 15.24F , Rating =1, Image = "ms-appx:///Assets/Images/X_combo.png",
                ImagesFromProduct = { "ms-appx:///Assets/Images/Xcombo1.Jpeg", "ms-appx:///Assets/Images/Xcombo2.Jpeg", "ms-appx:///Assets/Images/Xcombo3.Jpeg"}},
                new Product{ID = 5, Name = "X Duplo",Description = "Um hamburger duplo com cheda", Price = 15.24F , Rating = 4, Image = "ms-appx:///Assets/Images/X_Duplo.png",
                ImagesFromProduct = { "ms-appx:///Assets/Images/H_Duplo.Jpeg", "ms-appx:///Assets/Images/HamburguerDuplo.Jpeg", "ms-appx:///Assets/Images/Hamburguer_duplo.Jpeg"}},
                new Product{ID = 6, Name = "X Frango",Description = "Hamburguer de frango com muito molho...", Price = 15.24F , Rating = 2, Image = "ms-appx:///Assets/Images/H_Frango4.jpeg",
                ImagesFromProduct = { "ms-appx:///Assets/Images/H_Frango2.Jpeg", "ms-appx:///Assets/Images/H_1rango1.png", "ms-appx:///Assets/Images/H_Frango3.png"}}
            };

            return _data = products;
        }

        public void PutProductsfromDB()
        {
            throw new System.NotImplementedException();
        }
    }
}