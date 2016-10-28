using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitSense.Helpers
{
    public class OnAppearingBehavior : BehaviorBase<Page>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(RelayCommand), typeof(OnAppearingBehavior), null);

        public RelayCommand Command
        {
            get { return (RelayCommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(Page bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Appearing += Bindable_Appearing;
        }

        protected override void OnDetachingFrom(Page bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Appearing -= Bindable_Appearing;
        }

        private void Bindable_Appearing(object sender, EventArgs e)
        {
            if(Command == null)
                return;
            if(Command.CanExecute(null))
                Command.Execute(null);
        }

    }
}
