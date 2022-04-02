using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BaseConverter.ViewModels;
using BaseConverter.Views;

namespace BaseConverter
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new ConverterView
                {
                    DataContext = new ConverterViewModel(),
                };
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}
