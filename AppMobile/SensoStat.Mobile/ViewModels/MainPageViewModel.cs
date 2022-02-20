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

            Title = "Bienvenue à cette séance.";

            MsgAccueil = "Vous allez donner votre avis sur 3 savons.";
        }

        #endregion
        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Publics
        // Public attribut
        #region MsgAccueil =>  string
        private string _msgAccueil;

        public string MsgAccueil
        {
            get => _msgAccueil;
            set => SetProperty(ref _msgAccueil, value);
        }
        #endregion
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
