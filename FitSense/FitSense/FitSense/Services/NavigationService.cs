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
        /// <summary>
        /// Method makes sure you can get the right page in a simple way.
        /// </summary>
        /// <param name="pageName">The constant page name</param>
        /// <param name="objectToPass">The object to pass to the new page if any.</param>
        /// <returns>The requested page</returns>
        private Page GetPage(string pageName, object objectToPass = null)
        {
            switch (pageName)
            {
                case PageUrls.LOGINVIEW: return new LoginView();
                case PageUrls.SENSORCONNECTVIEW: return new SensorConnectView();
                case PageUrls.CATEGORIESVIEW: return new CategoriesPage();
                case PageUrls.EXERCISESVIEW: return new ExercisesView();
                case PageUrls.SETSCAROUSEL: return new SetsCarousel();
            }
            return null;
        }

        /// <summary>
        /// The navigation property of the root page. (MainView) 
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// The modalStack of the App navigation.
        /// </summary>
        public IReadOnlyList<Page> ModalStack
        {
            get
            {
                return Navigation.ModalStack;
            }
        }

        /// <summary>
        /// The navigationStack of the App navigation.
        /// </summary>
        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                return Navigation.NavigationStack;
            }
        }

        /// <summary>
        /// Insert a page in front of a page in the navigationStack.
        /// </summary>
        /// <param name="pageName">The page to be inserted</param>
        /// <param name="beforeName">The page it will be inserted before</param>
        public void InsertPageBefore(string pageName, string beforeName)
        {
            Navigation.InsertPageBefore(GetPage(pageName), GetPage(beforeName));
        }

        /// <summary>
        /// Go back in the navigation stack
        /// </summary>
        /// <returns></returns>
        public Task<Page> PopAsync()
        {
            return Navigation.PopAsync();
        }

        /// <summary>
        /// Go back in the navigation with animation.
        /// </summary>
        /// <param name="animated">True if animation is required</param>
        /// <returns></returns>
        public Task<Page> PopAsync(bool animated)
        {
            return Navigation.PopAsync(animated);
        }

        /// <summary>
        /// Go back in the navigation stack
        /// </summary>
        /// <returns></returns>
        public Task<Page> PopModalAsync()
        {
            return Navigation.PopModalAsync();
        }

        /// <summary>
        /// Go back in the navigation with animation.
        /// </summary>
        /// <param name="animated">True if animation is required</param>
        /// <returns></returns>
        public Task<Page> PopModalAsync(bool animated)
        {
            return Navigation.PopModalAsync(animated);
        }

        /// <summary>
        /// Go back to the root page of the application.
        /// </summary>
        /// <returns></returns>
        public Task PopToRootAsync()
        {
            return Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Go back to the root page of the application with animation.
        /// </summary>
        /// <param name="animated">True if animation is required</param>
        /// <returns></returns>
        public Task PopToRootAsync(bool animated)
        {
            return Navigation.PopToRootAsync(animated);
        }

        /// <summary>
        /// Insert a page in the navigation stack.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <returns></returns>
        public Task PushAsync(string pageName)
        {
            return Navigation.PushAsync(GetPage(pageName));
        }

        /// <summary>
        /// Insert a page with a parameter in the navigation stack.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <param name="objectToPass">The object to pass to the new page.</param>
        /// <returns></returns>
        public Task PushAsync(string pageName, object objectToPass)
        {
            Page page = GetPage(pageName);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushAsync(page);
        }

        /// <summary>
        /// Insert a page in the navigation stack with animation.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <param name="animated">True if animation is required</param>
        /// <returns></returns>
        public Task PushAsync(string pageName, bool animated)
        {
            return Navigation.PushAsync(GetPage(pageName), animated);
        }

        /// <summary>
        /// Insert a page in the Modal stack.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <returns></returns>
        public Task PushModalAsync(string pageName)
        {
            Page p = GetPage(pageName);
            return Navigation.PushModalAsync(p);
        }

        /// <summary>
        /// Insert a page with a parameter in the Modal stack.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <param name="objectToPass">The object to pass to the new page.</param>
        /// <returns></returns>
        public Task PushModalAsync(string pageName, object objectToPass)
        {
            Page page = GetPage(pageName, objectToPass);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushModalAsync(page);
        }

        /// <summary>
        /// Insert a page in the Modal stack with animation.
        /// </summary>
        /// <param name="pageName">The name of the page. (Found in PageUrls)</param>
        /// <param name="animated">True if animation is required</param>
        /// <returns></returns>
        public Task PushModalAsync(string pageName, bool animated)
        {
            return Navigation.PushModalAsync(GetPage(pageName), animated);
        }

        /// <summary>
        /// Removes a page from the navigation stack.
        /// </summary>
        /// <param name="pageName"></param>
        public void RemovePage(string pageName)
        {
            Navigation.RemovePage(GetPage(pageName));
        }

        
    }
}
