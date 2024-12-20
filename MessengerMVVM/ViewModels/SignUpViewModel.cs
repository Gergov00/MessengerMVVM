using MessengerMVVM.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.ComponentModel;

namespace MessengerMVVM.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
        private readonly SignUpModel _model;

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand SignUpCommand { get; }

        public SignUpViewModel()
        {
            _model = new SignUpModel();
            SignUpCommand = new DelegateCommand(ExecuteSignUp, CanExecuteSignUp)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Email)
                .ObservesProperty(() => Password);
        }

        private void ExecuteSignUp()
        {
            try
            {
                _model.Register(Username, Email, Password);
                // Здесь можно добавить логику перехода на другую страницу или отображения сообщения об успехе
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, отображение сообщения пользователю
            }
        }

        private bool CanExecuteSignUp()
        {
            // Простейшая валидация
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password);
        }
    }
}
