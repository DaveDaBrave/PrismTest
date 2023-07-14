namespace PrismMauiTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverlayBasePage
    {
        public static readonly BindableProperty HeadlineTemplateProperty = BindableProperty.Create(nameof(HeadlineTemplate), typeof(View), typeof(OverlayBasePage));

        private static readonly BindableProperty HeaderMarginProperty =
            BindableProperty.Create(nameof(HeaderMargin), typeof(Thickness), typeof(OverlayBasePage),
                new Thickness(0));

        public View HeadlineTemplate
        {
            get => (View)GetValue(HeadlineTemplateProperty);
            set => SetValue(HeadlineTemplateProperty, value);
        }

        public Thickness HeaderMargin => (Thickness) GetValue(HeaderMarginProperty);
        
        public OverlayBasePage()
        {
            InitializeComponent();
        }

        public async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}