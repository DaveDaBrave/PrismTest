using CommunityToolkit.Mvvm.Input;
using PrismMauiTest.Errors;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace PrismMauiTest.ViewModels
{
    public abstract class BasePageViewModel : BindableBase, INavigationAware, IInitializeAsync
    {
        private bool _isBusy;
        protected ITaskExecutor Executor { get; }
        protected INavigationService Navigator { get; }
        public AsyncRelayCommand BackCommand { get; }
        
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected BasePageViewModel(ITaskExecutor taskExecutor, INavigationService navigationService)
        {
            Executor = taskExecutor;
            Navigator = navigationService;

            BackCommand = Executor.CreateAsyncCommand(GoBackAsync, CanGoBack);
        }

        protected virtual bool CanGoBack()
        {
            return true;
        }
        
        protected virtual async Task GoBackAsync()
        {
            await Navigator.GoBackAsync();
        }
        
        protected async Task RunWithBusyAsync(Func<Task> callback)
        {
            IsBusy = true;

            try
            {
                await callback();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            await Executor.RunSafeAsync(async () => await OnInitializeAsync(parameters));
        }
        
        public virtual Task OnInitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }
        
        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            // It appears like prism will sometimes not provide parameters. This makes sure all navigations have a guarantee for parameters.
            if (parameters == null)
            {
                var internalParameters = (INavigationParametersInternal) new NavigationParameters();
                internalParameters.Add("__NavigationMode", NavigationMode.New);
                parameters = (NavigationParameters)internalParameters;
            }

            await Executor.RunSafeAsync(async () => await OnNavigatedToAsync(parameters));
        }
        
        public virtual Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }
        
        public async void OnNavigatedFrom(INavigationParameters parameters)
        {
            // It appears like prism will sometimes not provide parameters. This makes sure all navigations have a guarantee for parameters.
            if (parameters == null)
            {
                var internalParameters = (INavigationParametersInternal) new NavigationParameters();
                internalParameters.Add("__NavigationMode", NavigationMode.New);
                parameters = (NavigationParameters)internalParameters;
            }
            await Executor.RunSafeAsync(async () => await OnNavigatedFromAsync(parameters));
        }

        public virtual Task OnNavigatedFromAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }
    }
}
