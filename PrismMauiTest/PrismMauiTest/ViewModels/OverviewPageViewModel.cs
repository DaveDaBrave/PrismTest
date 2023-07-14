using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class OverviewPageViewModel : BasePageViewModel, IApplicationLifecycleAware
    {
        public AsyncRelayCommand ShowModalCommand { get; }

        public OverviewPageViewModel(ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
            ShowModalCommand = Executor.CreateAsyncCommand(ShowModalPage);
        }

        private async Task ShowModalPage()
        {
			await Navigator.NavigateAsync("ModalPage");
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
        }

        public async void OnResume()
        {
        }

        public void OnSleep()
        {
            // Do nothing
        }
    }
}