using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class ModalPageViewModel : BasePageViewModel
    {
        public AsyncRelayCommand ContinueButtonCommand { get;  }
        
        public ModalPageViewModel(ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
            ContinueButtonCommand = Executor.CreateAsyncCommand(async () => await Navigator.GoBackAsync());
        }
    }
}