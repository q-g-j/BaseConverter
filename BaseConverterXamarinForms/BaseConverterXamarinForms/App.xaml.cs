using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("BowlbyOne-Regular.otf", Alias = "Title")]
[assembly: ExportFont("selawk.ttf", Alias = "Main")]
[assembly: ExportFont("JetBrainsMono-Regular.ttf", Alias = "Block")]

namespace BaseConverterXamarinForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ConverterView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
