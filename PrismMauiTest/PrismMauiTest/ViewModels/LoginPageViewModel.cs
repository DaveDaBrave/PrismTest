using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
        private readonly IPageDialogService _dialogService;
        
        public AsyncRelayCommand LoginByPasswordCommand { get; }

        public LoginPageViewModel(IPageDialogService dialogService, ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
            _dialogService = dialogService;

            LoginByPasswordCommand = Executor.CreateAsyncCommand(LoginByPasswordAsync);
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
        }
        
        private async Task LoginByPasswordAsync()
        {
			await Navigator.NavigateAsync("/InitialLoadingPage");
        }
    }
}
