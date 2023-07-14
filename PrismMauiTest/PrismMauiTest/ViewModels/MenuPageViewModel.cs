using PrismMauiTest.Errors;

namespace PrismMauiTest.ViewModels
{
    public class MenuPageViewModel : BasePageViewModel
    { 
        public MenuPageViewModel(ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
        }
    }
}