using System;
using Prism;
using Prism.Ioc;
using SensoStat.Commons;
using SensoStat.ViewModels;
using SensoStat.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensoStat
{
    public partial class App : Application
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

       protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
