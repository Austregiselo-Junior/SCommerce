using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace SCommerce.Main.Common
{
    public class NavigationService
    {
        private readonly Frame _rootframe;

        public NavigationService(Frame frame)
        {
            _rootframe = frame;
        }

        /// <summary>
        /// Verificamos se a página ja existe na pilha de chamada, se existir remove e adiciona novamente ou só adiciona.
        ///
        /// </summary>
        /// <param name="sourcePageType"> É o tipo da página</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool Navigate(Type sourcePageType, object parameter = null)
        {
            var list = _rootframe.BackStack.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (item.GetType() == sourcePageType)
                {
                    _rootframe.BackStack.Remove(item);
                    break;
                }
            }

            return _rootframe.Navigate(sourcePageType, parameter); // a page é adicionada novamente a pilha
        }

        public void GoBack()
        {
            if (_rootframe.CanGoBack) { _rootframe.GoBack(); }
        }
    }
}