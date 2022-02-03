using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {       
        #region CTOR
        public MainPageViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            StartCommand = new DelegateCommand(async () => await DoStartCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        #endregion
        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Publics

        #endregion
        #region Commands
        public DelegateCommand StartCommand { get; set; }

        private async Task DoStartCommand()
        {
            await NavigationService.NavigateAsync(Constants.HomeSession);
        }
        #endregion
        #region Methods

        #endregion
    }
}
