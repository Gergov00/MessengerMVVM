using MessengerMVVM.Models;
using MessengerMVVM.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace MessengerMVVM.ViewModels
{
    public class LogInViewModel : WindowViewModelBase
    {
        private readonly LogInModel _model;
        private readonly IUserDialog _userDialog;

        

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

        public DelegateCommand LogInCommand { get; }
        public DelegateCommand GoToSignUpPageCommand { get; }

        public LogInViewModel(IUserDialog userDialog)
        {
            _model = new LogInModel();
            _userDialog = userDialog;

            LogInCommand = new DelegateCommand(ExecuteSignUp, CanExecuteSignUp)
                .ObservesProperty(() => Email)
                .ObservesProperty(() => Password);

            GoToSignUpPageCommand = new DelegateCommand(ExecuteGoSignUpPage);
        }

        private void ExecuteSignUp()
        {
            try
            {
                _model.LogIn(Email, Password);
                _userDialog.OpenMainWindow();
                OnRequestClose();
                // Дополнительно, вы можете закрыть текущее окно, используя механизм событий или другие подходы.
            }
            catch (ArgumentException ex)
            {
                ShowMessage.Message("Ошибка", ex.Message);
            }
        }

        private bool CanExecuteSignUp()
        {
            // Добавьте логику валидации, например, проверку на пустые поля
            return true;
        }

        private void ExecuteGoSignUpPage()
        {
            _userDialog.OpenLogInWindow();
            OnRequestClose();

            // Дополнительно, вы можете закрыть текущее окно.
        }
    }
}
