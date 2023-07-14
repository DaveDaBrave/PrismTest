using PrismMauiTest.ViewModels;
using NavigationMode = Prism.Navigation.NavigationMode;

namespace PrismMauiTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage
    {
        private BasePageViewModel _prevViewModel;

        public MenuPage()
        {
            InitializeComponent();
        }

        void TabbedPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            // we add the navigation mode to the internal parameters, otherwise GetNavigationMode() would throw an exception. 
            // We will default to NavigationMode.New because at this point its not clear if its a new or back navigation.
            var internalParameters = (INavigationParametersInternal) new NavigationParameters();
            internalParameters.Add("__NavigationMode", NavigationMode.New);
            
            _prevViewModel?.OnNavigatedFrom((NavigationParameters)internalParameters);

            _prevViewModel = (CurrentPage as NavigationPage)?.CurrentPage.BindingContext as BasePageViewModel;
            
            _prevViewModel?.OnNavigatedTo((NavigationParameters)internalParameters);
        }
    }
}