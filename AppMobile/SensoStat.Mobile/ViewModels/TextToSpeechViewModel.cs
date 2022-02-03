
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;


namespace SensoStat.Mobile.ViewModels
{
    public class TextToSpeechViewModel : BaseViewModel
    {
        //private SpeechConfig _speechConfig;
        //private SpeechSynthetiser _speechSynthetiser;

        public TextToSpeechViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            // ReadCommand = new DelegateCommand(async () => await DoReadCommand());

            Text = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        // Public attribut


        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Text =>  string
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public bool IsRunning;
        #endregion
        #region Commands
        public DelegateCommand ReadCommand { get; set; }

        //private async Task DoReadCommand()
        //{
        //    await SpeechUp(Text);
        //}
        #endregion
        #region Methods

        #endregion

        //private async Task SpeechUp(string text)
        //{
        //    IsRunning = true;
        //    _speechConfig.SpeechSynthesisLanguage = "fr_FR";
        //    _speechSynthetiser = _speechSynthetiser ?? new SpeechSynthetiser(_speechConfig);
        //    await _speechSynthetiser.SpeackTextAsync(text);
              // IsRunning = false;
        //}

        //public override async void OnNavigatedTo(INavigationService navigationService)
        //{
        //    IsRunning = false;
        //    _speechConfig = SpeechConfig.FromSubscription();
        //}
    }
}
