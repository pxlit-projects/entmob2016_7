using FitSense.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace test.fitsense.mocks
{
    class NavigationServiceMock : INavigationService
    {
        public string NavigatedTo { get; private set; }
        public bool Poped { get; private set; }

        public IReadOnlyList<global::Xamarin.Forms.Page> ModalStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public global::Xamarin.Forms.INavigation Navigation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IReadOnlyList<global::Xamarin.Forms.Page> NavigationStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void InsertPageBefore(string pageName, string beforeName)
        {
            throw new NotImplementedException();
        }

        public Task<global::Xamarin.Forms.Page> PopAsync()
        {
            Poped = true;
            return new Task<Xamarin.Forms.Page>(() => new Xamarin.Forms.Page());
        }

        public Task<global::Xamarin.Forms.Page> PopAsync(bool animated)
        {
            Poped = true;
            return new Task<Xamarin.Forms.Page>(() => new Xamarin.Forms.Page()); 
        }

        public Task<global::Xamarin.Forms.Page> PopModalAsync()
        {
            Poped = true;
            return new Task<Xamarin.Forms.Page>(() => new Xamarin.Forms.Page()); 
        }

        public Task<global::Xamarin.Forms.Page> PopModalAsync(bool animated)
        {
            Poped = true;
            return new Task<Xamarin.Forms.Page>(() => new Xamarin.Forms.Page());
        }

        public Task PopToRootAsync()
        {
            Poped = true;
            return Task.Delay(1);
        }

        public Task PopToRootAsync(bool animated)
        {
            Poped = true;
            return Task.Delay(1);
        }

        public Task PushAsync(string pageName)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public Task PushAsync(string pageName, object objectToPass)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public Task PushAsync(string pageName, bool animated)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public Task PushModalAsync(string pageName)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public Task PushModalAsync(string pageName, bool animated)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public Task PushModalAsync(string pageName, object objectToPass)
        {
            NavigatedTo = pageName;
            return Task.Delay(1);
        }

        public void RemovePage(string pageName)
        {
            NavigatedTo = pageName;
        }
    }
}
