using System.Threading.Tasks;

namespace MessengerMVVM.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : class;
        Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter) where TViewModel : class;
        void CloseWindow();
    }
}
