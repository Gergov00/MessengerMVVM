// UserDialogService.cs
using MessengerMVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MessengerMVVM.Services.Implementations
{
    public class UserDialogService : IUserDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public UserDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        

        public void OpenMainWindow()
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        public void OpenSignUpWindow()
        {
            var signUpWindow = _serviceProvider.GetRequiredService<SignUp>();
            signUpWindow.Show();
        }

        public void OpenLogInWindow()
        {
            var logInWindow = _serviceProvider.GetRequiredService<LogIn>();
            logInWindow.Show();
        }

        
    }
}
