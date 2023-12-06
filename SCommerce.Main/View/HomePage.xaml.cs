using SCommerce.Main.Model.Entities;
using SCommerce.Main.Model.Services.CartService;
using SCommerce.Main.Model.Services.HomeService;
using SCommerce.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePageViewModel ViewModel => (HomePageViewModel)this.DataContext;
        public HomePage()
        {
            this.InitializeComponent();
            this.DataContext = new HomePageViewModel();

            (App.Current as App).SetVisibleButtonAppBarButton(true);
            (App.Current as App).SetVisibleButtonGoHomePage(false);
            (App.Current as App).SetVisibleButtonTryGoBackPage(false);
            (App.Current as App).SetVisibleButtonCartQiantityItens(false);
            (App.Current as App).SetVisibleButtonSettingPage(false);
            // TODO - Nova funcionalidade ->  Futuramente deverar ter uma barra de pesquisa.
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (HomePageViewModel.ProductinCache is null)
            {
                return; //TODO: Improvement -> deverá haver um popUp informando o usuário que não há ítem selecionado
            }
            else { this.Frame.Navigate(typeof(ProductDetailsPage)); }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                ViewModel.Products = (List<Product>)e.Parameter;
            }
            else { ViewModel.Products = HomeService.GetInstance().GetProductsforHomePage(); }
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
