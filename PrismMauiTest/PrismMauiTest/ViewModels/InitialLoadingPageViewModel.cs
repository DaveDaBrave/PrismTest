using PrismMauiTest.Errors;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace PrismMauiTest.ViewModels
{
    public class InitialLoadingPageViewModel : BasePageViewModel
    {
        public InitialLoadingPageViewModel(IDialogService dialogService, ITaskExecutor taskExecutor, INavigationService navigationService) : base(taskExecutor, navigationService)  
        {
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            // Order is important here to some degree. Do not change it without understanding the consequences!
            await RunWithBusyAsync(async () =>
            {
                try
                {
                    if (parameters.GetNavigationMode() == NavigationMode.Back)
                    {
                        await Navigator.NavigateAsync("/MenuPage");
                        return;
                    }
                
                    // await Navigator.NavigateAsync("SecondPage"); // with SecondPage it presents ModalPage correct
                    await Navigator.NavigateAsync("ModalPage");
                }
                catch (Exception)
                {
                }
            });
        }
    }
}