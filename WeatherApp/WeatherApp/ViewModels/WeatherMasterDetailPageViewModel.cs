using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WeatherApp.ItemViewModels;
using WeatherApp.Models;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class WeatherMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public WeatherMasterDetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
            {
                Icon = "LogoFinal",
                PageName = $"{nameof(HomePage)}",
                Title = "Home"
            },
                new Menu
            {
                Icon = "LogoFinal",
                PageName = $"{nameof(Login)}",
                Title = "Login"
            },
                  new Menu
            {
                Icon = "ic_history",
                PageName = $"{nameof(CityPage)}",
                Title = "Cities",
                //IsLoginRequired
            },
            new Menu
            {
                Icon = "LogoFinal",
                PageName = $"{nameof(About)}",
                Title = "About"
            },
            //new Menu
            //{
            //    Icon = "ic_person",
            //    PageName = $"{nameof(ModifyUserPage)}",
            //    Title = Languages.ModifyUser,
            //    IsLoginRequired = true
            //},
            //new Menu
            //{
            //    Icon = "ic_exit_to_app",
            //    PageName = $"{nameof(LoginPage)}",
            //    Title = Languages.Login
            //}
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }
}
