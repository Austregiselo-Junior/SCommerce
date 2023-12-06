using SCommerce.Main.Model.Data;
using SCommerce.Main.Model.Entities;
using System;
using System.Collections.Generic;

namespace SCommerce.Main.Model.Services
{/// <summary>
/// Esse serviço expoe o banco de dados, todas as requisições devem passar por aqui.
/// </summary>
    internal class ServiceConnection : IServiceConnection
    {
        private static ServiceConnection _instance;
        private static object locallock = new object();

        public event EventHandler OnCreated;

        private ServiceConnection()
        { }

        public static ServiceConnection GetInstance()
        {
            lock (locallock)
            {
                if (_instance is null)
                {
                    _instance = new ServiceConnection();
                }
                return _instance;
            }
        }

        public int GetIdProduct()
        {
            int id = 0;
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                id = item.ID;
            }
            return id;
        }

        public string GetTitleProduct()
        {
            string name = "";
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                name = item.Name;
            }
            return name;
        }

        public string GetDescriptionProduct()
        {
            string description = "";
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                description = item.Description;
            }
            return description;
        }

        public float GetPriceProduct()
        {
            float price = 0;
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                price = item.Price;
            }
            return price;
        }

        public int GetRatingProduct()
        {
            int rating = 0;
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                rating = item.Rating;
            }
            return rating;
        }

        public List<string> GetImageProduct()
        {
            List<string> image = new List<string>();
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                image.Add(item.Image);
            }
            return image;
        }

        public List<string> GetListFromImageProduct()
        {
            List<string> imagesFromProduct = new List<string>();
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                imagesFromProduct.Add(item.ImagesFromProduct.ToString()); // Ainda há problema com esse método, por hora vamos usar o de cima
            }
            return imagesFromProduct;
        }

        public List<Product> GetListProducts()
        {
            List<Product> products = new List<Product>();
            foreach (var item in MockDBBaseService.GetInstanceDB().GetProductsfromDB())
            {
                products.Add(item);
            }
            return products;
        }

        public void OnStartDB()
        {
            OnCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}