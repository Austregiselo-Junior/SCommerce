using SCommerce.Main.Model.Entities;
using SCommerce.Main.Model.Services;
using SCommerce.Main.Model.Services.HomeService;
using SCommerce.Main.MVVM;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.ViewModels
{
    public class HomePageViewModel : MVVMBase
    {
        private static readonly string _cacheKey = "ItemSelected";
        public string TitleofPage { get; set; }

        public static Product ProductinCache { get; private set; }

        public static Product SelectedItem { get; private set; }

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    OnPropertyChanged("Products");
                }
            }
        }

        public HomePageViewModel()
        {
            TitleofPage = "Escolha seu produto!";
            UnAssined();
            Assined();
        }

        private void UnAssined()
        {
            ServiceConnection.GetInstance().OnCreated -= GetProductsforHomePage;
        }

        private void Assined()
        {
            ServiceConnection.GetInstance().OnCreated += GetProductsforHomePage;
        }

        public void GetProductsforHomePage(object sender, EventArgs e)
        {
            Products = HomeService.GetInstance().GetProductsforHomePage();
        }

        public void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectedItem = e.ClickedItem as Product;
            AddItemInCache();
        }

        /// <summary>
        /// Esse método mostra como adicionar informações a um Cache me memória, mas bom evitar porque o uso de cache pode causar gargalo de memória.
        /// </summary>
        /// <returns></returns>
        private void AddItemInCache()
        {
            var cache = new MemoryCache(_cacheKey);// Criar uma instância do MemoryCache
            try
            {
                cache.Add(_cacheKey, SelectedItem, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(1) });// Adicionar um item ao cache com uma chave e um tempo de vida
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }

            ProductinCache = (Product)cache.Get(_cacheKey);// Recuperar um item do cache
        }
    }
}