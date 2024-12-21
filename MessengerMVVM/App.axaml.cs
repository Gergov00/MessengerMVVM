using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MessengerMVVM.Services;
using MessengerMVVM.Services.Implementations;
using MessengerMVVM.ViewModels;
using MessengerMVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MessengerMVVM
{
    public partial class App : Application
    {
        private static IServiceProvider? _services;
        public static IServiceProvider Services => _services ??= InitializeServices().BuildServiceProvider();

        private static IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            // Регистрация ViewModels
            services.AddSingleton<SignUpViewModel>();
            services.AddScoped<LogInViewModel>();
            services.AddScoped<MainWindowViewModel>();

            // Регистрация сервисов
            services.AddSingleton<IUserDialog, UserDialogService>();

            // Регистрация окон с их ViewModel
            services.AddTransient<MainWindow>(s =>
            {
                var viewModel = s.GetRequiredService<MainWindowViewModel>();
                var window = new MainWindow(s)
                {
                    DataContext = viewModel
                };
                //s.GetRequiredService<IUserDialog>().RegisterCloseAction(() => window.Close());

                return window;
            });

            services.AddTransient<SignUp>(s =>
            {

                var viewModel = s.GetRequiredService<SignUpViewModel>();
                var window = new SignUp(s)
                {
                    DataContext = viewModel
                };
                //s.GetRequiredService<IUserDialog>().RegisterCloseAction(() => window.Close());

                return window;
            });

            services.AddTransient<LogIn>(s =>
            {
                var viewModel = s.GetRequiredService<LogInViewModel>();
                var window = new LogIn(s)
                {
                    DataContext = viewModel
                };
                //s.GetRequiredService<IUserDialog>().RegisterCloseAction(() => window.Close());

                return window;
            });

            return services;
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.ShutdownMode = ShutdownMode.OnLastWindowClose;

                // Получаем и показываем начальное окно (SignUp)
                var signUpWindow = Services.GetRequiredService<SignUp>();
                desktop.MainWindow = signUpWindow;
                signUpWindow.Show();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
