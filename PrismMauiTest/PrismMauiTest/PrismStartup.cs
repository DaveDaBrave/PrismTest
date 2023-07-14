using PrismMauiTest.Errors;
using PrismMauiTest.ViewModels;
using PrismMauiTest.Views;

namespace PrismMauiTest
{
    internal static class PrismStartup
    {
        public static void Configure(PrismAppBuilder builder)
        {
            builder.RegisterTypes(RegisterTypes)
                .AddGlobalNavigationObserver(context => context.Subscribe(x =>
                {
                    if (x.Type == NavigationRequestType.Navigate)
                        Console.WriteLine($"Navigation: {x.Uri}");
                    else
                        Console.WriteLine($"Navigation: {x.Type}");
                    var status = x.Cancelled ? "Cancelled" : x.Result.Success ? "Success" : "Failed";
                    Console.WriteLine($"Result: {status}");
                    if (status == "Failed" && !string.IsNullOrEmpty(x.Result?.Exception?.Message))
                        Console.Error.WriteLine(x.Result.Exception.Message);
                    
                    if (!x.Result.Success)
                    {
                        Console.WriteLine(x.Result.Exception);

                        if (x.Result.Exception.InnerException != null)
                        {
                            Console.WriteLine(x.Result.Exception.InnerException);
                        }
                    }
                }))
                .OnInitialized(OnInitialized)
                .OnAppStart(OnAppStart);
        }

        private static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Prism
            containerRegistry.RegisterGlobalNavigationObserver();

            // Services
            containerRegistry.RegisterSingleton<ITaskExecutor, TaskExecutor>();
            
            // Pages
            containerRegistry.RegisterForNavigation<RootPage>();
            containerRegistry.RegisterForNavigation<MenuPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<InitialLoadingPage, InitialLoadingPageViewModel>();
            containerRegistry.RegisterForNavigation<OverviewPage, OverviewPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<FourthPage, FourthPageViewModel>();
            containerRegistry.RegisterForNavigation<ModalPage, ModalPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
        }
        
        private static void OnInitialized(IContainerProvider containerProvider)
        {
        }

        private static async Task OnAppStart(INavigationService navigationService)
        {
            await navigationService.NavigateAsync("RootPage/LoginPage");
            // await navigationService.NavigateAsync("/MenuPage?selectedTab=OverviewPage");
            
        }
    }
}