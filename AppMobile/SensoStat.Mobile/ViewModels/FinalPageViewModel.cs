using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class FinalPageViewModel : BaseViewModel
    {
        public DelegateCommand CloseCommand { get; set; }

        public FinalPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CloseCommand = new DelegateCommand(() => DoCloseCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        private void DoCloseCommand()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
