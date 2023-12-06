using SCommerce.Main.Model.Entities;
using SCommerce.Main.Model.Services;
using SCommerce.Main.Model.Services.CartService;
using SCommerce.Main.MVVM;
using System.Collections.Generic;
using System.Linq;

namespace SCommerce.Main.ViewModels
{
    public class CartPageViewModel : MVVMBase
    {
        private string selectedsteps;
        public string SelectedSteps
        {
            get { return selectedsteps; }
            set
            {
                if (selectedsteps != value)
                {
                    selectedsteps = value;
                    OnPropertyChanged("SelectedSteps");
                }
            }
        }

        private List<string> steps;
        public List<string> Steps
        {
            get { return steps; }
            set
            {
                if (steps != value)
                {
                    steps = value;
                    OnPropertyChanged("Steps");
                }
            }
        }

        private List<Cart> itens;
        public List<Cart> Itens
        {
            get { return itens; }
            set
            {
                if (itens != value)
                {
                    itens = value;
                    OnPropertyChanged("Itens");
                }
            }
        }

        public CartPageViewModel()
        {
            Steps = new List<string> { "Checkout", "Address", "Payment" };
            SelectedSteps = Steps.First();
        }

        int count = 0;
        public void Confirme()
        {
            count++;
            SelectedSteps = Steps[count % Steps.Count];
        }
    }
}
