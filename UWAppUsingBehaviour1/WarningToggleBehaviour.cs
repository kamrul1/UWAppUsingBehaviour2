using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace UWAppUsingBehaviour1
{
    public class WarningToggleBehaviour : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        public string Message { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            if(this.AssociatedObject is ToggleSwitch) //check is a toggleswitch
            {
                (this.AssociatedObject as ToggleSwitch).Toggled += WarningToggleBehaviour_Toggled;

            }
        }

        private async void WarningToggleBehaviour_Toggled(object sender, RoutedEventArgs e)
        {
            if(!(sender as ToggleSwitch).IsOn)
            {
                await new MessageDialog(this.Message, "Warning").ShowAsync();
            }
        }

        public void Detach()
        {
            (this.AssociatedObject as ToggleSwitch).Toggled -= WarningToggleBehaviour_Toggled;
        }
    }
}
