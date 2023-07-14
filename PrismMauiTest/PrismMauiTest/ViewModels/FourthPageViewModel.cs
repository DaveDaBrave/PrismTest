using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class FourthPageViewModel : BasePageViewModel
    {
        public AsyncRelayCommand ShowModalCommand { get; }

        public FourthPageViewModel(ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
            ShowModalCommand = Executor.CreateAsyncCommand(async () => await Navigator.NavigateAsync("ModalPage"));
        }
        
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
        }
    }
}