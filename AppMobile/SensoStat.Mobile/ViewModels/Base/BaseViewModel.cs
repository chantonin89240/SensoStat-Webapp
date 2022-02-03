using System;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.ViewModels.Base
{
	public class BaseViewModel : BindableBase, INavigationAware, IPageLifecycleAware
	{
        // Protected
		protected IAlertdialogService AlertDialogService;
		protected INavigationService NavigationService;

        // Public attribut
		private string _title;

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

        public BaseViewModel(IAlertdialogService alertdialogService, INavigationService navigationService)
        {
            NavigationService = navigationService;
            AlertDialogService = alertdialogService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void OnAppearing()
        {

        }

        public void OnDisappearing()
        {

        }
    }
}

