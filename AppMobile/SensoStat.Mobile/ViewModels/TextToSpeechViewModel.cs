
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Services.Interfaces;
using SensoStat.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SensoStat.Mobile.ViewModels
{
    public class TextToSpeechViewModel : BaseViewModel
    {
        private SpeechConfig _speechConfig;
        private SpeechSynthesizer _speechSynthesizer;
        public Picker Languages = new Picker();

        IEnumerable<Locale> locales;

        public TextToSpeechViewModel(IAlertdialogService alertdialogService, INavigationService navigationService) : base(alertdialogService, navigationService)
        {
            ReadCommand = new DelegateCommand(async () => await DoReadCommand());

            Text = "Bienvenue sur votre séance sensorielle SensoStat";  
        }

        // Public attribut
        #region Lifecycle

        #endregion
        #region Privates

        #endregion
        #region Text => string
        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public bool ActiveBool;
        #endregion
        #region Commands
        public DelegateCommand ReadCommand { get; set; }
        

        private async Task DoReadCommand()
        {
           await SpeechUp(Text);
        }
        #endregion
        #region Methods

        #endregion

        private async Task SpeechUp(string textTo)
        {
           ActiveBool = true;

           _speechConfig.SpeechSynthesisLanguage = "fr_FR";

           _speechSynthesizer = _speechSynthesizer ?? new SpeechSynthesizer(_speechConfig);
           await _speechSynthesizer.SpeakTextAsync(textTo);

           ActiveBool = false;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ActiveBool = false;
            // locales = await TextToSpeech.GetLocalesAsync();
            // locales.ToList().ForEach(lang =>
            // {
            //     Languages.Items.Add(lang.Name);
            // });

            _speechConfig = SpeechConfig.FromSubscription(Constants.CognitiveServicesApiKey, Constants.CognitiveServicesRegion);

            base.OnNavigatedTo(parameters);
        }
    }
}
