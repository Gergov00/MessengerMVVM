using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MessengerMVVM.ViewModels;
using MessengerMVVM.Views;
using System;
using System.Threading.Tasks;

namespace MessengerMVVM.Services
{
    public class NavigationService : INavigationService
    {
        private Window _currentWindow;

        public async Task NavigateToAsync<TViewModel>() where TViewModel : class
        {
            await NavigateToAsync<TViewModel, object>(null);
        }

        public async Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter) where TViewModel : class
        {
            // Создайте экземпляр ViewModel
            var viewModel = Activator.CreateInstance(typeof(TViewModel), parameter) as TViewModel;
            if (viewModel == null)
                throw new InvalidOperationException($"Не удалось создать экземпляр ViewModel типа {typeof(TViewModel)}");

            // Определите соответствующую View для ViewModel
            var viewTypeName = typeof(TViewModel).FullName.Replace("ViewModel", "View");
            var viewType = Type.GetType(viewTypeName);
            if (viewType == null)
                throw new InvalidOperationException($"Не удалось найти View для ViewModel типа {typeof(TViewModel)}");

            // Создайте экземпляр View
            var window = Activator.CreateInstance(viewType) as Window;
            if (window == null)
                throw new InvalidOperationException($"Не удалось создать экземпляр View типа {viewType}");

            // Установите DataContext
            window.DataContext = viewModel;

            // Закройте текущее окно, если оно есть
            _currentWindow?.Close();

            // Покажите новое окно
            _currentWindow = window;
            window.Show();
        }

        public void CloseWindow()
        {
            _currentWindow?.Close();
        }
    }
}
