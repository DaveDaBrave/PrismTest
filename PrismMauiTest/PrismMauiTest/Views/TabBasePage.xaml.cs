using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace PrismMauiTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBasePage
    {
        public static readonly BindableProperty ToolbarTemplateProperty = BindableProperty.Create(nameof(ToolbarTemplate), typeof(View), typeof(TabBasePage));
        public static readonly BindableProperty HeadlineTemplateProperty = BindableProperty.Create(nameof(HeadlineTemplate), typeof(View), typeof(TabBasePage));
        private static readonly BindableProperty HeaderMarginProperty = BindableProperty.Create(nameof(HeaderMargin), typeof(Thickness), typeof(TabBasePage), new Thickness(0));

        public View ToolbarTemplate
        {
            get => (View)GetValue(ToolbarTemplateProperty);
            set => SetValue(ToolbarTemplateProperty, value);
        }

        public View HeadlineTemplate
        {
            get => (View)GetValue(HeadlineTemplateProperty);
            set => SetValue(HeadlineTemplateProperty, value);
        }

        public Thickness HeaderMargin => (Thickness) GetValue(HeaderMarginProperty);

        public TabBasePage()
        {
            InitializeComponent();
        }
        
        protected override void OnBindingContextChanged()
        {
            if (HeadlineTemplate != null)
                On<iOS>().SetUseSafeArea(true);

            base.OnBindingContextChanged();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName != "SafeAreaInsets")
            {
                return;
            }

            if (!On<iOS>().UsingSafeArea())
            {
                return;
            }
            
            var insets = On<iOS>().SafeAreaInsets();
            On<iOS>().SetUseSafeArea(false);
            var margin = new Thickness(0, insets.Top, 0, 0);
            SetValue(HeaderMarginProperty, margin);
        }
    }
}