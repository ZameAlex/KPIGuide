using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KPIGuide.Services;
using KPIGuide.Services.Implementation;
using KPIGuide.Views;

namespace KPIGuide
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var csharpTab = new TabbedPage();
            csharpTab.Children.Add(new MapPage(null,null,null) { Title = "Local" });
            csharpTab.Children.Add(new Info { Title = "Download" });
            csharpTab.Children.Add(new About { Title = "Embedded" });
            MainPage = csharpTab;
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
