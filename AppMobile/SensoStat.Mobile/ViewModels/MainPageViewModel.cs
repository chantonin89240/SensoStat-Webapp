﻿using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SensoStat.Mobile.Commons;
using SensoStat.ViewModels.Base;

namespace SensoStat.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public DelegateCommand StartCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            StartCommand = new DelegateCommand(async () => await DoStartCommand());

            Title = "Bienvenue sur votre séance sensorielle SensoStat!";
        }

        private async Task DoStartCommand()
        {
            await NavigationService.NavigateAsync(Constants.HomeSession);
        }
    }
}
