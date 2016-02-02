using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWAppCustomBehaviorHandsOn
{
    public class ShowDialogBehavior : DependencyObject, IBehavior
    {
        public string Message { get; set; }
        public string MsgTitle { get; set; }

        public DependencyObject AssociatedObject{ get; set;}


        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
            (this.AssociatedObject as Button).Click += Button_Click;
        }



        public void Detach()
        {
            (this.AssociatedObject as Button).Click -= Button_Click;
        }




        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog(this.Message, this.MsgTitle).ShowAsync();
        }
    }
}
