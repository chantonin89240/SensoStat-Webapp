using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        #region CTOR
        public AnswerViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            ValidAnswerCommand = new DelegateCommand(async () => await DoValidAnswerCommand());

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
        public DelegateCommand ValidAnswerCommand { get; set; }

        private async Task DoValidAnswerCommand()
        {
            await NavigationService.NavigateAsync(Constants.FinalPage);
        }
        #endregion
        #region Methods

        #endregion
    }
}
