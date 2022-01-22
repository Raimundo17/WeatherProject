using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class CityDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RootResponse _root;

        public CityDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public RootResponse Root
        {
            get => _root;
            set => SetProperty(ref _root, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("root"))
            {
                Root = parameters.GetValue<RootResponse>("root");
                Title = Root.EnglishName;
            }
        }
    }
}
