using SCommerce.Main.Controls.MainMenu;
using SCommerce.Main.MVVM;
using System;

namespace SCommerce.Main.ViewModels
{
    public class MainMenuViewModel : MVVMBase
    {
        public EventHandler<MainMenuEventArgs> OnCreated;
        private static MainMenuViewModel _instance;
        private static object locallock = new object();

        public static MainMenuViewModel GetInstance()
        {
            lock (locallock)
            {
                if (_instance is null)
                {
                    _instance = new MainMenuViewModel();
                }
                return _instance;
            }
        }

        private int _badgeQuantity;

        public int BadgeQuantity
        {
            get { return _badgeQuantity; }
            set
            {
                if (_badgeQuantity != value)
                {
                    _badgeQuantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Create(int quantity)
        {
            if (OnCreated != null)
            {
                OnCreated(this, new MainMenuEventArgs { BadgeQuantity = quantity });
            }
        }

        public void OnGetBadgeQuantity(object sender, MainMenuEventArgs e)
        {
            BadgeQuantity += e.BadgeQuantity;
        }
    }
}