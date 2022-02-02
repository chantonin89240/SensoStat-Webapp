using System;
using Prism;
using Prism.Ioc;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.ViewModels;
using SensoStat.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SensoStat.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Constants.NavigationPage}/{Constants.MainPage}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterHelpers(containerRegistry);
            RegisterRepositories(containerRegistry);
            RegisterServices(containerRegistry);
            RegisterViews(containerRegistry);
        }

        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NavigationPage);
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>(Constants.MainPage);
            containerRegistry.RegisterForNavigation<HomeSession, HomeViewModel>(Constants.HomeSession);
            containerRegistry.RegisterForNavigation<Answer, AnswerViewModel>(Constants.Answer);
            containerRegistry.RegisterForNavigation<FinalPage, FinalPageViewModel>(Constants.FinalPage);
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