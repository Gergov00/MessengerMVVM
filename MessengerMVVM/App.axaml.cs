using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MessengerMVVM.Services;
using MessengerMVVM.ViewModels;
using MessengerMVVM.Views;
using MessengerMVVM.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MessengerMVVM
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            // Настройка DI контейнера
            var services = new ServiceCollection();

            // Регистрация сервисов
            services.AddSingleton<INavigationService, NavigationService>();

            // Регистрация ViewModels
            services.AddTransient<ViewModels.SignUpViewModel>();
            services.AddTransient<ViewModels.MainWindowViewModel>();
            // Добавьте другие ViewModels по необходимости

            ServiceProvider = services.BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Получение ViewModel из DI контейнера
                var signUpViewModel = ServiceProvider.GetRequiredService<SignUpViewModel>();

                // Создание окна и установка DataContext
                var signUpWindow = new SignUp
                {
                    DataContext = signUpViewModel
                };

                // Подписка на событие успешной регистрации
                signUpViewModel.RegistrationSucceeded += () =>
                {
                    // Получение ViewModel для главного окна
                    var mainViewModel = ServiceProvider.GetRequiredService<MainViewModel>();

                    // Создание и показ главного окна
                    var mainWindow = new MainWindow
                    {
                        DataContext = mainViewModel
                    };
                    mainWindow.Show();

                    // Закрытие окна регистрации
                    signUpWindow.Close();
                };

                desktop.MainWindow = signUpWindow;
                signUpWindow.Show();
            }

            base.OnFrameworkInitializationCompleted();
        }
    

    private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}