﻿using MessengerMVVM.Models;
using MessengerMVVM.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace MessengerMVVM.ViewModels
{
    public class SignUpViewModel :  WindowViewModelBase
    {
        private readonly SignUpModel _model;
        private readonly IUserDialog _userDialog;

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
        public DelegateCommand GoLogInPageCommand { get; }

        public SignUpViewModel(IUserDialog userDialog)
        {
            _model = new SignUpModel();
            _userDialog = userDialog;

            SignUpCommand = new DelegateCommand(ExecuteSignUp, CanExecuteSignUp)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Email)
                .ObservesProperty(() => Password);

            GoLogInPageCommand = new DelegateCommand(ExecuteGoLogInPage);
        }

        private void ExecuteSignUp()
        {
            try
            {
                _model.Register(Username, Email, Password);
                _userDialog.OpenMainWindow();
                // Дополнительно, вы можете закрыть текущее окно, используя механизм событий или другие подходы.
            }
            catch (ArgumentException ex)
            {
                ShowMessage.Message("Ошибка регистрации", ex.Message);
            }
        }

        private bool CanExecuteSignUp()
        {
            // Добавьте логику валидации, например, проверку на пустые поля
            return true;
        }

        private void ExecuteGoLogInPage()
        {
            _userDialog.OpenLogInWindow();
            OnRequestClose();
            
            // Дополнительно, вы можете закрыть текущее окно.
        }
    }
}
