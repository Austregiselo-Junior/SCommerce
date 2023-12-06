using SCommerce.Main.Model.Entities;
using SCommerce.Main.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main.View
{
    public sealed partial class CartPage : Page
    {
        public CartPageViewModel ViewModel => (CartPageViewModel)this.DataContext;

        public CartPage()
        {
            this.InitializeComponent();
            this.DataContext = new CartPageViewModel();

            (App.Current as App).SetVisibleButtonAppBarButton(true);
            (App.Current as App).SetVisibleButtonTryGoBackPage(true);
            (App.Current as App).SetVisibleButtonCartQiantityItens(false);
            (App.Current as App).SetVisibleButtonSettingPage(true);
            (App.Current as App).SetVisibleButtonGoHomePage(true);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                ViewModel.Itens = (List<Cart>)e.Parameter;
            }
        }
    }
}