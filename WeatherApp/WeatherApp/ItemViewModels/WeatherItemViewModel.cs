﻿using Prism.Commands;
using Prism.Navigation;
using WeatherApp.Models;
using WeatherApp.Views;

namespace WeatherApp.ItemViewModels
{
    public class WeatherItemViewModel : RootResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCityCommand;

        public WeatherItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCityCommand =>
            _selectCityCommand ??
            (_selectCityCommand = new DelegateCommand(SelectCityAsync));

        private async void SelectCityAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                {"root",this}
            };

            await _navigationService.NavigateAsync(nameof(CityDetailPage), parameters);

        }
    }
}
