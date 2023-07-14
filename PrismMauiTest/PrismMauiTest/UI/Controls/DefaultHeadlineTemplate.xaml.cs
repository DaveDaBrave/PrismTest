namespace PrismMauiTest.UI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultHeadlineTemplate
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(DefaultHeadlineTemplate), string.Empty);
        
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public DefaultHeadlineTemplate()
        {
            InitializeComponent();
        }
    }
}
