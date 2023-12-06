using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Controls
{
    public sealed class Rating : Control
    {
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Rating), new PropertyMetadata(1, OnValuePropertyChanged));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rating = (Rating)d;
            rating.UpdateRatingState();
        }

        private void UpdateRatingState()
        {
            var val = Math.Clamp(Value, 1, 5);
            var state = $"Rating{val}";
            VisualStateManager.GoToState(this, state, false);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateRatingState();
        }

        public Rating()
        {
            this.DefaultStyleKey = typeof(Rating);
        }
    }
}