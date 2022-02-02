using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public DelegateCommand NextCommand { get; set; }

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            NextCommand = new DelegateCommand(async () => await DoNextCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        private async Task DoNextCommand()
        {
            await NavigationService.NavigateAsync(Constants.Answer);
        }

    }
}