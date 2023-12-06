using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        public void SetContent(Frame frame)
        {
            ContentFrame.Content = frame;
        }

        public void SetVisibleTryGoBackPage(bool visible)
        {
            mainMenu.TryGoBackPage = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetVisibleGoHomePage(bool visible)
        {
            mainMenu.GoHomePage = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetVisibleCartQuantityItens(bool visible)
        {
            mainMenu.CartQuantityItens = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetVisibleAppBarButton(bool visible)
        {
            mainMenu.AppBarButton = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetVisibleAppSettingPageButton(bool visible)
        {
            mainMenu.SettingPage = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetVisibleAppSearchbar(bool visible)
        {
            mainMenu.SearchBar = visible ? Visibility.Visible : Visibility.Collapsed; // continuar fazendo a barra de pesquisa.
        }
    }
}