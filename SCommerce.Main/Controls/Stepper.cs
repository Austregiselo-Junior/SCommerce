using SCommerce.Main.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Controls
{
    [TemplatePart(Name = PartAddButton, Type = typeof(Button))]
    [TemplatePart(Name = PartSubtractButton, Type = typeof(Button))]
    [TemplatePart(Name = PartRemoveButton, Type = typeof(Button))]
    public sealed class Stepper : Control
    {
        private const string PartAddButton = "PartAddButton";
        private const string PartSubtractButton = "PartSubtractButton";
        private const string PartRemoveButton = "PartRemoveButton";

        private const string StateNormal = "Normal";
        private const string StateManyItems = "ManyItems";

        public event RoutedEventHandler RemoveAll;

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Stepper), new PropertyMetadata(0, OnValuePropertyChanged));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = (Stepper)d;
            self.UpdateVisualState();
        }

        public Stepper()
        {
            this.DefaultStyleKey = typeof(Stepper);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            BindClickEvent();

            UpdateVisualState();
        }

        private void BindClickEvent()
        {
            if (GetTemplateChild(PartAddButton) is Button addBtn)
            {
                addBtn.Click += OnAdd;
            }

            if (GetTemplateChild(PartSubtractButton) is Button subtractBtn)
            {
                subtractBtn.Click += OnSubtract;
            }

            if (GetTemplateChild(PartRemoveButton) is Button removeBtn)
            {
                removeBtn.Click += OnSubtract;
            }
        }

        private void OnSubtract(object sender, RoutedEventArgs e)
        {
            if (Value == 0)
            {
                RemoveAll?.Invoke(this, new RoutedEventArgs());
                return;
            }
            Value--;
           // Subtracted?.Invoke(this, new RoutedEventArgs());
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            Value++;
           // Add?.Invoke(this, new RoutedEventArgs());
        }

        private void UpdateVisualState()
        {
            var state = (Value <= 1 ? StateNormal: StateManyItems);
            VisualStateManager.GoToState(this, state, false);
        }
    }
}
