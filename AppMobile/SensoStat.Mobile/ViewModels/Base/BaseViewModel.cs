using System;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace SensoStat.ViewModels.Base
{
	public class BaseViewModel : BindableBase, INavigationAware, IPageLifecycleAware
	{
		//protected IAlertDialogService AlertDialogService;
		protected INavigationService NavigationService;

        // Public attribut
		private string _title;

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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

