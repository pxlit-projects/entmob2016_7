using FitSense_UWP.Services;
using FitSense_UWP.Utility;
using FitSense_UWP.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace FitSense_UWP.ViewModel
{
    public class OverViewPageViewModel : INotifyPropertyChanged
    {
        public class PagesModel
        {
            public string PageName { get; set; }
            public string DisplayText { get; set; }
        }

        public ICommand SwitchPageCommand { get; set; }
        private INavigationService navigationService;

        private Type pageType { get; set; }
        public Type PageType
        {
            get { return pageType; }
            set
            {
                pageType = value;
                RaisePropertyChanged("PageType");
            }
        }

        private ObservableCollection<PagesModel> pages { get; set; }
        public ObservableCollection<PagesModel> Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                RaisePropertyChanged("Pages");
            }
        }

        public PagesModel selectedPage { get; set; }
        public PagesModel SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                RaisePropertyChanged("SelectedPage");
                navigationService.NavigateTo(value.PageName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OverViewPageViewModel(INavigationService navigationService)
        {
            //Initialise the pages
            pages = new ObservableCollection<PagesModel>()
            {
                new PagesModel()
                {
                    DisplayText = "MainPage",
                    PageName = "Main"
                },
                new PagesModel()
                {
                    DisplayText = "Login here!",
                    PageName = "Login"
                }
            };

            this.navigationService = navigationService;
            PageType = typeof(MainPage);
            //Initialise commands
            LoadCommands();
        }

        private void LoadCommands()
        {
            SwitchPageCommand = new CustomCommand((Object o) =>
            {
                PageType = navigationService.NavigateTo(SelectedPage.PageName);
                //navigationService.NavigateTo(SelectedPage.PageName);
            }, (Object o) =>
             {
                 return true;
             });
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
