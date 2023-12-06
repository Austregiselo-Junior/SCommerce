using SCommerce.Main.Model.Entities;
using SCommerce.Main.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SCommerce.Main.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductDetailsPage : Page
    {
        public ProductDetailsPageViewModel ViewModel => (ProductDetailsPageViewModel)this.DataContext;

        public ProductDetailsPage()
        {
            this.InitializeComponent();
            this.DataContext = new ProductDetailsPageViewModel();

            (App.Current as App).SetVisibleButtonAppBarButton(true);
            (App.Current as App).SetVisibleButtonTryGoBackPage(true);
            (App.Current as App).SetVisibleButtonCartQiantityItens(true);
            (App.Current as App).SetVisibleButtonSettingPage(true);
            (App.Current as App).SetVisibleButtonGoHomePage(false);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                ViewModel.ItemSelected = (Product)e.Parameter;
            }
        }
    }
}