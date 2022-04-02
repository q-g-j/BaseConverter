using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BaseConverter.Views
{
    public partial class ConverterView : Window
    {
        public ConverterView()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
