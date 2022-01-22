using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherApp.ItemViewModels;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class CityPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiService;
        private ObservableCollection<WeatherItemViewModel> _cities;
        private bool _isRunning;
        private string _search;
        private List<RootResponse> _myCities;
        private DelegateCommand _searchCommand;
        public CityPageViewModel(INavigationService navigationService,
            IApiServices apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Cities";
            LoadCitiesAsync();
        }


        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCities));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCities();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }


        public ObservableCollection<WeatherItemViewModel> Cities
        {
            get => _cities;
            set => SetProperty(ref _cities, value);
        }


        private async void LoadCitiesAsync()
        {

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert(
                         "Error",
                        "The connection to the Internet failed", "Accept");
                });
                return;
            }

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();

           // Response response = await _apiService.GetListAsync<RootResponse>(url,"topcities","/150?apikey=JRt1B7XlK5A31Z9Q7onNLZAOScSI8xMr");

            Response response = await _apiService.GetListAsync<RootResponse>(url, "topcities", "/150?apikey=6A8W9HBlMVhiy1V9cajTVcUwpOEJ8LCw");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            _myCities = (List<RootResponse>)response.Result;

            ShowCities();
        }

        private void ShowCities()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Cities = new ObservableCollection<WeatherItemViewModel>(_myCities.Select(p =>
                new WeatherItemViewModel(_navigationService)
                {
                    Key = p.Key,
                    LocalizedName = p.LocalizedName,
                    EnglishName = p.EnglishName,
                    Country = p.Country,
                    TimeZone = p.TimeZone,
                    GeoPosition = p.GeoPosition,
                    LocalObservationDateTime = p.LocalObservationDateTime,
                    EpochTime = p.EpochTime,
                    WeatherText = p.WeatherText,
                    WeatherIcon = p.WeatherIcon,
                    HasPrecipitation = p.HasPrecipitation,
                    PrecipitationType = p.PrecipitationType,
                    IsDayTime = p.IsDayTime,
                    Temperature = p.Temperature,
                    MobileLink = p.MobileLink,
                    Link = p.Link,
                    Image = Images(p.WeatherIcon)

                }).ToList());
            }
            else
            {
                Cities = new ObservableCollection<WeatherItemViewModel>(_myCities.Select(p =>
                new WeatherItemViewModel(_navigationService)
                {
                    Key = p.Key,
                    LocalizedName = p.LocalizedName,
                    EnglishName = p.EnglishName,
                    Country = p.Country,
                    TimeZone = p.TimeZone,
                    GeoPosition = p.GeoPosition,
                    LocalObservationDateTime = p.LocalObservationDateTime,
                    EpochTime = p.EpochTime,
                    WeatherText = p.WeatherText,
                    WeatherIcon = p.WeatherIcon,
                    HasPrecipitation = p.HasPrecipitation,
                    PrecipitationType = p.PrecipitationType,
                    IsDayTime = p.IsDayTime,
                    Temperature = p.Temperature,
                    MobileLink = p.MobileLink,
                    Link = p.Link,
                    Image = Images(p.WeatherIcon)
                })
                    .Where(p => p.EnglishName.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }

        private string Images(int weatherIcon)
        {
            if (weatherIcon == 1)
                return "ic_1";
            else if (weatherIcon == 2)
                return "ic_2";
            else if (weatherIcon == 3)
                return "ic_3";
            else if (weatherIcon == 4)
                return "ic_4";
            else if (weatherIcon == 5)
                return "ic_5";
            else if (weatherIcon == 6)
                return "ic_6";
            else if (weatherIcon == 7)
                return "ic_7";
            else if (weatherIcon == 8)
                return "ic_8";
            else if (weatherIcon == 9)
                return "ic_9";
            else if (weatherIcon == 10)
                return "ic_10";
            else if (weatherIcon == 11)
                return "ic_11";
            else if (weatherIcon == 12)
                return "ic_12";
            else if (weatherIcon == 13)
                return "ic_13";
            else if (weatherIcon == 14)
                return "ic_14";
            else if (weatherIcon == 15)
                return "ic_15";
            else if (weatherIcon == 16)
                return "ic_16";
            else if (weatherIcon == 17)
                return "ic_17";
            else if (weatherIcon == 18)
                return "ic_18";
            else if (weatherIcon == 19)
                return "ic_19";
            else if (weatherIcon == 20)
                return "ic_20";
            else if (weatherIcon == 21)
                return "ic_21";
            else if (weatherIcon == 22)
                return "ic_22";
            else if (weatherIcon == 23)
                return "ic_23";
            else if (weatherIcon == 24)
                return "ic_24";
            else if (weatherIcon == 25)
                return "ic_25";
            else if (weatherIcon == 26)
                return "ic_26";
            else if (weatherIcon == 27)
                return "ic_27";
            else if (weatherIcon == 28)
                return "ic_28";
            else if (weatherIcon == 29)
                return "ic_29";
            else if (weatherIcon == 30)
                return "ic_30";
            else if (weatherIcon == 31)
                return "ic_31";
            else if (weatherIcon == 32)
                return "ic_32";
            else if (weatherIcon == 33)
                return "ic_33";
            else if (weatherIcon == 34)
                return "ic_34";
            else if (weatherIcon == 35)
                return "ic_35";
            else if (weatherIcon == 36)
                return "ic_36";
            else if (weatherIcon == 37)
                return "ic_37";
            else if (weatherIcon == 38)
                return "ic_38";
            else if (weatherIcon == 39)
                return "ic_39";
            else if (weatherIcon == 40)
                return "ic_40";
            else if (weatherIcon == 41)
                return "ic_41";
            else if (weatherIcon == 42)
                return "ic_42";
            else if (weatherIcon == 43)
                return "ic_43";

            return "ic_1";
        }
    }
}
