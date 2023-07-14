using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class SecondPageViewModel : BasePageViewModel
    {
        public AsyncRelayCommand ShowModalCommand { get; }
        
        public SecondPageViewModel(IDialogService dialogService, ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)     
        {
            ShowModalCommand = Executor.CreateAsyncCommand(async () => await Navigator.NavigateAsync("ModalPage"));
        }
        
        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
        }
    }
}