// WindowViewModelBase.cs
using Prism.Mvvm;
using System;

namespace MessengerMVVM.ViewModels
{
    public class WindowViewModelBase : BindableBase
    {
        public event Action? RequestClose;

        protected void OnRequestClose()
        {
            RequestClose?.Invoke();
        }
    }
}
