using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Controls
{
    public sealed class BadgeAppBarButton : AppBarButton
    {
        public static string Quantity { get; set; }
        private const string Hidden = "BadgeHasHidden";
        private const string Visible = "BadgeHasVisible";

        public string Badge
        {
            get { return (string)GetValue(BadgeProperty); }
            set { SetValue(BadgeProperty, value); }
        }

        public static readonly DependencyProperty BadgeProperty =
        DependencyProperty.Register("Badge", typeof(string), typeof(BadgeAppBarButton), new PropertyMetadata(string.Empty, OnBadgePropertyChanged));

        private static void OnBadgePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var badgeState = e.NewValue as string;
            var state = badgeState == string.Empty || badgeState == "0" ? Hidden : Visible;
            VisualStateManager.GoToState((Control)d, state, false);

            Quantity = badgeState;
        }

        public BadgeAppBarButton()
        {
            this.DefaultStyleKey = typeof(BadgeAppBarButton);
        }
    }
}