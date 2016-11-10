using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.Services
{
    public class NavigationService : INavigationService
    {
        private Page GetPage(string pageName, object objectToPass = null)
        {
            switch (pageName)
            {
                case PageUrls.LOGINVIEW: return new LoginView();
                case PageUrls.SENSORCONNECTVIEW: return new SensorConnectView();
                case PageUrls.CATEGORIESVIEW: return new CategoriesPage();
            }
            return null;
        }

        //The navigation property of the root page. (MainView)
        public INavigation Navigation { get; set; }

        public IReadOnlyList<Page> ModalStack
        {
            get
            {
                return Navigation.ModalStack;
            }
        }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                return Navigation.NavigationStack;
            }
        }

        public void InsertPageBefore(string pageName, string beforeName)
        {
            Navigation.InsertPageBefore(GetPage(pageName), GetPage(beforeName));
        }

        public Task<Page> PopAsync()
        {
            return Navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Navigation.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return Navigation.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return Navigation.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navigation.PopToRootAsync(animated);
        }

        public Task PushAsync(string pageName)
        {
            return Navigation.PushAsync(GetPage(pageName));
        }

        public Task PushAsync(string pageName, object objectToPass)
        {
            Page page = GetPage(pageName);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushAsync(page);
        }

        public Task PushAsync(string pageName, bool animated)
        {
            return Navigation.PushAsync(GetPage(pageName), animated);
        }

        public Task PushModalAsync(string pageName, object objectToPass)
        {
            Page page = GetPage(pageName, objectToPass);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(string pageName, bool animated)
        {
            return Navigation.PushModalAsync(GetPage(pageName), animated);
        }

        public void RemovePage(string pageName)
        {
            Navigation.RemovePage(GetPage(pageName));
        }

        public Task PushModalAsync(string pageName)
        {
            Page p = GetPage(pageName);
            return Navigation.PushModalAsync(p);
        }
    }
}
