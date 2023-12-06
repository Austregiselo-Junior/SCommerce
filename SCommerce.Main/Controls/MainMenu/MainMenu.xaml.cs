using SCommerce.Main.Model.Services.CartService;
using SCommerce.Main.Model.Services.HomeService;
using SCommerce.Main.View;
using SCommerce.Main.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Controls.MainMenu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainMenu : Page
    {
        public MainMenuViewModel ViewModel => (MainMenuViewModel)this.DataContext;
        private AppShell _appShell = null;

        public MainMenu()
        {
            this.InitializeComponent();
            this.DataContext = MainMenuViewModel.GetInstance();
        }

        public Visibility TryGoBackPage
        {
            get { return (Visibility)GetValue(TryGoBackPageProperty); }
            set { SetValue(TryGoBackPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TryGoBackPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TryGoBackPageProperty =
            DependencyProperty.Register("TryGoBackPage", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        public Visibility GoHomePage
        {
            get { return (Visibility)GetValue(GoHomePageProperty); }
            set { SetValue(GoHomePageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoHomePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoHomePageProperty =
            DependencyProperty.Register("GoHomePage", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        public Visibility CartQuantityItens
        {
            get { return (Visibility)GetValue(CartQuantityItensProperty); }
            set { SetValue(CartQuantityItensProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoHomePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartQuantityItensProperty =
            DependencyProperty.Register("CartQuantityItens", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        public Visibility AppBarButton
        {
            get { return (Visibility)GetValue(AppBarButtonProperty); }
            set { SetValue(AppBarButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoHomePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppBarButtonProperty =
            DependencyProperty.Register("AppBarButton", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        public Visibility SettingPage
        {
            get { return (Visibility)GetValue(SettingPageProperty); }
            set { SetValue(SettingPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoHomePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SettingPageProperty =
            DependencyProperty.Register("SettingPage", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        public Visibility SearchBar
        {
            get { return (Visibility)GetValue(SearchBarProperty); }
            set { SetValue(SearchBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoHomePage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchBarProperty =
            DependencyProperty.Register("SearchBar", typeof(Visibility), typeof(MainMenu), new PropertyMetadata(Visibility.Collapsed));

        private void GoBackPage_Click(object sender, RoutedEventArgs e)
        {
            TryGoBack();
        }

        public bool TryGoBack()
        {
            (App.Current as App).NavigationService.GoBack();
            return true;
        }

        private void GoHomePage_Click(object sender, RoutedEventArgs e)
        {
            var parameter = HomeService.GetInstance().GetProductsforHomePage();
            (App.Current as App).NavigationService.Navigate(typeof(HomePage), parameter);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var parameter = CartService.GetInstance().GetProductsFromCart();
            (App.Current as App).NavigationService.Navigate(typeof(CartPage), parameter);
        }

        private void GoSettingsPage_Click(object sender, RoutedEventArgs e)
        {
            //TODO A página ainda será criada
        }
    }
}