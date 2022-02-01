using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensoStat
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
                    : base(initializer)
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterHelpers(containerRegistry);
            RegisterServices(containerRegistry);
            RegisterRepositories(containerRegistry);
            RegisterViews(containerRegistry);
        }

        private void RegisterRepositories(IContainerRegistry containerRegistry)
        {

        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {

        }

        private void RegisterHelpers(IContainerRegistry containerRegistry)
        {

        }

        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NavigationPage);
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(Constants.HomePage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Constants.HomePage}/{Constants.HomePage}");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
