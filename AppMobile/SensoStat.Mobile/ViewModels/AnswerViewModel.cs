using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class AnswerViewModel : BaseViewModel
    {
        public DelegateCommand ValidAnswerCommand { get; set; }

        public AnswerViewModel(INavigationService navigationService) : base(navigationService)
        {
            ValidAnswerCommand = new DelegateCommand(async () => await DoValidAnswerCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        private async Task DoValidAnswerCommand()
        {
            await NavigationService.NavigateAsync(Constants.FinalPage);
        }
    }
}
