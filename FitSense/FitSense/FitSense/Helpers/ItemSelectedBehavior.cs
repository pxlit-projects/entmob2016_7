using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitSense.Helpers
{
    class ItemSelectedBehavior : BehaviorBase<ListView>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(RelayCommand<object>), typeof(OnAppearingBehavior), null);

        public RelayCommand<object> Command
        {
            get { return (RelayCommand<object>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            //BindingContext = bindable.Parent.BindingContext;
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += Bindable_ItemSelected;

        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ItemSelected -= Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command == null)
                return;
            if (Command.CanExecute(e.SelectedItem))
                Command.Execute(e.SelectedItem);
        }

    }
}
